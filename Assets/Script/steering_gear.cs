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
        // 스페이스바 입력 감지
        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (issteeringActive)
                {
                    //충돌 & 스페이스바 감지시 ui 활성화
                    background_black.SetActive(true);
                    steeringgear.SetActive(true);
                    
                    Debug.Log("충돌 감지");
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
            // BookLoan UI를 활성화

            issteeringActive = true;

        }

    }


    
}
