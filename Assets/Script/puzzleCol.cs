using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzleCol : MonoBehaviour
{
    public GameObject puzzle;
    public GameObject nextPosition;

    private GameObject playerObject;
    public GameObject hint;



    void Start()
    {
        playerObject = GameObject.Find("Main_Hook");
        StartCoroutine(ActivateHint(hint, 1f));
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

    IEnumerator ActivateHint(GameObject obj, float duration)
    {
        obj.SetActive(true);

        yield return new WaitForSeconds(duration);

        obj.SetActive(false);

    }
}
