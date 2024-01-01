using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
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
