using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire_hint : MonoBehaviour
{
    public GameObject FireHint;
    
    public bool FireHintUIActive = false;
    public GameObject Vanishing;

    private AudioSource audioSource;
    public AudioClip clickbox;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();  // AudioSource 동적 추가
        audioSource.clip = clickbox;
    }

    void Update()
    {
        // 스페이스바 입력 감지
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (FireHintUIActive)
            {
                    FireHint.SetActive(true);
                    Vanishing.SetActive(false);
                    
                    Debug.Log("충돌 감지");
                    audioSource.Play();
                    FireHintUIActive = false;
             }
            else
            {
                FireHint.SetActive(false);

            }

        }


        
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Player"))

        {


            FireHintUIActive = true;

        }
        else
        {
            FireHintUIActive = false;
        }

    }



}


   

