using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class click_item : MonoBehaviour
{

    public GameObject OpneItemUI;
    // Start is called before the first frame update
   public void ItemButtonClick()
    {
        OpneItemUI.SetActive(true);
    }


    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OpneItemUI.SetActive(false);

        }
    }
}
