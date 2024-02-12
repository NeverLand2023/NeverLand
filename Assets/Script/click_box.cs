using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class click_box : MonoBehaviour
{

    public GameObject active_ui;
    public GameObject inactive_ui;
    public GameObject inactive_ui2;
    public GameObject active_gameobject;





    // Update is called once per frame
    public void OnYesButtonClick()
    {


        active_ui.SetActive(true);
        inactive_ui.SetActive(false);
        inactive_ui2.SetActive(false);
        active_gameobject.SetActive(true);

       

    }
}
