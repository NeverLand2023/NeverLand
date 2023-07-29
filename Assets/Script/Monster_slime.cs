using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_slime : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator anim;
    SpriteRenderer spriteRenderer;


    // �ൿ�� �����ϴµ� ����� ���� nextMove
    public int nextMove;
    public bool attack = false;
    //public bool damaged= false;


    // ���� ���� ��ǥ
    private Vector3 originalPosition;

    // ���Ͱ� �����ϴ� �Ÿ�
    public float attackRange = 1f;

    // �÷��̾�� �浹�� �ð�
    private float lastAttackTime = -1f;


    // ���� �ִϸ��̼� ��� �ð�
    public float attackAnimationDuration = 1f;

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
        float distanceFromOriginal = Vector3.Distance(originalPosition, transform.position);

        //����ǥ���� �¿� 5��ŭ�� �̵�
        if (distanceFromOriginal <= 2f)
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

        // �÷��̾�� �浹�� �� ���� �ð��� ������ ���� �ִϸ��̼� ����
        if (Time.time - lastAttackTime >= attackAnimationDuration)
        {
            anim.SetBool("attack", false);
        }
    }

    void notFindPlayer()
    {
        nextMove = Random.Range(-1, 2); // -1, 0, 1 �߿��� �������� ���� ����



        anim.SetInteger("walkspeed", nextMove);


        //�������� ���� ����
        if(nextMove != 0)
        {
            spriteRenderer.flipX = nextMove == -1;

        }

        float nextmovetime = Random.Range(2f, 5f);
        Invoke("notFindPlayer", nextmovetime);


    }


    // �÷��̾�� �浹���� �� ȣ��Ǵ� �Լ�

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("�浹");

            AttackPlayer();

        }
    }


    // �÷��̾� ���� �Լ�
    void AttackPlayer()
    {
        // �÷��̾�� �浹�� �ð� ���
        lastAttackTime = Time.time;

        // ���� �ִϸ��̼� ����
        anim.SetBool("attack", true);

        Debug.Log("���Ͱ� �÷��̾ ����");



    }






}