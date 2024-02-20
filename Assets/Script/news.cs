using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class news : MonoBehaviour
{
    public GameObject news1;
    public GameObject news2;
    public GameObject news3;
    public GameObject news4;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("EnableNews2", 4.5f);
        Invoke("EnableNews3", 9f);
        Invoke("EnableNews4", 13.5f);
        Invoke("sceneChange", 18f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void sceneChange() 
    {
        SceneManager.LoadScene("Mission3");
    }
    private void EnableNews2()
    {
        news1.SetActive(false);
        news2.SetActive(true);
        Invoke("EnableNews3", 4.5f);
    }
    private void EnableNews3() 
    {
        news2.SetActive(false);
        news3.SetActive(true);
        Invoke("EnableNews4", 4.5f);
        
    }
    private void EnableNews4() 
    {
        news3.SetActive(false);
        news4.SetActive(true);
        Invoke("sceneChange", 4.5f);
    }
}
