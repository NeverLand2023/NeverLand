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
        // 스페이스바 입력 감지
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isBookLoanActive)
            {
              //충돌 & 스페이스바 감지시 ui 활성화
                bookLoanUI.SetActive(true);
                Debug.Log("충돌 감지");
                isBookLoanActive = false;
            }
            else
            {
                // 스페이스바를 눌렀을 때 UI를 활성화
                bookLoanUI.SetActive(false);
                //isBookLoanActive = true;
            }
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == ("Player"))
                
        {
            // BookLoan UI를 활성화
            
            isBookLoanActive = true;
        }

    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Player"))  // 플레이어와의 충돌이 끝났을 때
        {
            // BookLoan UI를 비활성화
            //bookLoanUI.SetActive(false);
            isBookLoanActive = false;
        }
    }
}
