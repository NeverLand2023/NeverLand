using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bread_circle : MonoBehaviour
{
    public bool awake;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        awake = true;
        timer = 0;
    }
    private void Awake()
    {
        awake = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (awake)
        {
            timer += Time.deltaTime;
            RectTransform rectTransform = GetComponent<RectTransform>();
            rectTransform.anchoredPosition += new Vector2(0, -0.015f);
            if (timer > 2)
            {
                awake = false;
            }
        }
    }
}
