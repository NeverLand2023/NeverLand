
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
    private bool playerEnter = false;


    // 행동을 결정하는데 사용할 변수 nextMove
    public int nextMove;
    public bool attack = false;
    
 
    
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

   /* private void Update()
    {
        if (distance < 2)
        {
            anim.SetBool("attack", true);
            AttackPlayer();

        }
    }*/

    void FixedUpdate()
    {
        // 몬스터의 원래 좌표와 현재 좌표 사이의 거리를 계산
        float distanceFromOriginal = Vector2.Distance(originalPosition, transform.position);

        float distance = Vector2.Distance(player.transform.position, transform.position);

        if (distance < 2)
        {
            anim.SetBool("attack", true);
            //rigid.constraints = RigidbodyConstraints2D.FreezePositionX;
            if (!isAttacking)
            {
                SoundManager.instance.slimeattacksound.Play();
            }
            AttackPlayer();

        }

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
                   
                    nextMove = -2;


                }
                else
                {
                    spriteRenderer.flipX = false;
                    
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
                        
                        spriteRenderer.flipX = nextMove == -1;


                    }
                    else
                    {
                        
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
            
            rigid.velocity = new Vector2(nextMove, rigid.velocity.y);
        }
      
    }

    public void notFindPlayer()
    {
        nextMove = Random.Range(-1, 2); // -1, 0, 1 중에서 랜덤으로 값을 선택



        anim.SetInteger("walkspeed", nextMove);


        //슬라임이 보는 방향
        if (nextMove != 0)
        {
            spriteRenderer.flipX = nextMove == -1;

        }

        float nextmovetime = Random.Range(2f, 5f);
        Invoke("notFindPlayer", nextmovetime);


    }

    private IEnumerator DeathCoroutine()
    {
        SoundManager.instance.slimediesound.Play();
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
        gameObject.SetActive(false);
    }

    void Update()
    {
        

        if (playerEnter)
        {
            if (Input.GetMouseButtonDown(0))
            {
                anim.SetBool("attack", false);
                
                slimeHp -= 35;
                anim.SetTrigger("hurt");


            }
        }

        //슬라임 죽음
        if (slimeHp <= 0)
        {
            anim.SetBool("die", true);
            StartCoroutine(DeathCoroutine());
        }
    }

    void wait()
    {

    }
    // 플레이어와 충돌했을 때 호출되는 함수

    void OnCollisionEnter2D(Collision2D collision)

    {
        if (collision.gameObject.tag == ("Player"))
        {
            playerEnter = true;
            rigid.constraints = RigidbodyConstraints2D.FreezeAll;
        }


        /* rigid.constraints = RigidbodyConstraints2D.FreezePositionX;
         if (collision.gameObject.tag == "Player" && !isAttacking)
         {

             rigid.constraints = RigidbodyConstraints2D.FreezePositionX;

             isAttacking = true;

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


         }*/
        /*else if (collision.gameObject.tag == "PlayerAttack" && !isAttacking)
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

        }*/

    }


    void OnCollisionExit2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == ("Player"))
        {
            playerEnter = false;
            isAttacking = false;
            rigid.constraints = ~RigidbodyConstraints2D.FreezePositionX;
            //rigid.constraints &= ~RigidbodyConstraints2D.FreezePositionX;
        }
    }



    // 플레이어 공격 함수
    void AttackPlayer()
    {
       


        Debug.Log("몬스터가 플레이어를 공격");
        
        
        Invoke("ResetAttackAnimation", anim.GetCurrentAnimatorStateInfo(0).length);
        //StartCoroutine(CheckCollisionWhileAttacking());




    }

    IEnumerator CheckCollisionWhileAttacking()
    {
        //3초 대기
        yield return new WaitForSeconds(3);

        // 공격 애니메이션이 끝난 후에 플레이어와 충돌 중인지 확인
        if (isAttacking && player != null)
        {
            // 플레이어와 충돌한 상태를 다시 확인하고 필요한 처리를 수행
            OnCollisionEnter2D(new Collision2D()); // Collision2D에 실제 충돌 정보를 전달해야 함
        }
    }
    void ResetAttackAnimation()
    {

        // x축 고정 해제
        rigid.constraints &= ~RigidbodyConstraints2D.FreezePositionX;

        anim.SetBool("attack", false);

        isAttacking = false; // attack 애니메이션이 종료되었으므로 변수 초기화
    }


    void Die()
    {

        Destroy(gameObject);
    }
}





