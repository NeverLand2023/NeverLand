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
            // �����̽��� �Է� ����

                if (Input.GetKeyDown(KeyCode.Space))
                {
                   // if (collisionLetter)
                    //{
                        letterUI.SetActive(true);
                        Debug.Log("�浹 ����");
                        


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
        if (collision.gameObject.tag == ("Player"))  // �÷��̾���� �浹�� ������ ��
        {

            collisionLetter = false;
        }
    }
}
