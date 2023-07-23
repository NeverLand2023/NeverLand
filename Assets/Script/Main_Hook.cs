using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Hook : MonoBehaviour
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
        //캐릭터 움직임
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");

        //애니메이션 구현
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

    }

    void FixedUpdate()
    {
        //캐릭터 움직임
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
