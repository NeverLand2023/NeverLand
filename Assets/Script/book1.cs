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
        // 스페이스바 입력 감지
        if (Input.anyKeyDown)
        {


            if (Input.GetKeyDown(KeyCode.Space))
            {
                if(isBook1Active)
                {
                    book1UI.SetActive(true);
                    Debug.Log("충돌 감지");
                    isBook1Active = false;
                }
              
            }
            

            else
            {
                book1UI.SetActive(false);
            
            }
        }
    }


    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Player"))

        {
            // BookLoan UI를 활성화

            isBook1Active = true;


        
        }

    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Player"))  // 플레이어와의 충돌이 끝났을 때
        {
            // BookLoan UI를 비활성화
            //bookLoanUI.SetActive(false);
            isBook1Active = false;
        }
    }
}