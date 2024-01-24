using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gear_rotation : MonoBehaviour
{

    public GameObject background_black;
    public AudioClip rotation_sound;

    public float rotation =15f;
    public int left = 0;
    public int right = 0;
    private AudioSource audioSource;


    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();  // AudioSource 동적 추가
        audioSource.clip = rotation_sound;  // 오디오 클립 설정
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            right = 0;
            left = 0;
            gameObject.SetActive(false);
            background_black.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.forward, rotation);
            left +=1;

            audioSource.Play();
            if (left == 3 && right == 5)
            {
                gameObject.SetActive(false);
                background_black.SetActive(false);
            }
            if (left > 10)
            {
                left = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.back, rotation);
            right +=1;

            audioSource.Play();
            if (left == 3 && right == 5)
            {
                gameObject.SetActive(false);
                background_black.SetActive(false);
            }
            if (right > 10)
            {
                right = 0;
            }

        }

        
    }
}
