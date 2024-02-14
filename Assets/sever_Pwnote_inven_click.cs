using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class sever_Pwnote_inven_click : MonoBehaviour
{
    public GameObject PW_NOTE_openUI;

    void Start()
    {

        if (PW_NOTE_openUI != null)
        {
            PW_NOTE_openUI.SetActive(false);
        }
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.I))
        {

            PW_NOTE_openUI.SetActive(false);

        }
    }

    public void OnClick()
    {
            PW_NOTE_openUI.SetActive(true);

    }

}
