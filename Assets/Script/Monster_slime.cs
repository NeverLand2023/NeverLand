using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_slime : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator anim;
    SpriteRenderer spriteRenderer;


    // 행동을 결정하는데 사용할 변수 nextMove
    public int nextMove;
    public bool attack = false;
    //public bool damaged= false;


    // 몬스터 원래 좌표
    private Vector3 originalPosition;

    // 몬스터가 공격하는 거리
    public float attackRange = 1f;

    // 플레이어와 충돌한 시간
    private float lastAttackTime = -1f;


    // 공격 애니메이션 재생 시간
    public float attackAnimationDuration = 1f;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
 
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        notFindPlayer();

        // 몬스터의 원래 좌표 저장
        originalPosition = transform.position;
    }

    void FixedUpdate()
    {
        // 몬스터의 원래 좌표와 현재 좌표 사이의 거리를 계산
        float distanceFromOriginal = Vector3.Distance(originalPosition, transform.position);

        //원좌표에서 좌우 5만큼만 이동
        if (distanceFromOriginal <= 2f)
        {
            rigid.velocity = new Vector2(nextMove, rigid.velocity.y);
        }
        else
        {
            // 거리가 5를 넘으면 반대 방향으로 이동
            nextMove = -nextMove;


            if (nextMove == -1)
            {
                Debug.Log("오른쪽->왼쪽");
                spriteRenderer.flipX = nextMove == -1;


            }
            else
            {
                Debug.Log("왼쪽->오른쪽");
                spriteRenderer.flipX = nextMove == -1;

            }

            rigid.velocity = new Vector2(nextMove, rigid.velocity.y);
            
        }

        // 플레이어와 충돌한 후 일정 시간이 지나면 공격 애니메이션 종료
        if (Time.time - lastAttackTime >= attackAnimationDuration)
        {
            anim.SetBool("attack", false);
        }
    }

    void notFindPlayer()
    {
        nextMove = Random.Range(-1, 2); // -1, 0, 1 중에서 랜덤으로 값을 선택



        anim.SetInteger("walkspeed", nextMove);


        //슬라임이 보는 방향
        if(nextMove != 0)
        {
            spriteRenderer.flipX = nextMove == -1;

        }

        float nextmovetime = Random.Range(2f, 5f);
        Invoke("notFindPlayer", nextmovetime);


    }


    // 플레이어와 충돌했을 때 호출되는 함수

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("충돌");

            AttackPlayer();

        }
    }


    // 플레이어 공격 함수
    void AttackPlayer()
    {
        // 플레이어와 충돌한 시간 기록
        lastAttackTime = Time.time;

        // 공격 애니메이션 실행
        anim.SetBool("attack", true);

        Debug.Log("몬스터가 플레이어를 공격");



    }






}