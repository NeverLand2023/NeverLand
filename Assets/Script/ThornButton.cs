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

        // ���⿡�� ���� ������ ��ο� ������ �����մϴ�.
        currentColor.r *= 0.7f; // ���� ä���� ��Ӱ�
        currentColor.g *= 0.7f; // ��� ä���� ��Ӱ�
        currentColor.b *= 0.7f; // �Ķ� ä���� ��Ӱ�

        spriteRenderer.color = currentColor;
    }

    void SetNormalColor()
    {
        
        spriteRenderer.color = Color.white;
    }

   

}
