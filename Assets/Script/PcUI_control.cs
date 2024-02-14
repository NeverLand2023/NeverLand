using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PcUI_control : MonoBehaviour
{


    public GameObject PC_UI1;
    public GameObject PC_UI2;
    public GameObject RedLight;

    private bool UI1Active = false;
    private bool UI2Active = false;


    
    public int UInum = 0;

    // Start is called before the first frame update


    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Player"))

        {
            if (UInum == 0){
                UI1Active = true;
            }
            
            if (UInum == 1){
                UI2Active = true;
            }
            

        }




    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Player"))  
        {
            UI1Active = false;
            UI2Active = false;

        }
    }
    // Update is called once per frame
    void Update()
    {
        if (UInum == 2)
        {
            UI1Active = false;
            UI2Active = false;
        }
       

        if (Input.anyKeyDown)
        {


            if (Input.GetKeyDown(KeyCode.Space))
            {

                if (UI1Active)
                {
                    PC_UI1.SetActive(true);
                    Debug.Log("1충돌 감지");
                    UI1Active = false;
                }
                if (UI2Active)
                {
                    PC_UI2.SetActive(true);
                    Debug.Log("2충돌 감지");
                    UI2Active = false;
                }

                if (UInum == 3)
                {
                    RedLight.SetActive(true);
                    //보스전으로 넘어가는 연출
                }



            }

        }


    }

}
