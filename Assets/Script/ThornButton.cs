using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornButton : MonoBehaviour
{
    public ThornActive thornCs;
    private bool pushed = false;

    private SpriteRenderer spriteRenderer;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player"&&!pushed)
        {
            thornCs.actButt++;
            pushed = true;

            SetDarkColor();
        }
    }

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (thornCs.thorn&&pushed)
        {
            pushed = false;

            SetNormalColor();
        }


    }

    void SetDarkColor()
    {
        Color currentColor = spriteRenderer.color;

        // 여기에서 현재 색상을 어두운 색으로 조절합니다.
        currentColor.r *= 0.7f; // 빨강 채널을 어둡게
        currentColor.g *= 0.7f; // 녹색 채널을 어둡게
        currentColor.b *= 0.7f; // 파랑 채널을 어둡게

        spriteRenderer.color = currentColor;
    }

    void SetNormalColor()
    {
        
        spriteRenderer.color = Color.white;
    }

   

}
