using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class book_loan : MonoBehaviour
{  
    public GameObject bookLoanUI;
    public bool collisionLoan= false;
    public bool UIopen = true;

    private void Awake()
    {
        bookLoanUI.SetActive(false);
    }

    void Update()
    {

        if (collisionLoan)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
               
                    bookLoanUI.SetActive(true);
                    Debug.Log("�浹 ����");
                    //collisionBOOK = false;


                    if (UIopen)
                    {
                        UIopen = false;
                        Main_Hook.attackAvailable = false;
                    }
                    else
                    {
                        bookLoanUI.SetActive(false);

                        Debug.Log("close");
                        UIopen = true;
                        Main_Hook.attackAvailable = true;
                    }


                


            }

        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.W))
        {
            bookLoanUI.SetActive(false);
            Main_Hook.attackAvailable = true;
        }

    }


    void OnCollisionStay2D(Collision2D collision)
        {
            if (collision.gameObject.tag == ("Player"))
                
        {
            // BookLoan UI�� Ȱ��ȭ

            collisionLoan = true;

        }

    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Player"))  // �÷��̾���� �浹�� ������ ��
        {
            // BookLoan UI�� ��Ȱ��ȭ
            //bookLoanUI.SetActive(false);
            collisionLoan = false;
        }
    }
}
