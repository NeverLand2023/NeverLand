using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class BossTree : MonoBehaviour
{
    [Header("Preset Fields")]
    [SerializeField] private Animator animator;

    public GameObject bossThorn;
    public GameObject playerHook;
    public GameObject Box3;
    public int numberOfThorns = 10;
    public Vector2 xRange = new Vector2(-21f, 2f);
    public Vector2 yRange = new Vector2(172f, 183f);
    public enum State
    {
        None,
        Idle,
        Attack,
        Dead
    }

    public State state = State.None;
    public State nextState = State.None;

    private bool attackDone=false;
    private bool deadDone = false;

    public float attackTime = 5f;
    public float countTime = 0;

    public float followTime = 2f;
    private float curTime = 0;

    private static int bossHp = 500;
    private bool playerEnter = false;

    Collider2D[] hit;


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
                    if (bossHp <= 0)
                    {
                        animator.SetBool("Idle", false);
                        nextState = State.Dead;
                    }
                    else if (countTime >= attackTime)
                    {
                        animator.SetBool("Idle", false);
                        nextState = State.Attack;                        
                    }

                    countTime += Time.deltaTime;
                    break;
                case State.Attack:
                    if (bossHp <= 0)
                    {
                        animator.SetBool("Attack", false);
                        nextState = State.Dead;
                        attackDone = false;
                    }
                    else
                    {
                        if (attackDone)
                        {
                            animator.SetBool("Attack", false);
                            nextState = State.Idle;
                            attackDone = false;
                        }

                    }
                    attackDone = true;
                    break;
                case State.Dead:
                    if (deadDone)
                    {
                        Box3.SetActive(true);
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
        hit = Physics2D.OverlapBoxAll(transform.position, new Vector2(40, 20), 0);
/*        for(int i= 0; i < hit.Length; i++)
        {
            Debug.Log(hit[i]);
        }*/
        curTime += Time.deltaTime;
        if (Array.Exists(hit, x => x.tag.Equals("Player")))
        {
            if (curTime >= followTime)
            {
                Instantiate(bossThorn, playerHook.transform.position, Quaternion.identity);
                curTime = 0;
            }
        }


        /*        if (playerEnter)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        Debug.Log("20 ����");
                        bossHp -= 30;
                    }
                }*/
        if (playerEnter)
        {
            Debug.Log("20 ����");
            bossHp -= 30;
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector2(40, 20));
    }
    private void Idle()
    {
        countTime = 0;
        Debug.Log("Idle");
        animator.SetBool("Idle", true);
    }

    private void Attack()
    {
        if (Array.Exists(hit, x => x.tag.Equals("Player")))
        {
            animator.SetBool("Attack", true);
            for (int i = 0; i < numberOfThorns; i++)
            {
                Vector3 randomPosition = GenerateRandomPosition();
                Instantiate(bossThorn, randomPosition, Quaternion.identity);
            }
        }
    }

    public void AttackAnimationEnd()
    {
        attackDone = true;
        Debug.Log("AttackDone");
    }

    private void Dead()
    {
        animator.SetBool("Dead", true);
        
    }

    public void DeadAnimationEnd()
    {
        deadDone = true;
        AudioSource bgmAudioSource = Camera.main.GetComponent<AudioSource>();
        SoundManager.instance.bossTreeBGM.Pause();
        bgmAudioSource.UnPause(); // BGM�� �ٽ� �����Ŵ
    }
    private Vector3 GenerateRandomPosition()
    {
        Vector3 randomPosition;

        do
        {
            randomPosition = new Vector3(Random.Range(xRange.x, xRange.y), Random.Range(yRange.x, yRange.y), 0f);
        }
        while (
            randomPosition.x >= new Vector2(-10.35f, -6.34f).x && randomPosition.x <= new Vector2(-10.35f, -6.34f).y &&
            randomPosition.y >= new Vector2(176.64f, 182.04f).x && randomPosition.y <= new Vector2(176.64f, 182.04f).y
        );

        return randomPosition;
    }

    /*    private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == ("Player"))
            {
                playerEnter = true;
            }
        }
        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.tag == ("Player"))
            {
                playerEnter = false;
            }
        }*/
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("PlayerAttack"))
        {
            Debug.Log("20 ����");
            bossHp -= 30;
        }
    }

    public static float GetCurrentHP()
    {
        return bossHp;
    }
}
