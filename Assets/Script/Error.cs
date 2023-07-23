using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Error : MonoBehaviour
{
    public GameObject error_screen;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.localScale.x >= 1.0f)
        {
            timer += Time.deltaTime;
            gameObject.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            if (timer > 3.0f)
            {
                error_screen.SetActive(true);
                if (timer > 6.0f)
                    error_screen.SetActive(false);
            }
        }
        else
            gameObject.transform.localScale += new Vector3(0.02f, 0, 0);
    }
}
