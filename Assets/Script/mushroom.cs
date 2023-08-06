using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class mushroom : MonoBehaviour
{
    public Sprite desiredSprite; // ���ϴ� �̹����� Inspector â���� �������ּ���.
    public float changeDuration = 30f; // �̹��� ���� ���� �ð� (30�ʷ� ����)

    private Sprite originalSprite; // ���� �̹���
    private SpriteRenderer spriteRenderer;
    private float timeElapsed = 0f; // �̹��� ���� ���� �ð� ��� �ð�

    public GameObject mushroonLight;


    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalSprite = spriteRenderer.sprite;


    }

    private void Update()
    {
        // �÷��̾� ��ġ���� ���� �Ÿ� ���� �ִ��� Ȯ��
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 2f);
        bool playerNearby = false;
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                playerNearby = true;
                break;
            }
        }

        if (playerNearby && Input.GetKeyDown(KeyCode.Space))
        {
            // �̹��� ���� �Լ� ȣ��
            ChangeImage();

            // ����Ʈ 
            //mushroomLight.SetActive(false);

        }

        // �̹����� ����� ��, ���� �ð��� ������ ���� �̹����� ����
        if (spriteRenderer.sprite == desiredSprite)
        {
            timeElapsed += Time.deltaTime;
            if (timeElapsed >= changeDuration)
            {
                // ���� �̹����� ����
                spriteRenderer.sprite = originalSprite;
                timeElapsed = 0f;

                //mushroomLight.SetActive(false);


            }
        }
    }

    public void ChangeImage()
    {
        // �̹����� ���ϴ� �̹����� ����
        if (desiredSprite != null)
        {
            spriteRenderer.sprite = desiredSprite;
            timeElapsed = 0f; // �̹��� ���� �� Ÿ�̸� �ʱ�ȭ
        }
    }
}
