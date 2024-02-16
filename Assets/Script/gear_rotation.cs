using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            Main_Hook.attackAvailable = true;
            right = 0;
            left = 0;
            Main_Hook.MoveUnavailable = false;
            gameObject.SetActive(false);
            background_black.SetActive(false);

        }

        if (Input.GetKeyDown(KeyCode.LeftArrow)|| Input.GetKeyDown(KeyCode.A))
        {
            transform.Rotate(Vector3.forward, rotation);
            left +=1;

            audioSource.Play();
            if (left == 3 && right == 5)
            {
                Main_Hook.attackAvailable = true;
                Main_Hook.MoveUnavailable = false;
    
                SceneManager.LoadScene("Mission3");

            }
            if (left > 10)
            {
                left = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow)|| Input.GetKeyDown(KeyCode.D))
        {
            transform.Rotate(Vector3.back, rotation);
            right +=1;

            audioSource.Play();
            if ( right == 5 && left == 3)
            {
                Main_Hook.attackAvailable = true;
                Main_Hook.MoveUnavailable = false;
               
                SceneManager.LoadScene("Mission3");


            }
            if (right > 10)
            {
                right = 0;
            }

        }

        
    }
}
