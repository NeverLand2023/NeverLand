using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home_Hook : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed;
    public GameObject error_light;
    public GameObject[] emoji;
    private bool emojiFlag = false;

    Rigidbody2D rigid;
    SpriteRenderer spriter;
    Animator anim;

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
        if (inputVec.x != 0)
        {
            anim.SetBool("isSleep", false);
            rigid.position = new Vector2(rigid.position.x, -1.5f);
            spriter.flipX = inputVec.x < 0;
            anim.SetBool("isWalk", true);
        }
        else                        //Idle
        {
            anim.SetBool("isWalk", false);
        }

        //컴퓨터 상호작용
        if(rigid.position.x > -4.5 && rigid.position.x < -3)
        {
            if (!emojiFlag)
            {
                emojiFlag = true;
                StartCoroutine(EmojiSequentially(emoji, 0.5f));
            }  
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                error_light.SetActive(true);
            }   
        }


    }

    void FixedUpdate()
    {
        //캐릭터 움직임
        if (rigid.position.x >= 9)
        {
            rigid.position = new Vector2(9, transform.position.y);

        }
        else if (rigid.position.x <= -9)
        {
            rigid.position = new Vector2(-9, transform.position.y);
        }

        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);

    }

    IEnumerator EmojiSequentially(GameObject[] objects, float delayTime)
    {
        foreach (var obj in objects)
        {
            // 현재 오브젝트 활성화
            obj.SetActive(true);

            // 일정 시간 대기
            yield return new WaitForSeconds(delayTime);

            // 현재 오브젝트 삭제
            Destroy(obj);

            yield return new WaitForSeconds(1f);
        }
    }
}
