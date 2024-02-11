using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildColliderController : MonoBehaviour
{
    private AudioSource audioSource;
    public GameObject hand;
    public AudioClip hand_sound;
    public BoxCollider2D handcolider;



    void Start()
    {
        //childObject = transform.Find("hand").gameObject;
        hand.SetActive(false);
        //handcolider = hand.GetComponent<BoxCollider2D>();
        audioSource = gameObject.AddComponent<AudioSource>();  // AudioSource 동적 추가
        audioSource.clip = hand_sound;
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("쿵");
            // 플레이어가 콜라이더에 감지되면 "hand" 오브젝트를 활성화
            hand.SetActive(true);
            audioSource.Play();
            handcolider.enabled = false;


        }
    }
}