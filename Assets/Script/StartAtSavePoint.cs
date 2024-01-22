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
        GameManager.ResetHP();

        SceneManager.LoadScene("news");
    }

    public void onClickContinue()
    {
        GameManager.ContinueKey = true;
        GameManager.ResetHP();

        int missionNumber = PlayerPrefs.GetInt("MissionNunber", 1);
        //�̼� �Ѿ������ PlayerPrefs.SetInt("MissionNunber", <�̼ǹ�ȣ>);   <-�߰����ּ���

        //SceneManager.LoadScene("Mission"+ missionNumber.ToString());
        SceneManager.LoadScene("WH_mission1");
    }

    public void onClickExit()
    {
        Application.Quit();
    }
}
