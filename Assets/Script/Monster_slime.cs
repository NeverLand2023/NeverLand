
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


    // �ൿ�� �����ϴµ� ����� ���� nextMove
    public int nextMove;
    public bool attack = false;
    
 
    
    // ���� ���� ��ǥ
    private Vector2 originalPosition;

    // ���Ͱ� �����ϴ� �Ÿ�
    //public float attackRange = 1f;

    // �÷��̾�� �浹�� �ð�
    //private float lastAttackTime = -1f;


    // ���� �ִϸ��̼� ��� �ð�
    //public float attackAnimationDuration = 1f;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        notFindPlayer();

        // ������ ���� ��ǥ ����
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
        // ������ ���� ��ǥ�� ���� ��ǥ ������ �Ÿ��� ���
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
              Debug.Log("�ǵ��ư�");
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
                    // �Ÿ��� 5�� ������ �ݴ� �������� �̵�
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
        nextMove = Random.Range(-1, 2); // -1, 0, 1 �߿��� �������� ���� ����



        anim.SetInteger("walkspeed", nextMove);


        //�������� ���� ����
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

        //������ ����
        if (slimeHp <= 0)
        {
            anim.SetBool("die", true);
            StartCoroutine(DeathCoroutine());
        }
    }

    void wait()
    {

    }
    // �÷��̾�� �浹���� �� ȣ��Ǵ� �Լ�

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



    // �÷��̾� ���� �Լ�
    void AttackPlayer()
    {
       


        Debug.Log("���Ͱ� �÷��̾ ����");
        
        
        Invoke("ResetAttackAnimation", anim.GetCurrentAnimatorStateInfo(0).length);
        //StartCoroutine(CheckCollisionWhileAttacking());




    }

    IEnumerator CheckCollisionWhileAttacking()
    {
        //3�� ���
        yield return new WaitForSeconds(3);

        // ���� �ִϸ��̼��� ���� �Ŀ� �÷��̾�� �浹 ������ Ȯ��
        if (isAttacking && player != null)
        {
            // �÷��̾�� �浹�� ���¸� �ٽ� Ȯ���ϰ� �ʿ��� ó���� ����
            OnCollisionEnter2D(new Collision2D()); // Collision2D�� ���� �浹 ������ �����ؾ� ��
        }
    }
    void ResetAttackAnimation()
    {

        // x�� ���� ����
        rigid.constraints &= ~RigidbodyConstraints2D.FreezePositionX;

        anim.SetBool("attack", false);

        isAttacking = false; // attack �ִϸ��̼��� ����Ǿ����Ƿ� ���� �ʱ�ȭ
    }


    void Die()
    {

        Destroy(gameObject);
    }
}





