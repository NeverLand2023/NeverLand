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

        //움직임 애니메이션 구현
        if(inputVec.x != 0)
        {
            spriter.flipX = inputVec.x < 0;
            anim.SetBool("isRun", true);
        }
        else if(inputVec.y != 0)
        {
            anim.SetBool("isRun", true);
        }
        else
        {
            anim.SetBool("isRun", false);
        }

        //공격
        if (Input.GetMouseButtonDown(0))
        {
            inputVec.x = 0;
            anim.SetTrigger("Attack");
        }

    }

    void FixedUpdate()
    {
        //캐릭터 움직임
        if (rigid.position.x >= 100)
        {
            rigid.position = new Vector2(100, transform.position.y);

        }
        else if (rigid.position.x <= -100)
        {
            rigid.position = new Vector2(-100, transform.position.y);
        }

        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            GameManager.DecreaseHP(10f);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("main_hook_Attack"))
        {

        }
    }
}
