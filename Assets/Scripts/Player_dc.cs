using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class Player_dc : MonoBehaviour
{
    private Controls controls;

    [SerializeField] private bool moveKeyHeld;

    private void Awake() => controls = new Controls();

    private void OnEnable() {
        controls.Enable();
        Debug.Log("controls.Enable()");
        controls.Player.Movement.started += OnMovement;
        controls.Player.Movement.canceled += OnMovement;

        controls.Player.Exit.performed += OnExit;
    }

    private void OnDisable() {
        controls.Disable();

        controls.Player.Movement.started -= OnMovement;
        controls.Player.Movement.canceled -= OnMovement;

        controls.Player.Exit.performed -= OnExit;
    }

    private void OnMovement(InputAction.CallbackContext ctx) {
        if (ctx.started)
        moveKeyHeld = true;
        else if (ctx.canceled)
        moveKeyHeld = false;
    }

    private void OnExit(InputAction.CallbackContext ctx) {
        Debug.Log("Exit");
    }

    private void FixedUpdate() {
        if (GameManager_dc.instance.IsPlayerTurn && moveKeyHeld)
        MovePlayer();
    }

    private void MovePlayer() {
        Debug.Log("1");
        transform.position += (Vector3)controls.Player.Movement.ReadValue<Vector2>();
        GameManager_dc.instance.EndTurn();
    }
}
