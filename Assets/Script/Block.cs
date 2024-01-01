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
        // 충돌한 오브젝트가 플레이어인 경우
        if (collision.gameObject.CompareTag("Player"))
        {
            rb2d.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // 플레이어와의 충돌이 끝난 경우
        if (collision.gameObject.CompareTag("Player"))
        {
            // 플레이어와 충돌이 끝나면 속도를 0으로 만듭니다.
            rb2d.velocity = Vector2.zero;

            rb2d.bodyType = RigidbodyType2D.Kinematic;
        }
    }
}
