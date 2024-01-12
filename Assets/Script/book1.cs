using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class book1 : MonoBehaviour
{
    public GameObject book1UI;
    public bool isBook1Active = false;
    private void Awake()
    {
        book1UI.SetActive(false);
    }

    void Update()
    {
        // �����̽��� �Է� ����
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isBook1Active)
            {
                //�浹 & �����̽��� ������ ui Ȱ��ȭ
                book1UI.SetActive(true);
                Debug.Log("�浹 ����");
                isBook1Active = false;
            }
            else
            {
                // �����̽��ٸ� ������ �� UI�� Ȱ��ȭ
                book1UI.SetActive(false);
                //isBookLoanActive = true;
            }
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Player"))

        {
            // BookLoan UI�� Ȱ��ȭ

            isBook1Active = true;
        }

    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Player"))  // �÷��̾���� �浹�� ������ ��
        {
            // BookLoan UI�� ��Ȱ��ȭ
            //bookLoanUI.SetActive(false);
            isBook1Active = false;
        }
    }
}