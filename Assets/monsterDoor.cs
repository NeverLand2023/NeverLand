using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterDoor : MonoBehaviour
{
    public GameObject puzzle;
    public GameObject puzzlePosition;

    private bool isColliding = false;
    private GameObject playerObject;



    void Start()
    {
        playerObject = GameObject.Find("Main_Hook");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            isColliding = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isColliding = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isColliding)
        {
            ChangePlayerPosition();
        }
    }

    private void ChangePlayerPosition()
    {
        if (puzzlePosition != null)
        {
            playerObject.transform.position = puzzlePosition.transform.position;
            puzzle.SetActive(true);
        }
    }

}
