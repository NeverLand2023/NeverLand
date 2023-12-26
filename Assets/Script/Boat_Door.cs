using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat_Door : MonoBehaviour
{
    public GameObject keypad; 
    public GameObject lockEmoji;

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

            StartCoroutine(ShowEmoji(lockEmoji, 0.8f));

        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            onDoor = false;
            if (showKeypad)
            {
                Main_Hook.attackAvailable = true;
                keypad.SetActive(false);
                showKeypad = false;
            }
        }
    }

    IEnumerator ShowEmoji(GameObject obj, float delayTime)
    {
        obj.SetActive(true);

        yield return new WaitForSeconds(delayTime);

        obj.SetActive(false);
    }


}
