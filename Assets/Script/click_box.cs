using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class click_box : MonoBehaviour
{

    private AudioSource audioSource;
    public AudioClip clickbox;

    public GameObject active_ui;
    public GameObject inactive_ui;
    public GameObject inactive_ui2;
    public GameObject inactive_PWui;
    public GameObject active_gameobject;
    public GameObject UInumChange;
  //  public GameObject active_openSound;


    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();  // AudioSource 동적 추가
        audioSource.clip = clickbox;
        
    }


    // Update is called once per frame
    public void OnYesButtonClick()
    {

        audioSource.Play();

        active_ui.SetActive(true);
        inactive_ui.SetActive(false);
        inactive_ui2.SetActive(false);
        inactive_PWui.SetActive(false);
        active_gameobject.SetActive(true);
        UInumChange.SetActive(true);
    //    active_openSound.SetActive(true);


       

    }

    public void OnNobuttonClick()
    {
        //hp 100 감소
        //GameManager.DecreaseHP(100f);
    }
}
