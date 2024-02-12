using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class black_monster : MonoBehaviour
{
    public float hp = 1;
    public float speed = 1;
    public bool isRun;

    public Rigidbody2D player;

    SpriteRenderer spriter;
    Animator anim;
    Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();

        player = GameObject.Find("Main_Hook").GetComponent<Rigidbody2D>();
        isRun = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > player.transform.position.x)
        {
            spriter.flipX = true;
        }
        else
        {
            spriter.flipX = false;
        }


    }
    private void FixedUpdate()
    {
        //move
        if (isRun)
        {
            Vector2 dirVec = player.position - rigid.position;
            Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime;
            rigid.MovePosition(rigid.position + nextVec);
            rigid.velocity = Vector2.zero;
        }

    }

    public void StartRun()
    {
        isRun = true;
    }

    public void Dead()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerAttack")
        {
            rigid.constraints = RigidbodyConstraints2D.FreezeAll;
            anim.SetTrigger("hurt");
            hp -= 2;
            if (hp < 0)
            {
                gameObject.GetComponent<Collider2D>().isTrigger = true;
                anim.SetBool("isDeath", true);
            }
        }

        if(collision.gameObject.tag == "Player")
        {
            GameManager.DecreaseHP(10);
        }
    }
}
