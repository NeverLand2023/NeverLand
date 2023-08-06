using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class mushroom : MonoBehaviour
{
    public Sprite desiredSprite; // 원하는 이미지를 Inspector 창에서 지정해주세요.
    public float changeDuration = 30f; // 이미지 변경 지속 시간 (30초로 가정)

    private Sprite originalSprite; // 원래 이미지
    private SpriteRenderer spriteRenderer;
    private float timeElapsed = 0f; // 이미지 변경 지속 시간 경과 시간

    public GameObject mushroonLight;


    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalSprite = spriteRenderer.sprite;


    }

    private void Update()
    {
        // 플레이어 위치에서 일정 거리 내에 있는지 확인
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
            // 이미지 변경 함수 호출
            ChangeImage();

            // 라이트 
            //mushroomLight.SetActive(false);

        }

        // 이미지가 변경된 후, 일정 시간이 지나면 원래 이미지로 복원
        if (spriteRenderer.sprite == desiredSprite)
        {
            timeElapsed += Time.deltaTime;
            if (timeElapsed >= changeDuration)
            {
                // 원래 이미지로 복원
                spriteRenderer.sprite = originalSprite;
                timeElapsed = 0f;

                //mushroomLight.SetActive(false);


            }
        }
    }

    public void ChangeImage()
    {
        // 이미지를 원하는 이미지로 변경
        if (desiredSprite != null)
        {
            spriteRenderer.sprite = desiredSprite;
            timeElapsed = 0f; // 이미지 변경 시 타이머 초기화
        }
    }
}
