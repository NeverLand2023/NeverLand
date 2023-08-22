using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


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
        GameManager.RestartKey = true;
        GameManager.EatHealItem();

        SceneManager.LoadScene("Mission1");
    }

    public void onClickContinue()
    {
        GameManager.ContinueKey = true;
        GameManager.EatHealItem();

        int missionNumber = PlayerPrefs.GetInt("MissionNunber", 1);
        //미션 넘어갈때마다 PlayerPrefs.SetInt("MissionNunber", <미션번호>);   <-추가해주세요

        SceneManager.LoadScene("Mission"+ missionNumber.ToString());
    }

    public void onClickExit()
    {
        Application.Quit();
    }
}
