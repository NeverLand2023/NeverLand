using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_slime : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator anim;
    SpriteRenderer spriteRenderer;

    public GameObject player;
    private bool isAttacking = false;

    public float distance;

    public int slimeHp = 100;


    // 행동을 결정하는데 사용할 변수 nextMove
    public int nextMove;
    public bool attack = false;
    //public bool damaged= false;


    // 몬스터 원래 좌표
    private Vector2 originalPosition;

    // 몬스터가 공격하는 거리
    //public float attackRange = 1f;

    // 플레이어와 충돌한 시간
    //private float lastAttackTime = -1f;


    // 공격 애니메이션 재생 시간
    //public float attackAnimationDuration = 1f;

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
        float distanceFromOriginal = Vector2.Distance(originalPosition, transform.position);

        float distance = Vector2.Distance(player.transform.position, transform.position);
        Debug.Log("거리값");

        anim.SetInteger("walkspeed", nextMove);

        /*      (distanceFromOriginal >= 3f)
          {

              nextMove = 2;
              spriteRenderer.flipX = false;
              Debug.Log("되돌아감");
          }*/

        if (distanceFromOriginal <= 3f)
        {

            if (distance < 3)
            {
                if (transform.position.x > player.transform.position.x)
                {
                    spriteRenderer.flipX = true;
                    Debug.Log("왼쪽 발견");
                    nextMove = -2;


                }
                else
                {
                    spriteRenderer.flipX = false;
                    Debug.Log("오른쪽 발견");
                    nextMove = 2;
                }
            }
            else
            {
                if (distanceFromOriginal <= 3f)
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
            }
        }
        else
        {
            nextMove = -nextMove;
            spriteRenderer.flipX = nextMove == -1;
            Debug.Log("되돌아감");
            rigid.velocity = new Vector2(nextMove, rigid.velocity.y);
        }
        //원좌표에서 좌우 5만큼만 이동
        


        // 플레이어와 충돌한 후 일정 시간이 지나면 공격 애니메이션 종료
        /*if (Time.time - lastAttackTime >= attackAnimationDuration)
        {
            anim.SetBool("attack", false);
        }*/
    }

    public void notFindPlayer()
    {
        nextMove = Random.Range(-1, 2); // -1, 0, 1 중에서 랜덤으로 값을 선택



        anim.SetInteger("walkspeed", nextMove);
        Debug.Log("걷는 애니메이션?");

        
        



        //슬라임이 보는 방향
        if(nextMove != 0)
        {
            spriteRenderer.flipX = nextMove == -1;

        }

        float nextmovetime = Random.Range(2f, 5f);
        Invoke("notFindPlayer", nextmovetime);


    }

    void Update()
    {
        if (isAttacking && !anim.GetCurrentAnimatorStateInfo(0).IsName("slime_attack"))
        {
            // attack 애니메이션이 종료되었을 때 제약을 해제
            
            isAttacking = false; // attack 애니메이션이 종료되었으므로 변수 초기화
        }
    }



    // 플레이어와 충돌했을 때 호출되는 함수

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && !isAttacking)
        {
            rigid.constraints = RigidbodyConstraints2D.FreezePositionX;
            Debug.Log("아야");
            isAttacking = true;
            nextMove = 0;
            if (transform.position.x > player.transform.position.x)
            {
                spriteRenderer.flipX = true;

            }
            else
            {
                spriteRenderer.flipX = false;
            }
            anim.SetBool("attack", true);


            AttackPlayer();


        }
        else if (collision.gameObject.tag == "PlayerAttack" && !isAttacking)
        {
            anim.SetTrigger("hurt");
            slimeHp -= 35;
            Debug.Log("slimeHp");
            Debug.Log(slimeHp);
            if (slimeHp <= 0)
            {
                anim.SetTrigger("die");
                Invoke("Die", anim.GetCurrentAnimatorStateInfo(0).length);
            }
                
        }

    }




    // 플레이어 공격 함수
    void AttackPlayer()
    {
        // 플레이어와 충돌한 시간 기록
        //lastAttackTime = Time.time;

        // 공격 애니메이션 실행

        
        Debug.Log("몬스터가 플레이어를 공격");

        Invoke("ResetAttackAnimation", anim.GetCurrentAnimatorStateInfo(0).length);



    }
    void ResetAttackAnimation()
    {

        rigid.constraints = RigidbodyConstraints2D.None;
        rigid.constraints = RigidbodyConstraints2D.FreezePositionY;

        anim.SetBool("attack", false);
        isAttacking = false; // attack 애니메이션이 종료되었으므로 변수 초기화
    }


    void Die()
    {

        Destroy(gameObject);
    }
}





