using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toB2 : MonoBehaviour
{
    public Transform arriveTrans;
    private GameObject Hook;

    private void Start()
    {
        Hook = GameObject.FindWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Vector3 newPosition = arriveTrans.position;
            newPosition.z = Hook.transform.position.z; 
            Hook.transform.position = newPosition;
        }
    }
}