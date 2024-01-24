using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class steering_gear : MonoBehaviour
{
    public GameObject steeringgear;
    public GameObject background_black;
    public bool issteeringActive = false;

    private int open = 0;
    // Start is called before the first frame update
    void Start()
    {
        steeringgear.SetActive(false);
        background_black.SetActive(false);
    }
    void Update()
    {
   
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (issteeringActive)
                {

                    issteeringActive = false;
                    //충돌 & 스페이스바 감지시 ui 활성화
                    background_black.SetActive(true);
                    steeringgear.SetActive(true);

                  
                   
                }

               /* else
                {
                    background_black.SetActive(false);
                   steeringgear.SetActive(false);
                }*/
            }


           
        }

    


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Player"))

        {


            issteeringActive = true;

        }
        else
        {
            issteeringActive = false;
        }

    }


    
}
