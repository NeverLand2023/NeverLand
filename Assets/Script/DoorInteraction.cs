using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    public Transform arriveTrans;

    private bool hookEnter= false;
    private GameObject Hook;

    private void Start()
    {
        Hook = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        if(hookEnter && Input.GetKeyDown(KeyCode.Space))
        {
            Hook.transform.position = arriveTrans.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hookEnter = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        hookEnter= false;
    }
}
