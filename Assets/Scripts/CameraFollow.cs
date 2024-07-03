using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject target;
    void Start()
    {
        target = GameObject.FindWithTag("Player");
    }
    void LateUpdate()
    {
        if (target != null)
        {
            transform.position = new Vector3 (target.transform.position.x, target.transform.position.y, -10);

        }
        else
        {
            // print("no player");
            target = GameObject.FindWithTag("Player");
        }
    }
}
