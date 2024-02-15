using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class end_news : MonoBehaviour
{
    public GameObject news1;
    public GameObject news2;
    public GameObject news3;
    public GameObject news4;
    public GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("EnableNews2", 4.5f);
        Invoke("EnableNews3", 9f);
        Invoke("EnableNews4", 13.5f);
        Invoke("DisableCaption4", 18f);
    }

    // Update is called once per frame
    void Update()
    {

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
    }

    private void DisableCaption4() 
    {
        news4.SetActive(false);
        panel.SetActive(false);
    }
}
