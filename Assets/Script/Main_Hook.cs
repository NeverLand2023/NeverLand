using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;


public class Main_Hook : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed;

    Rigidbody2D rigid;
    SpriteRenderer spriter;
    Animator anim;

    public GameObject bossTree;
    public GameObject bossSlime;

    public TilemapCollider2D thorn;

    public Transform[] savePoints;

    public static bool attackAvailable = true;

    public AudioClip Thud;

    public AudioSource walkSound;

    public GameObject attack_effect;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

    }


    // Update is called once per frame
    void Update()
    {
        //캐릭터 움직임
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");

        //움직임 애니메이션 구현
        if (inputVec.x != 0)
        {
            spriter.flipX = inputVec.x < 0;
            anim.SetBool("isRun", true);
            if (!walkSound.isPlaying)
            {
                walkSound.Play();
            }
        }
        else if (inputVec.y != 0)
        {
            anim.SetBool("isRun", true);
            if (!walkSound.isPlaying)
            {
                walkSound.Play();
            }
        }
        else
        {
            anim.SetBool("isRun", false);
            walkSound.Stop();
        }

        //공격
        if (Input.GetMouseButtonDown(0) && attackAvailable)
        {
            rigid.constraints = RigidbodyConstraints2D.FreezeAll;
            inputVec.x = 0;
            anim.SetTrigger("Attack");
            ChangeAttackTag();
            SoundManager.instance.playSFX(SoundManager.SFX.후크공격, false);
            attack_effect.SetActive(true);
        }


        if (GameManager.ContinueKey)
        {
            GameManager.ContinueKey = false;
            float savePoint_x = PlayerPrefs.GetFloat("SavePoint_x");
            float savePoint_y = PlayerPrefs.GetFloat("SavePoint_y");
            transform.position = new Vector2(savePoint_x, savePoint_y);
        }
        if (GameManager.RestartKey)
        {
            GameManager.RestartKey = false;
            transform.position = savePoints[0].position;
        }
    }

    void FixedUpdate()
    {
        //캐릭터 움직임
        if (rigid.position.x >= 100)
        {
            rigid.position = new Vector2(100, transform.position.y);

        }
        else if (rigid.position.x <= -100)
        {
            rigid.position = new Vector2(-100, transform.position.y);
        }

        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);

    }

    void ChangeAttackTag()
    {
        gameObject.tag = "PlayerAttack"; // 플레이어 태그를 "PlayerAttack"으로 변경
        Invoke("ResetTag", anim.GetCurrentAnimatorStateInfo(0).length);

    }

    void ResetTag()
    {
        gameObject.tag = "Player"; // 플레이어 태그를 다시 "Player"로 변경
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == ("Monster"))
        {
            //GameManager.DecreaseHP(10f);
            anim.SetTrigger("Hurt");
        }
        if (collision.collider == thorn)
        {
            GameManager.DecreaseHP(10f);
            anim.SetTrigger("Hurt");
        }
        else if (collision.gameObject.tag == ("BossThorn"))
        {
            GameManager.DecreaseHP(30f);
            anim.SetTrigger("Hurt");
        }
        else if (collision.gameObject.tag == ("BossSlime"))
        {
            GameManager.DecreaseHP(20f);
            anim.SetTrigger("Hurt");
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("main_hook_Attack"))
        {

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
/*        if (collision.gameObject.tag == ("BossArea"))
        {
            bossTree.SetActive(true);
            SoundManager.instance.bossTreeBGM.Play();
            SoundManager.instance.bossTreeBGM.loop=true;
        }*/
        if (collision.gameObject.tag == ("BossSlimeArea"))
        {
            bossSlime.SetActive(true);
        }
    }
/*    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("BossArea"))
        {
            SoundManager.instance.bossTreeBGM.Stop();
        }
    }*/

    public void PlayerDeath()
    {
        anim.SetBool("isDeath", true);
        SoundManager.instance.bossTreeBGM.Stop();
    }

    public void GameOverSceneLoad()
    {
        anim.SetBool("isDeath", false);
        for (int i = 0; i < GameManager.invenArray.Length; i++)
        {
            GameManager.invenArray[i] = null;
        }
        SceneManager.LoadScene("GameOver");
    }

    /*public void MainHookRunStart()
    {
        SoundManager.instance.playSFX(SoundManager.SFX.걷는소리, false);

    }*/

    void thud()
    {
        AudioSource.PlayClipAtPoint(Thud, Camera.main.transform.position);
    }
}