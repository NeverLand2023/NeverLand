using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Hook : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed;
    public float maxHealth;
    public float health;

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
        inputVec.y = Input.GetAxisRaw("Vertical");

        //������ �ִϸ��̼� ����
        if (inputVec.x > 0)         //������ �޸���
        {
            anim.SetBool("isRun", true);
            anim.SetBool("isRunLeft", false);
        }
        else if (inputVec.x < 0)    //���� �޸���
        {
            anim.SetBool("isRun", true);
            anim.SetBool("isRunLeft", true);
        }
        else if (inputVec.y != 0)   //���Ʒ��� �޸���
        {
            anim.SetBool("isRun", true);
        }
        else                        //Idle
        {
            anim.SetBool("isRun", false);
            //anim.SetBool("isRunLeft", false);
        }

        //����
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Attack");
        }

    }

    void FixedUpdate()
    {
        //ĳ���� ������
        if (rigid.position.x >= 50)
        {
            rigid.position = new Vector2(50, transform.position.y);

        }
        else if (rigid.position.x <= -50)
        {
            rigid.position = new Vector2(-50, transform.position.y);
        }

        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);

    }
}
