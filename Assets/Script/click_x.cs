using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class click_x : MonoBehaviour
{
    public GameObject uiObject; // ������� �ϴ� UI ������Ʈ

    public AudioClip clickXbox;


    public GameObject minimapline;
    public Camera minimapcam;
    public Camera minimapcam2;

    void Start()
    {

        
        
    }

    public void OnXButtonClick()
    {
        // ��ư�� Ŭ���Ǿ��� �� ����Ǵ� �Լ�


        Debug.Log("UI�� ��Ȱ��ȭ�մϴ�.");

             AudioSource.PlayClipAtPoint(clickXbox, Camera.main.transform.position);

            

            minimapline.SetActive(true);
            Main_Hook.attackAvailable = true;
        Debug.Log("���� ��������");
            minimapcam.enabled = true;
            minimapcam2.enabled = true;
            uiObject.SetActive(false);

    }

}


