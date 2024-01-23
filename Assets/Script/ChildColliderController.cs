using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildColliderController : MonoBehaviour
{

    public GameObject hand;


    void Start()
    {
        //childObject = transform.Find("hand").gameObject;
        hand.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("쿵");
            // 플레이어가 콜라이더에 감지되면 "hand" 오브젝트를 활성화
            hand.SetActive(true);
        }
    }
}