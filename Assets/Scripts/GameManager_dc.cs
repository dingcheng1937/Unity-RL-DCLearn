using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_dc : MonoBehaviour
{
    public static  GameManager_dc instance;
    [SerializeField] private float time = 0.1f;
    [SerializeField] private bool isPlayerTurn = true;
    public bool IsPlayerTurn { get => isPlayerTurn; }
    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        Instantiate(Resources.Load<GameObject>("player_dc")).name = "dc";
    }

    public void EndTurn() {
        isPlayerTurn = false;
        StartCoroutine(WaitForTurns());
  }

    private IEnumerator WaitForTurns() {
        yield return new WaitForSeconds(time);
        isPlayerTurn = true;
    }
}
