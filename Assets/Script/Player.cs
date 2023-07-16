using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
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
        //inputVec.y = Input.GetAxisRaw("Vertical");

        //�ִϸ��̼� ����
/*        if (inputVec.x > 0)         //������ �޸���
        {
            spriter.flipX = false;
            anim.SetBool("isRun", true);
            anim.SetBool("isRunLeft", false);
        }
        else if (inputVec.x < 0)    //���� �޸���
        {
            spriter.flipX = true;
            //anim.SetBool("isRun", false);
            //anim.SetBool("isRunLeft", true);
        }
        else                        //Idle
        {
            anim.SetBool("isRun", false);
            anim.SetBool("isRunLeft", false);
        }*/

        if(inputVec.x != 0)
        {
            spriter.flipX = inputVec.x < 0;
            anim.SetBool("isRun", true);
            anim.SetBool("isRunLeft", false);
        }
        else                        //Idle
        {
            anim.SetBool("isRun", false);
            anim.SetBool("isRunLeft", false);
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
