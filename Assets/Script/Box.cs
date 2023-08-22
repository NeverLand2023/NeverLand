using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Box : MonoBehaviour
{
    public int boxNum;
    private bool playerEnter = false;

    public GameObject numNoteUI;
    public GameObject numNotePrefab;
    public GameObject c_numPrefab;
    public string numbernoteName;

    public GameObject NoteUI;
    public GameObject notePrefab;
    public GameObject c_notePrefab;
    public string noteName;

    private bool boxOpened = false;
    private bool extraDone = false;

    // Update is called once per frame
    void Update()
    {
        if(playerEnter && Input.GetKeyDown(KeyCode.Space) && !boxOpened)
        {
            boxOpened = true;
            SoundManager.instance.playSFX(SoundManager.SFX.보물상자, false);
            Debug.Log("Box" + boxNum + " Open");
            string BoxName = $"box{boxNum}Open";
            GameObject OpenBox = GameObject.Find(BoxName);
            OpenBox.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            gameObject.transform.localScale = new Vector3(0.001f, 0.001f, 0.001f);

            GameObject note = Instantiate(numNotePrefab, transform);
            StartCoroutine(MoveNoteUp(note, numNoteUI, c_numPrefab, numbernoteName));
        }
        
    }

    private IEnumerator MoveNoteUp(GameObject noteObject, GameObject invenNote, GameObject clickNote, string objName)
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
        Inventory.InventorySend(invenNote, clickNote, objName);

        if(boxNum == 3 && !extraDone)
        {
            GameObject note2 = Instantiate(notePrefab, transform);
            StartCoroutine(MoveNoteUp(note2, NoteUI, c_notePrefab, noteName));
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
