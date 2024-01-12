using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class book_loan : MonoBehaviour
{  
    public GameObject bookLoanUI;
    public bool isBookLoanActive = false;

    private void Awake()
    {
        bookLoanUI.SetActive(false);
    }

    void Update()
    {
        // �����̽��� �Է� ����
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isBookLoanActive)
            {
              //�浹 & �����̽��� ������ ui Ȱ��ȭ
                bookLoanUI.SetActive(true);
                Debug.Log("�浹 ����");
                isBookLoanActive = false;
            }
            else
            {
                // �����̽��ٸ� ������ �� UI�� Ȱ��ȭ
                bookLoanUI.SetActive(false);
                //isBookLoanActive = true;
            }
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == ("Player"))
                
        {
            // BookLoan UI�� Ȱ��ȭ
            
            isBookLoanActive = true;
        }

    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Player"))  // �÷��̾���� �浹�� ������ ��
        {
            // BookLoan UI�� ��Ȱ��ȭ
            //bookLoanUI.SetActive(false);
            isBookLoanActive = false;
        }
    }
}
