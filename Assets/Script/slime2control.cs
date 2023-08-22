using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slime2control : MonoBehaviour
{
    public GameObject player;

    Rigidbody2D rigid;

    SpriteRenderer spriteRenderer;

    private float distanceFromOriginal;
    private float distance = 0;
    //공격 후 대기 시간
    private float idleTime = 3f;
    //공격 상태 나타냄
    private bool isAttacking = false;

    public enum State
    {
        None,
        Idle,
        Run,
        Hurt,
        Attack,
        Dead
    }

    private Animator animator;


    public State state = State.None;
    public State nextState = State.None;
    public bool waiting = false;
    private bool attackDone = false;
    private bool deadDone = false;
    //슬라임 움직임 제어 변수
    public int nextMove;

    public float attackTime = 3f;
    private float countTime = 0;
    private float ran_runTime;

    //private float curTime = 0;

    private int SlimeHp = 100;
    private bool playerEnter = false;
    private Vector2 originalPosition;

    void Start()
    {
        state = State.None;
        nextState = State.Idle;
        

    }

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalPosition = transform.position;
        wait();

    }
    // Update is called once per frame

    void wait()
    {
        Debug.Log("방향 재설정");        
        nextMove = Random.Range(-1, 2);
    }

    
    
    void Update()
    {
        //슬라임 원래 위치

        float distance = Vector2.Distance(player.transform.position, transform.position);
        //Debug.Log(distance);

        checkdistancefromoriginal();
        


        if (nextState == State.None)
        {
            switch (state)
            {
                case State.Idle:
                    if (SlimeHp <= 0)
                    {
                        animator.SetBool("idle", false);
                        nextState = State.Dead;
                    }
                    /*else if (countTime >= attackTime)
                    {
                        animator.SetBool("idle", false);
                        nextState = State.Attack;
                    }*/

                    if (distance < 3 && !waiting)
                    {
                        Debug.Log("공격 대기");
                        nextState = State.Attack;
                        if (!isAttacking)  // Attack 애니메이션 재생 중이 아닐 때
                        {
                            StartCoroutine(AttackAndIdle());  // Attack 애니메이션 재생 및 Idle 상태 유지 시작
                        }
                    }

                  

                    

                    break;


                /*case State.Hurt:
                    // animator.SetBool("hurt", true);
                    animator.SetTrigger("hurt");
                    nextState = State.Idle;
                    

                    if (SlimeHp <= 0)
                    {
                       // animator.SetBool("hurt", false);
                        nextState = State.Dead;
                    }
   
                break;*/

                case State.Attack:
                    if (SlimeHp <= 0)
                    {
                        animator.SetBool("attack", false);
                        
                        nextState = State.Dead;
                        attackDone = false;
                    }

                    

                    else if (SlimeHp >= 0)
                    {
                        if (attackDone)
                        {
                            animator.SetBool("attack", false);
                            Debug.Log("attack false");
                            nextState = State.Idle;
                            attackDone = false;
                        }

                    }
                    break;
                case State.Dead:
                    if (deadDone)
                    {
                        Destroy(gameObject);
                    }
                    break;
            }
        }

        if (nextState != State.None)
        {
            state = nextState;
            nextState = State.None;
            switch (state)
            {
                case State.Idle:
                    Idle();
                    break;

                case State.Attack:
                    Attack();
                    break;

                case State.Dead:
                    Dead();
                    break;

                

            }
        }

       if (playerEnter && Input.GetMouseButtonDown(0))
            {
            
                Debug.Log("35 깎임");
                SlimeHp -= 35;
 
            
        }


    }

   /* private void FixedUpdate()
    {
        if (playerEnter)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("35 깎임");
                SlimeHp -= 35;
                nextState = State.Hurt;
            }
        }
    }*/

    private void checkdistancefromoriginal()
    {
        
        float distanceFromOriginal = Vector2.Distance(originalPosition, transform.position);
   
        if (distanceFromOriginal <= 2f)
        {

            rigid.velocity = new Vector2(nextMove, rigid.velocity.y);




        }

        else
        {
            float moveDirection = Mathf.Sign(originalPosition.x - transform.position.x);
            nextMove = (int)moveDirection;

            spriteRenderer.flipX = moveDirection == -1;

            rigid.velocity = new Vector2(nextMove, rigid.velocity.y);

        }
    }

    private void Idle()
    {
        countTime = 0;
        Debug.Log("Idle");
        animator.SetInteger("run", nextMove);


       
        

       /* if (distance < 2)
        {
            Debug.Log("가까움");
            animator.SetBool("attack", true);
            rigid.constraints = RigidbodyConstraints2D.FreezePositionX;
            Attack();



            countTime += Time.deltaTime;

        }*/



        ran_runTime = Random.Range(1, 4);

            animator.SetInteger("run", nextMove);
            //슬라임이 보는 방향
            if (nextMove != 0)
            {
                spriteRenderer.flipX = nextMove == -1;

            }

            float nextmovetime = Random.Range(2f, 5f);
            countTime += Time.deltaTime;

            if (countTime >= ran_runTime)
            {
                wait();

            }


        
    }

    private void hit()
    {
        if (playerEnter)
        {
            //GameManager.DecreaseHP(10);
            Debug.Log("해치웟나");
        }

    }

   private void Hurt()
    {

        //animator.SetTrigger("hurt0");
        nextState = State.Idle;
    }

    private void Attack()
    {
        animator.SetBool("attack", true);

        SoundManager.instance.slimeattacksound.Play();
        
        if (player.transform.position.x < transform.position.x)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }


        countTime += Time.deltaTime;

    }

    public void AttackAnimationEnd()
    {
        attackDone = true;
        Debug.Log("AttackDone");
        animator.SetBool("attack", false);
       
        nextState = State.Idle;
    }


    private void Dead()
    {
        animator.SetBool("dead", true);
    }

    public void DeadAnimationEnd()
    {
        deadDone = true;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            
            playerEnter = true;
            rigid.constraints = RigidbodyConstraints2D.FreezeAll;
            nextState = State.Attack;

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {

            playerEnter = false;
            rigid.constraints = ~RigidbodyConstraints2D.FreezePositionX;
        }
    }

    private IEnumerator AttackAndIdle()
    {
        isAttacking = true;  // Attack 애니메이션 재생 중 표시

        // Attack 애니메이션 재생
        animator.SetBool("attack", true);
        waiting = true;

        Attack();

        yield return new WaitForSeconds(attackTime);  // attackTime 동안 대기

        // Attack 애니메이션 종료
        animator.SetBool("attack", false);
        
        AttackAnimationEnd();

        yield return new WaitForSeconds(idleTime);  // idleTime 동안 대기

        waiting = false;

        isAttacking = false;  // Attack 애니메이션 재생 종료 표시
    }
}
