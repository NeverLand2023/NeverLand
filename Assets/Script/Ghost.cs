using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public Rigidbody2D player;
    public float distance;
    public float speed;

    SpriteRenderer spriter;
    Animator anim;
    Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //플레이어랑 거리 계산
        distance = Vector2.Distance(transform.position, player.transform.position);
        anim.SetFloat("Pdistance", distance);
        if (transform.position.x > player.transform.position.x)
        {
            spriter.flipX = true;
        }
        else
        {
            spriter.flipX = false;
        }

        if(distance < 2)
        {
            anim.SetTrigger("attack");
        }
    }
    private void FixedUpdate()
    {
        Vector2 dirVec = player.position - rigid.position;
        Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
        rigid.velocity = Vector2.zero;
    }

}
