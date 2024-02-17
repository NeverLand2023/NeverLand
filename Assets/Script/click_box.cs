using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class click_box : MonoBehaviour
{


    public AudioClip clickbox;

    public GameObject active_ui;
    public GameObject inactive_ui;
    public GameObject inactive_ui2;
    public GameObject inactive_PWui;
    public GameObject active_gameobject;
    public GameObject UInumChange;

    public GameObject minimapline;
    public Camera minimapcam;
    public Camera minimapcam2;

    //  public GameObject active_openSound;


    private void Start()
    {
      
        
    }


    // Update is called once per frame
    public void OnYesButtonClick()
    {
        AudioSource.PlayClipAtPoint(clickbox, Camera.main.transform.position);


        active_ui.SetActive(true);
        inactive_ui.SetActive(false);
        inactive_ui2.SetActive(false);
        inactive_PWui.SetActive(false);
        active_gameobject.SetActive(true);
        UInumChange.SetActive(true);
        minimapline.SetActive(true);
        minimapcam.enabled = true;
        minimapcam2.enabled = true;
        //    active_openSound.SetActive(true);




    }

    public void ConfirmClick()
    {
        Main_Hook.attackAvailable = true;
    }

    public void OnNobuttonClick()
    {
        //hp 100 °¨¼Ò
        //GameManager.DecreaseHP(100f);
    }
}
