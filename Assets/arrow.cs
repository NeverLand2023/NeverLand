using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{
    private bool collided = false;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("collided", false);
    }

    // 다른 콜라이더와 충돌했을 때 호출되는 함수
    // 다른 콜라이더와 충돌했을 때 호출되는 함수
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim.SetBool("collided", true);
            Debug.Log("플레이어와 충돌!");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        anim.SetBool("collided", false);
        collided = false;
    }
    // 매 프레임마다 호출되는 함수
    private void Update()
    {
        // 추가적인 로직이 필요한 경우 여기에 작성
    }
}
