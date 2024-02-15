using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzleCol : MonoBehaviour
{
    public GameObject puzzle;
    public GameObject nextPosition;

    private GameObject playerObject;


    void Start()
    {
        playerObject = GameObject.Find("Main_Hook");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ChangePlayerPosition();
        }
    }

    private void ChangePlayerPosition()
    {
        if (nextPosition != null)
        {
            playerObject.transform.position = nextPosition.transform.position;
            puzzle.SetActive(false);
        }
    }
}
