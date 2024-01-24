using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class letter : MonoBehaviour
{

    public GameObject letterUI;
    public bool isletterActive = false;



    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Player"))

        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (isletterActive == false)
                {
                    letterUI.SetActive(true);
                    isletterActive = true;

                }

                else
                {
                    isletterActive = false;
                    letterUI.SetActive(false);


                }
            }



        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        letterUI.SetActive(false);
    }

    void Update()
    {
 

        
    }
}
