using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSlime : MonoBehaviour
{
    SpriteRenderer spriter;
    Animator anim;

    public GameObject player;
    public GameObject BossEntry;

    public float distance;
    float time = 0f;
    float time2 = 0f;

    public static int bossHp = 500;
    private bool playerEnter = false;

    private void Awake()
    {
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //�÷��̾�� �Ÿ� ���
        distance = Vector2.Distance(transform.position, player.transform.position);
        anim.SetFloat("Pdistance", distance);
        if(transform.position.x > player.transform.position.x)
        {
            spriter.flipX = true;
        }
        else
        {
            spriter.flipX = false;
        }

        time += Time.deltaTime;

        //������ ������
        if (time % 3 > 0 && time % 3 < 1)
        {
            BossSlimeMove();
        }

        //������ �ǰ�
/*        if (playerEnter)
        {
            if (Input.GetMouseButtonDown(0))
            {
                bossHp -= 50;
                anim.SetTrigger("hurt");
            }
        }*/

        //������ ����
        if (bossHp <= 0)
        {
            anim.SetBool("isDeath", true);
            GetComponent<Collider2D>().isTrigger = true;
            SoundManager.instance.bossSlimeDeadSound.Play();
            time2 += Time.deltaTime;
            if(time2 > 2)
            {
                BossEntry.SetActive(false);
                gameObject.SetActive(false);
            }
        }

    }

    void BossSlimeMove()
    {
        //�÷��̾ ������ ���� ������
        if (spriter.flipX == false && player.transform.position.y > transform.position.y)
        {
            transform.position = new Vector2(transform.position.x + 0.01f, transform.position.y + 0.01f);
        }
        //�÷��̾ ������ �Ʒ��� ������
        else if (spriter.flipX == false && player.transform.position.y < transform.position.y)
        {
            transform.position = new Vector2(transform.position.x + 0.01f, transform.position.y - 0.01f);
        }
        //�÷��̾ ���� ���� ������
        else if (spriter.flipX == true && player.transform.position.y > transform.position.y)
        {
            transform.position = new Vector2(transform.position.x - 0.01f, transform.position.y + 0.01f);
        }
        //�÷��̾ ���� �Ʒ��� ������
        else if (spriter.flipX == true && player.transform.position.y < transform.position.y)
        {
            transform.position = new Vector2(transform.position.x - 0.01f, transform.position.y - 0.01f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "PlayerAttack")
        {
            bossHp -= 50;
            anim.SetTrigger("hurt");
        }
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


    private void AttackAnimationStart()
    {
        SoundManager.instance.bossSlimeAttackSound.Play();
    }

    public static float GetCurrentHP()
    {
        return bossHp;
    }
}

