using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Box : MonoBehaviour
{
    public int boxNum;
    private bool playerEnter = false;

    public GameObject NoteUI;
    public GameObject notePrefab;
    public GameObject c_notePrefab;

    private bool boxOpened = false;
    private bool extraDone = false;

    // Update is called once per frame
    void Update()
    {
        if(playerEnter && Input.GetKeyDown(KeyCode.Space) && !boxOpened)
        {
            boxOpened = true;
            Debug.Log("Box" + boxNum + " Open");
            string BoxName = $"box{boxNum}Open";
            GameObject OpenBox = GameObject.Find(BoxName);
            OpenBox.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            gameObject.transform.localScale = new Vector3(0.001f, 0.001f, 0.001f);

            GameObject note = Instantiate(notePrefab, transform);
            StartCoroutine(MoveNoteUp(note));
        }
        
    }

    private IEnumerator MoveNoteUp(GameObject noteObject)
    {
        RectTransform noteRectTransform = noteObject.GetComponent<RectTransform>();
        Vector2 startPosition = noteRectTransform.anchoredPosition;
        Vector2 targetPosition = new Vector2(startPosition.x, startPosition.y + 700);

        float upTime = 0f;
        while (upTime < 1.2f)
        {
            noteRectTransform.anchoredPosition = Vector2.Lerp(startPosition, targetPosition, upTime / 1.2f);
            upTime += Time.deltaTime;
            yield return null;
        }
        Destroy(noteObject);
        Inventory.InventorySend(NoteUI, c_notePrefab);

        if(boxNum == 3 && !extraDone)
        {
            GameObject note2 = Instantiate(notePrefab, transform);
            StartCoroutine(MoveNoteUp(note2));
            extraDone = true;
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            playerEnter = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerEnter = false;
        }
    }
}
