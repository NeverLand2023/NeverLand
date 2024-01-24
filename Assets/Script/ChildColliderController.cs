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
        audioSource = gameObject.AddComponent<AudioSource>();  // AudioSource ���� �߰�
        audioSource.clip = hand_sound;
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("��");
            // �÷��̾ �ݶ��̴��� �����Ǹ� "hand" ������Ʈ�� Ȱ��ȭ
            hand.SetActive(true);
            audioSource.Play();
            handcolider.enabled = false;


        }
    }
}