using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class click_x : MonoBehaviour
{
    public GameObject uiObject; // 숨기고자 하는 UI 오브젝트

    public AudioClip clickXbox;


    public GameObject minimapline;
    public Camera minimapcam;
    public Camera minimapcam2;

    void Start()
    {

        
        
    }

    public void OnXButtonClick()
    {
        // 버튼이 클릭되었을 때 실행되는 함수


        Debug.Log("UI를 비활성화합니다.");

             AudioSource.PlayClipAtPoint(clickXbox, Camera.main.transform.position);

            

            minimapline.SetActive(true);
            Main_Hook.attackAvailable = true;
        Debug.Log("여기 들어오나요");
            minimapcam.enabled = true;
            minimapcam2.enabled = true;
            uiObject.SetActive(false);

    }

}


