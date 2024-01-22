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
            Debug.Log("��");
            // �÷��̾ �ݶ��̴��� �����Ǹ� "hand" ������Ʈ�� Ȱ��ȭ
            hand.SetActive(true);
        }
    }
}