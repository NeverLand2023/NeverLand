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

            SetAlpha(0.4f);
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

            SetAlpha(1);
        }


    }

    void SetAlpha(float alphaValue)
    {
        Color currentColor = spriteRenderer.color;

        currentColor.a = alphaValue;

        spriteRenderer.color = currentColor;
    }

}
