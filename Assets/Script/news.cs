using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class news : MonoBehaviour
{
    public GameObject news1;
    public GameObject news2;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("EnableNews2", 4.5f);
        Invoke("sceneChange", 9);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void sceneChange() 
    {
        SceneManager.LoadScene("home");
    }
    private void EnableNews2()
    {
        news1.SetActive(false);
        news2.SetActive(true);
    }
}
