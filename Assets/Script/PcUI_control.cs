using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PcUI_control : MonoBehaviour
{


    public GameObject PC_UI1;
    public GameObject PC_UI2;
    public GameObject RedLight;

    public GameObject minimapline;
    public Camera minimapcam;
    public Camera minimapcam2;

    private bool UI1Active = false;
    private bool UI2Active = false;
    private bool letsgoBoss = false;


    
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

            if (UInum == 2)
            {
                letsgoBoss = false;
                UI1Active = false;
                UI2Active = false;
            }

            if (UInum == 4)
            {

                letsgoBoss = true;
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
                if(UInum == 3)
                {
                    UInum = 4;
                }
                if (!letsgoBoss && !UI1Active && !UI2Active)
                {
                    minimapline.SetActive(true);
                    minimapcam.enabled = true;
                    minimapcam2.enabled = true;
                }

                if (UI1Active)
                {
                    minimapline.SetActive(false);
                    minimapcam.enabled = false;
                    minimapcam2.enabled = false;
                    PC_UI1.SetActive(true);
                    Main_Hook.attackAvailable = false;
                    Debug.Log("1충돌 감지");
                    UI1Active = false;
                }
                if (UI2Active)
                {
                    minimapline.SetActive(false);
                    minimapcam.enabled = false;
                    minimapcam2.enabled = false;
                    PC_UI2.SetActive(true);
                    PC_UI1.SetActive(false);
                    Main_Hook.attackAvailable = false;
                    Debug.Log("2충돌 감지");
                    UI2Active = false;
                }

                

                if (letsgoBoss)
                {
                    RedLight.SetActive(true);
                    StartCoroutine(LoadNextSceneAfterDelay(2f));
                    minimapline.SetActive(true);
                    minimapcam.enabled = true;
                    minimapcam2.enabled = true;
                }

                

               



            }
           

        }


    }

    private IEnumerator LoadNextSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        SceneManager.LoadScene("Boss_wh"); 
    }

}
