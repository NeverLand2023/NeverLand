using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bread_circle : MonoBehaviour
{
    public bool awake;
    public float timer;

    RectTransform rectTransform;


    private void OnEnable()
    {
        rectTransform = GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(-1.5f, 5);
        timer = 0;
        awake = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (awake)
        {
            timer += Time.deltaTime;
            rectTransform.anchoredPosition += new Vector2(0, -0.015f);
            if (timer > 2)
            {
                awake = false;
                timer = 0;
            }
        }
    }
}
