using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Vector2 startPos;
    public ThornActive thornCs;

    void Start()
    {
        startPos = GetComponent<Transform>().position;
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (thornCs.reset)
        {
            this.GetComponent<Transform>().position = startPos;
            thornCs.resetObj++;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        // �浹�� ������Ʈ�� �÷��̾��� ���
        if (collision.gameObject.CompareTag("Player"))
        {
            rb2d.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // �÷��̾���� �浹�� ���� ���
        if (collision.gameObject.CompareTag("Player"))
        {
            // �÷��̾�� �浹�� ������ �ӵ��� 0���� ����ϴ�.
            rb2d.velocity = Vector2.zero;

            rb2d.bodyType = RigidbodyType2D.Kinematic;
        }
    }
}
