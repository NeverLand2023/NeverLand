using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : MonoBehaviour
{
    [Header("Preset Fields")]
    [SerializeField] private Animator animator;

    [Header("Settings")]
    [SerializeField] private float attackRange;
    [SerializeField] private float followRange;
    [SerializeField] private float moveSpeed;

    public int hp = 200;

    public Transform target;
    public GameObject AttackCol;
    public GameObject[] nextObjectPrefab;


    private bool facingRight = true;
    private bool isWalking = false;
    private bool ableWalking = false;
    private int result = 0;


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

    private string originalTag;

    void Start()
    {
        state = State.None;
        nextState = State.Idle;
        animator.SetBool("idle", true);

        GameObject playerObject = GameObject.Find("Main_Hook"); // "PlayerObjectName"에는 실제 플레이어 오브젝트의 이름을 넣어주세요.

        B2_Monster monster = GetComponentInParent<B2_Monster>();
        if (monster != null)
        {
            hp = monster.GetHP();
        }

        if (playerObject != null)
        {
            target = playerObject.transform;
        }

        StartCoroutine(DisappearAfterDelay());
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            animator.SetBool("idle", false);
            animator.SetBool("walk", false);
            animator.SetBool("attack", false);
            animator.SetBool("death", true);
            nextState = State.Dead;
        }

        FlipIfNeeded(-(transform.position.x - target.position.x));

        if (nextState == State.None)
        {
            switch (state)
            {
                case State.Idle:
                    if (hp <= 0)
                    {
                        animator.SetBool("idle", false);
                        nextState = State.Dead;
                    }
                    else if (ableWalking && Physics2D.OverlapCircle(transform.position, followRange, 1 << 3))
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
                    if (hp <= 0)
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
                    if (hp <= 0)
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

        Collider2D hitCollider = Physics2D.OverlapCircle(transform.position, attackRange, 1 << 3);
        
        if (hitCollider != null && hitCollider.tag == "PlayerAttack")
        {
            animator.SetTrigger("Hurt");
            hp -= 1;
        }

        if (hp <= 0)
        {
            //Debug.Log("디짐");
            animator.SetTrigger("Death");
        }

        B2_Monster monster = GetComponentInParent<B2_Monster>();
        if (monster != null)
        {
            monster.SetHP(hp);
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
        AttackCol.SetActive(true);
    }

    private void AttackAnimationDone()
    {
        attackDone = true;
        AttackCol.SetActive(false); 
    }

    private void Dead()
    {
        ableWalking = false;
        animator.SetTrigger("death");

    }
    private void DeadAnimationDone()
    {
        monsterControl.deadMonster += 1;
        deadDone = true;
        Destroy(gameObject);

    }

    private void AppearAnimationDone()
    {
        ableWalking = true;
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

    IEnumerator FollowTarget()
    {
        while (isWalking && ableWalking)
        {

            float step = moveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target.position, step);


            yield return null;
        }
        yield return null;
    }

    IEnumerator DisappearAfterDelay()
    {
        yield return new WaitForSeconds(10f); // 10초 대기

        // disappear 애니메이션 실행
        animator.SetTrigger("disappear");

        yield return new WaitForSeconds(0.5f); // disappear 애니메이션의 길이에 맞춰 조절

        // 다음 오브젝트 생성
        result = Random.Range(0, 2);
        GameObject newObject = Instantiate(nextObjectPrefab[result], transform.position, Quaternion.identity);

        B2_Monster monster = GetComponentInParent<B2_Monster>();
        if (monster != null)
        {
            monster.SetHP(hp);
        }

        // 이전 오브젝트 제거
        if (newObject != null )
        {
            newObject.transform.parent = transform.parent;
            Destroy(gameObject);
        }
    }
}