using UnityEngine;

public class SwitchCollider : MonoBehaviour
{
    public GameObject switchCanvas; // 활성화할 SwitchCanvas 참조
    private bool collisionState = false;
    public bool UIopen = true;

    

    void Update()
    {
        if (collisionState)
        {
            // 특정 SwitchCanvas를 활성화

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    if (switchCanvas != null)
                    {
                    
                    

                        Debug.Log("충돌 감지");
                        //collisionBOOK = false;


                        if (UIopen)
                        {
                            UIopen = false;
                            Main_Hook.attackAvailable = false;
                            switchCanvas.SetActive(true);
                        }
                        else
                        {
                            switchCanvas.SetActive(false);
                            Main_Hook.attackAvailable = true;

                            Debug.Log("close");
                            UIopen = true;
                        }


                    }


                }


            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.W))
            {
                switchCanvas.SetActive(false);
                Main_Hook.attackAvailable = true;
            }


            
            
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // 충돌한 오브젝트가 "Player" 태그인지 확인
        {
            collisionState = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collisionState = false;

            //Main_Hook.attackAvailable = true;
        }
    }
}