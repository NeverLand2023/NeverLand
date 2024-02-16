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
                    Debug.Log("충돌 감지");
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
            // BookLoan UI를 활성화

            collisionLoan = true;

        }

    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Player"))  // 플레이어와의 충돌이 끝났을 때
        {
            // BookLoan UI를 비활성화
            //bookLoanUI.SetActive(false);
            collisionLoan = false;
        }
    }
}
