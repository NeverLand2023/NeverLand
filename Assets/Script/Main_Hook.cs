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
        //캐릭터 움직임
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");

        //움직임 애니메이션 구현
        if (inputVec.x > 0)         //오른쪽 달리기
        {
            anim.SetBool("isRun", true);
            anim.SetBool("isRunLeft", false);
        }
        else if (inputVec.x < 0)    //왼쪽 달리기
        {
            anim.SetBool("isRun", true);
            anim.SetBool("isRunLeft", true);
        }
        else if (inputVec.y != 0)   //위아래로 달리기
        {
            anim.SetBool("isRun", true);
        }
        else                        //Idle
        {
            anim.SetBool("isRun", false);
            //anim.SetBool("isRunLeft", false);
        }

        //공격
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Attack");
        }

    }

    void FixedUpdate()
    {
        //캐릭터 움직임
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
