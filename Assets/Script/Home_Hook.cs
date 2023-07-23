using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home_Hook : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed;

    Rigidbody2D rigid;
    SpriteRenderer spriter;
    Animator anim;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //ĳ���� ������
        inputVec.x = Input.GetAxisRaw("Horizontal");
        if (inputVec.x != 0)
        {
            spriter.flipX = inputVec.x < 0;
            anim.SetBool("isWalk", true);
        }
        else                        //Idle
        {
            anim.SetBool("isWalk", false);
        }
    }

    void FixedUpdate()
    {
        //ĳ���� ������
        if (rigid.position.x >= 9)
        {
            rigid.position = new Vector2(9, transform.position.y);

        }
        else if (rigid.position.x <= -9)
        {
            rigid.position = new Vector2(-9, transform.position.y);
        }

        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);

    }
}
