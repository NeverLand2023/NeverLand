using UnityEngine;

public class SwitchCollider : MonoBehaviour
{
    public GameObject switchCanvas; // Ȱ��ȭ�� SwitchCanvas ����
    private bool collisionState = false;
    public bool UIopen = true;

    

    void Update()
    {
        if (collisionState)
        {
            // Ư�� SwitchCanvas�� Ȱ��ȭ

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    if (switchCanvas != null)
                    {
                    
                    

                        Debug.Log("�浹 ����");
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
        if (collision.gameObject.CompareTag("Player")) // �浹�� ������Ʈ�� "Player" �±����� Ȯ��
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