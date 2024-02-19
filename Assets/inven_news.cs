using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inven_news : MonoBehaviour
{
    public GameObject inGameNews;
    public GameObject inGameLetter;
    public GameObject toinvenNews;
    public GameObject toinvenLetter;
    private AudioSource audioSource;
    public AudioClip PCcallSound;
    private BoxCollider2D myCollider;

    private void Start()
    {
        myCollider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                SoundManager.instance.ItemSound.Play();

                Debug.Log("½¹");
                Inventory.InventorySend(toinvenNews, null, "News");
                
                inGameNews.SetActive(false); 
                Inventory.InventorySend(toinvenLetter, null, "Letter");
                inGameLetter.SetActive(false);
                myCollider.enabled = false;



                Invoke("sound", 1.5f);
            }

        }


    }


    void sound()
    {
        audioSource = gameObject.AddComponent<AudioSource>();  // AudioSource µ¿Àû Ãß°¡
        audioSource.clip = PCcallSound;
        audioSource.Play();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
