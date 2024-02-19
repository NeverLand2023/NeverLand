using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    public Transform arriveTrans;
    public bool BoxButtIn = false;
    public bool BoxButtOut = false;

    private bool hookEnter = false;
    private GameObject Hook;
    private GameObject ResetButton;

    private void Start()
    {
        ResetButton = GameObject.Find("ResetButton");
        Hook = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        if (hookEnter && Input.GetKeyDown(KeyCode.Space))
        {
            Hook.transform.position = arriveTrans.position;
            Debug.Log("going from " + this.gameObject.name);
            SoundManager.instance.doorSound.Play();
            if (BoxButtIn)
            {
                ResetButton.SetActive(true);
            }
            else if (BoxButtOut)
            {

                ResetButton.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            hookEnter = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            hookEnter = false;

        }
    }
}
