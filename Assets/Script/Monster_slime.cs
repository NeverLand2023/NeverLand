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


    // �ൿ�� �����ϴµ� ����� ���� nextMove
    public int nextMove;
    public bool attack = false;
    //public bool damaged= false;


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

    

    void FixedUpdate()
    {
        // ������ ���� ��ǥ�� ���� ��ǥ ������ �Ÿ��� ���
        float distanceFromOriginal = Vector2.Distance(originalPosition, transform.position);

        float distance = Vector2.Distance(player.transform.position, transform.position);
        Debug.Log("�Ÿ���");

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
                    Debug.Log("���� �߰�");
                    nextMove = -2;


                }
                else
                {
                    spriteRenderer.flipX = false;
                    Debug.Log("������ �߰�");
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
                        Debug.Log("������->����");
                        spriteRenderer.flipX = nextMove == -1;


                    }
                    else
                    {
                        Debug.Log("����->������");
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
            Debug.Log("�ǵ��ư�");
            rigid.velocity = new Vector2(nextMove, rigid.velocity.y);
        }
        //����ǥ���� �¿� 5��ŭ�� �̵�
        


        // �÷��̾�� �浹�� �� ���� �ð��� ������ ���� �ִϸ��̼� ����
        /*if (Time.time - lastAttackTime >= attackAnimationDuration)
        {
            anim.SetBool("attack", false);
        }*/
    }

    public void notFindPlayer()
    {
        nextMove = Random.Range(-1, 2); // -1, 0, 1 �߿��� �������� ���� ����



        anim.SetInteger("walkspeed", nextMove);
        Debug.Log("�ȴ� �ִϸ��̼�?");

        
        



        //�������� ���� ����
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
            // attack �ִϸ��̼��� ����Ǿ��� �� ������ ����
            
            isAttacking = false; // attack �ִϸ��̼��� ����Ǿ����Ƿ� ���� �ʱ�ȭ
        }
    }



    // �÷��̾�� �浹���� �� ȣ��Ǵ� �Լ�

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && !isAttacking)
        {
            rigid.constraints = RigidbodyConstraints2D.FreezePositionX;
            Debug.Log("�ƾ�");
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




    // �÷��̾� ���� �Լ�
    void AttackPlayer()
    {
        // �÷��̾�� �浹�� �ð� ���
        //lastAttackTime = Time.time;

        // ���� �ִϸ��̼� ����

        
        Debug.Log("���Ͱ� �÷��̾ ����");

        Invoke("ResetAttackAnimation", anim.GetCurrentAnimatorStateInfo(0).length);



    }
    void ResetAttackAnimation()
    {

        rigid.constraints = RigidbodyConstraints2D.None;
        rigid.constraints = RigidbodyConstraints2D.FreezePositionY;

        anim.SetBool("attack", false);
        isAttacking = false; // attack �ִϸ��̼��� ����Ǿ����Ƿ� ���� �ʱ�ȭ
    }


    void Die()
    {

        Destroy(gameObject);
    }
}





