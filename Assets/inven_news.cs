using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inven_news : MonoBehaviour
{
    public GameObject inGameNews;
    public GameObject inGameLetter;
    public GameObject toinvenNews;
    public GameObject toinvenLetter;

    void Start()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {

                Debug.Log("½¹");
                Inventory.InventorySend(toinvenNews, null, "News");
                SoundManager.instance.ItemSound.Play();
                inGameNews.SetActive(false); 
                Inventory.InventorySend(toinvenLetter, null, "Letter");
                inGameLetter.SetActive(false);
            }

        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
