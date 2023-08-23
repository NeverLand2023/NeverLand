using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class SlimeSlime : MonoBehaviour
{
    [Header("Preset Fields")]
    [SerializeField] private Animator animator;

    [Header("Settings")]
    [SerializeField] private float attackRange;
    [SerializeField] private float followRange;
    [SerializeField] private float moveSpeed;

    private int slimeHp = 100;

    public Transform target;
    public SpriteRenderer spriteRenderer;


    public enum State
    {
        None,
        Idle,
        Run,
        Hurt,
        Attack,
        Dead
    }

    public State state = State.None;
    public State nextState = State.None;


    private bool attackDone = false;
    private bool hurtDone = false;
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
        if (nextState == State.None)
        {
            switch (state)
            {
                case State.Idle:
                    if (Physics2D.OverlapCircle(transform.position, attackRange, 1 << 3) && (Input.GetMouseButtonDown(0))) {
                        animator.SetBool("idle", false);
                        nextState = State.Hurt;
                    }
                    else if (Physics2D.OverlapCircle(transform.position, followRange, 1 << 3))
                    {
                        animator.SetBool("idle", false);
                        nextState = State.Run;
                    }
                    else if (Physics2D.OverlapCircle(transform.position, attackRange, 1 << 3))
                    {
                        animator.SetBool("idle", false);
                        nextState = State.Attack;
                    }
                    break;
                case State.Run:
                    if (Physics2D.OverlapCircle(transform.position, attackRange, 1 << 3) && (Input.GetMouseButtonDown(0))) {
                        animator.SetBool("run", false);
                        nextState = State.Hurt;
                    }
                    else if (Physics2D.OverlapCircle(transform.position, attackRange, 1 << 3))
                    {
                        bool isTargetOnLeft = target.position.x < transform.position.x;

                        
                        animator.SetBool("run", false);
                        nextState = State.Attack;

                        
                        if (isTargetOnLeft)
                        {
                            spriteRenderer.flipX = true;
                        }
                        else
                        {
                            spriteRenderer.flipX = false;
                        }
                    }
                    else if (!Physics2D.OverlapCircle(transform.position, followRange, 1 << 3))
                    {
                        animator.SetBool("run", false);
                        nextState = State.Idle;
                    }
                    else
                    {
                        nextState = State.Run;
                    }
                    break;
                case State.Attack:
                    if (attackDone)
                    {                     
                        animator.SetBool("attack", false);
                        nextState = State.Idle;
                        
                        attackDone = false;
                    }
                    else if ((Input.GetMouseButtonDown(0)))
                    {
                        animator.SetBool("attack", false);
                        nextState = State.Hurt;
                    }
                    break;
                case State.Hurt:
                    if (hurtDone)
                    {
                        if (slimeHp <= 0)
                        {
                            animator.SetBool("hurt", false);
                            nextState = State.Dead;
                        }
                        else
                        {
                            animator.SetBool("hurt", false);
                            nextState = State.Idle;
                        }
                        hurtDone = false;
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
                    animator.SetBool("idle", true);
                    break;

                case State.Run:
                    Run();
                    break;

                case State.Attack:
                    Attack();
                    break;

                case State.Hurt:
                    Hurt();
                    break;

                case State.Dead:
                    Dead();
                    break;

            }
        }
    }
    private void Run()
    {
        animator.SetBool("run", true);
        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
    }

    private void Attack()
    {
        animator.SetBool("attack", true);
    }
    private void AttackHit()
    {
        if(state != State.Attack)
        {
            attackDone = false;
        }
        else
        {
            GameManager.DecreaseHP(10f);
        }
    }

    private void AttackAnimationDone()
    {
        if (state != State.Attack)
        {
            attackDone = false;
        }
        else
        {
            attackDone = true; ;
        }
        
    }

    private void Hurt()
    {
        animator.SetBool("hurt", true);
    }
    private void HurtAnimationDone()
    {
        slimeHp -= 50;
        hurtDone = true;
    }
    private void Dead()
    {
        animator.SetBool("death", true);
    }
    private void DeadAnimationDone()
    {
        deadDone = true;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1f, 0f, 0f, 0.5f);
        Gizmos.DrawSphere(transform.position, attackRange);

        Gizmos.color = new Color(85f, 211f, 241f, 0.3f);
        Gizmos.DrawSphere(transform.position, followRange);
    }
}
