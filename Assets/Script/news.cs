using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class news : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("sceneChange", 4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void sceneChange() 
    {
        SceneManager.LoadScene("home");
    }
}
