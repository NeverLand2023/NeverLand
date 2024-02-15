using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class click_x : MonoBehaviour
{
    public GameObject uiObject; // 숨기고자 하는 UI 오브젝트
    private AudioSource audioSource;
    public AudioClip clickXbox;

    public GameObject minimapline;
    public Camera minimapcam;
    public Camera minimapcam2;

    void Start()
    {
        // 버튼에 클릭 이벤트 추가
        Button xButton = uiObject.GetComponent<Button>();
        xButton.onClick.AddListener(OnXButtonClick);
        audioSource = gameObject.AddComponent<AudioSource>();  // AudioSource 동적 추가
        audioSource.clip = clickXbox;
    }

    public void OnXButtonClick()
    {
        // 버튼이 클릭되었을 때 실행되는 함수
        
            uiObject.SetActive(false);
            Debug.Log("UI를 비활성화합니다.");
            audioSource.Play();
            minimapline.SetActive(true);
            minimapcam.enabled = true;
            minimapcam2.enabled = true;

    }

}


