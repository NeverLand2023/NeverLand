using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chase_player : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    bool canChangeNextMove = true;
    float changeNextMoveDuration = 1.5f; // 변경할 수 있는 시간 간격 (초)

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (!canChangeNextMove)
        {
            // 일정 시간 후에 다시 변경 가능하도록 설정
            StartCoroutine(ResetChangeNextMove());
        }
    }

    private IEnumerator ResetChangeNextMove()
    {
        yield return new WaitForSeconds(changeNextMoveDuration);
        canChangeNextMove = true;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        // find player
        if (other.gameObject.CompareTag("Player") && canChangeNextMove)
        {
            transform.parent.GetComponent<Monster_slime>().notFindPlayer();
            Vector3 playerPos = other.transform.position;

            if (playerPos.x > transform.position.x)
            {
                transform.parent.GetComponent<Monster_slime>().nextMove = 2; // speed up
                canChangeNextMove = false; // 변경 중복 방지
                Debug.Log("발견 오른쪽");
            }
            else if (playerPos.x < transform.position.x)
            {
                spriteRenderer.flipX = playerPos.x < transform.position.x;
                transform.parent.GetComponent<Monster_slime>().nextMove = -2;
                canChangeNextMove = false; // 변경 중복 방지
                Debug.Log("발견 왼쪽");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            transform.parent.GetComponent<Monster_slime>().notFindPlayer();
            canChangeNextMove = false; // 변경 중복 방지
        }
    }
}
