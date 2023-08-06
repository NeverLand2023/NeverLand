using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAtSavePoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClickRestart()
    {
        //게임매니저 초기화

        PlayerPrefs.SetInt("ContinueKey", 0);
        PlayerPrefs.Save();
    }

    public void onClickContinue()
    {
        PlayerPrefs.SetInt("ContinueKey", 1);
        PlayerPrefs.Save();
    }

    public void onClickExit()
    {

    }
}
