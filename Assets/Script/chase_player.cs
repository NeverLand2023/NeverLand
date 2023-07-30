using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chase_player : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    bool canChangeNextMove = true;
    float changeNextMoveDuration = 1.5f; // ������ �� �ִ� �ð� ���� (��)

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (!canChangeNextMove)
        {
            // ���� �ð� �Ŀ� �ٽ� ���� �����ϵ��� ����
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
                canChangeNextMove = false; // ���� �ߺ� ����
                Debug.Log("�߰� ������");
            }
            else if (playerPos.x < transform.position.x)
            {
                spriteRenderer.flipX = playerPos.x < transform.position.x;
                transform.parent.GetComponent<Monster_slime>().nextMove = -2;
                canChangeNextMove = false; // ���� �ߺ� ����
                Debug.Log("�߰� ����");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            transform.parent.GetComponent<Monster_slime>().notFindPlayer();
            canChangeNextMove = false; // ���� �ߺ� ����
        }
    }
}
