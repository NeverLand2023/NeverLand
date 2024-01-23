using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class BossSkeleton : MonoBehaviour
{
    [Header("Preset Fields")]
    [SerializeField] private Animator animator;

    [Header("Settings")]
    [SerializeField] private float attackRange;
    [SerializeField] private float followRange;
    [SerializeField] private float moveSpeed;

    private static int BossHp = 200;

    public Transform target;
    public SpriteRenderer spriteRenderer;

    private bool facingRight = true;
    private bool isWalking = false;


    public enum State
    {
        None,
        Idle,
        Walk,
        Attack,
        Dead
    }

    public State state = State.None;
    public State nextState = State.None;

    private bool walkDone = false;
    private bool attackDone = false;
    private bool deadDone = false;

    // Start is called before the first frame update
    void Start()
    {
        state = State.None;
        nextState = State.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        if (BossHp <= 0)
        {
            animator.SetBool("idle", false);
            animator.SetBool("walk", false);
            animator.SetBool("attack", false);
            animator.SetBool("dead", true);
            nextState = State.Dead;
        }

        FlipIfNeeded(transform.position.x - target.position.x);

        if (nextState == State.None)
        {
            switch (state)
            {
                case State.Idle:
                    if (BossHp <= 0)
                    {
                        animator.SetBool("idle", false);
                        nextState = State.Dead;
                    }
                    else if (Physics2D.OverlapCircle(transform.position, followRange, 1 << 3))
                    {
                        animator.SetBool("idle", false);
                        nextState = State.Walk;
                    }
                    else if (Physics2D.OverlapCircle(transform.position, attackRange, 1 << 3))
                    {
                        animator.SetBool("idle", false);
                        nextState = State.Attack;
                    }
                    break;
                case State.Walk:
                    if (BossHp <= 0)
                    {
                        animator.SetBool("walk", false);
                        nextState = State.Dead;
                    }
                    else if (walkDone)
                    {
                        isWalking = false;
                        walkDone = false;
                        if (Physics2D.OverlapCircle(transform.position, attackRange, 1 << 3))
                        {

                            animator.SetBool("walk", false);
                            nextState = State.Attack;

                        }
                        else
                        {
                            animator.SetBool("walk", false);
                            nextState = State.Idle;
                        }                       

                    }
                    break;
                case State.Attack:
                    if (BossHp <= 0)
                    {
                        animator.SetBool("attack", false);
                        nextState = State.Dead;
                    }
                    else if (attackDone)
                    {
                        attackDone = false;
                        if (Physics2D.OverlapCircle(transform.position, followRange, 1 << 3))
                        {
                            animator.SetBool("attack", false);
                            nextState = State.Walk;
                        }
                        else
                        {
                            animator.SetBool("attack", false);
                            nextState = State.Idle;
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
                    Debug.Log("Idle");
                    animator.SetBool("idle", true);
                    break;

                case State.Walk:
                    Debug.Log("Walk");
                    isWalking = true;
                    Walk();
                    break;

                case State.Attack:
                    Debug.Log("Attack");
                    Attack();
                    break;

                case State.Dead:
                    Debug.Log("Dead");
                    Dead();
                    break;

            }
        }
    }
    private void Walk()
    {
        animator.SetBool("walk", true);
        StartCoroutine(FollowTarget());


    }
    private void WalkAnimationDone()
    {
        walkDone = true;
    }

        private void Attack()
    {
        animator.SetBool("attack", true);
    }
    private void AttackHit()
    {
        if (Physics2D.OverlapCircle(transform.position, attackRange, 1 << 3))
        {
            GameManager.DecreaseHP(10f);
        }
    }

    private void AttackAnimationDone()
    {
            attackDone = true; ;
      

    }

    private void Dead()
    {
        animator.SetBool("death", true);

    }
    private void DeadAnimationDone()
    {
        deadDone = true;
        Destroy(gameObject);
    }

    void FlipIfNeeded(float horizontalMovement)
    {
        if ((horizontalMovement > 0 && !facingRight) || (horizontalMovement < 0 && facingRight))
        {
            facingRight = !facingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1f, 0f, 0f, 0.5f);
        Gizmos.DrawSphere(transform.position, attackRange);

        Gizmos.color = new Color(85f, 211f, 241f, 0.3f);
        Gizmos.DrawSphere(transform.position, followRange);
    }
    public static float GetCurrentHP()
    {
        return BossHp;
    }

    public static void MinusHP()
    {
        BossHp -= 20;
    }

    IEnumerator FollowTarget()
    {
        while (isWalking)
        {
           
                float step = moveSpeed * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, target.position, step);
            

            yield return null;
        }
        yield return null;
    }



}
