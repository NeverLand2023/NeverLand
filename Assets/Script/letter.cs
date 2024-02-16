using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class letter : MonoBehaviour
{

    public GameObject letterUI;
    public bool collisionLetter = false;
    public bool UIopen = true;





    void Update()
    {

        if (collisionLetter)
        {
            // 스페이스바 입력 감지

                if (Input.GetKeyDown(KeyCode.Space))
                {
                   // if (collisionLetter)
                    //{
                        letterUI.SetActive(true);
                        Debug.Log("충돌 감지");
                        


                        if (UIopen)
                        {
                            UIopen = false;
                            Main_Hook.attackAvailable = false;
                        }
                        else
                        {
                            letterUI.SetActive(false);

                            Debug.Log("close");
                            UIopen = true;
                            Main_Hook.attackAvailable = true;
                        }


                    //}


                }


            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.W))
            {
                letterUI.SetActive(false);
                Main_Hook.attackAvailable = true;
            }
        }
        

    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Player"))

        {
            collisionLetter = true;
        }

    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Player"))  // 플레이어와의 충돌이 끝났을 때
        {

            collisionLetter = false;
        }
    }
}
