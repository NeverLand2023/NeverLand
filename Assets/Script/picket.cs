using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class picket : MonoBehaviour
{
    public GameObject hintUI;
    public float interactionRadius = 1.5f;
    private bool isInRange = false;

    // Start is called before the first frame update
    void Start()
    {
        hintUI.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.Space))
        {
            ToggleHintUI(); 
        }
            
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) 
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            isInRange = false;
            hintUI.gameObject.SetActive(false);
        }
    }

    private void ToggleHintUI() 
    {
        if (hintUI.gameObject.activeSelf)
        {
            hintUI.gameObject.SetActive(false);
        }
        else 
        {
            hintUI.gameObject.SetActive(true);
        }
    }
}
