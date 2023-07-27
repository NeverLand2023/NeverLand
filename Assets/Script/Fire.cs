using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Fire : MonoBehaviour
{

    private bool playerEnter = false;
    static int fire = 0;
    public TMP_Text text;


    void Start()
    {
        Screen.SetResolution(1920, 1080, true);
    }

    void Update()
    {
        if (playerEnter && Input.GetKeyDown(KeyCode.Space))
        {
            fire++;
            text.text = fire.ToString();
            Debug.Log(fire);
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

}
