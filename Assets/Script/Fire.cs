using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Fire : MonoBehaviour
{

    private bool playerEnter = false;

    void Start()
    {
        Screen.SetResolution(1920, 1080, true);
    }

    void Update()
    {
        if (playerEnter && Input.GetKeyDown(KeyCode.Space))
        {
            FireCount.fire++;
            FireCount.fireAdd = true;
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
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
