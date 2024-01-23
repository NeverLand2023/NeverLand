using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class steering_gear : MonoBehaviour
{
    public GameObject steeringgear;
    public GameObject background_black;
    public bool issteeringActive = false;
    // Start is called before the first frame update
    void Start()
    {
        steeringgear.SetActive(false);
        background_black.SetActive(false);
    }
    void Update()
    {
        // �����̽��� �Է� ����
        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (issteeringActive)
                {
                    //�浹 & �����̽��� ������ ui Ȱ��ȭ
                    background_black.SetActive(true);
                    steeringgear.SetActive(true);
                    
                    Debug.Log("�浹 ����");
                    issteeringActive = false;
                }

            }

            else
            {
                steeringgear.SetActive(false);
                background_black.SetActive(false);
            }
        }

    }


    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Player"))

        {
            // BookLoan UI�� Ȱ��ȭ

            issteeringActive = true;

        }

    }


    
}
