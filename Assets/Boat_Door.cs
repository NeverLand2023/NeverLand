using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat_Door : MonoBehaviour
{
    public GameObject keypad; 

    private bool onDoor = false;
    private bool showKeypad = false;

    void Update()
    {
        if (onDoor)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (!showKeypad)
                {
                    Main_Hook.attackAvailable = false;
                    keypad.SetActive(true);
                    showKeypad = true;
                }
                else
                {
                    Main_Hook.attackAvailable = true;
                    keypad.SetActive(false);
                    showKeypad = false;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            onDoor = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            onDoor = false;
            if (showKeypad)
            {
                Main_Hook.attackAvailable = false;
                keypad.SetActive(false);
                showKeypad = false;
            }
        }
    }


}
