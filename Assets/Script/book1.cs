using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class book1 : MonoBehaviour
{
    public GameObject book1UI;
    public bool collisionBOOK = false;
    public bool UIopen = true;
    private void Awake()
    {
        book1UI.SetActive(false);
    }

    void Update()
    {
        if (collisionBOOK)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {

                book1UI.SetActive(true);
                Debug.Log("�浹 ����");
                //collisionBOOK = false;


                if (UIopen)
                {
                    UIopen = false;
                    Main_Hook.attackAvailable = false;
                }
                else
                {
                    book1UI.SetActive(false);

                    Debug.Log("close");
                    UIopen = true;
                    Main_Hook.attackAvailable = true;
                }





            }

        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.W))
        {
            book1UI.SetActive(false);
            Main_Hook.attackAvailable = true;
        }

    }


    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Player"))

        {
            // BookLoan UI�� Ȱ��ȭ

            collisionBOOK = true;


        
        }

    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Player"))  // �÷��̾���� �浹�� ������ ��
        {
            // BookLoan UI�� ��Ȱ��ȭ
            //bookLoanUI.SetActive(false);
            collisionBOOK = false;
        }
    }
}