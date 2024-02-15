using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class click_x : MonoBehaviour
{
    public GameObject uiObject; // ������� �ϴ� UI ������Ʈ
    private AudioSource audioSource;
    public AudioClip clickXbox;

    public GameObject minimapline;
    public Camera minimapcam;
    public Camera minimapcam2;

    void Start()
    {
        // ��ư�� Ŭ�� �̺�Ʈ �߰�
        Button xButton = uiObject.GetComponent<Button>();
        xButton.onClick.AddListener(OnXButtonClick);
        audioSource = gameObject.AddComponent<AudioSource>();  // AudioSource ���� �߰�
        audioSource.clip = clickXbox;
    }

    public void OnXButtonClick()
    {
        // ��ư�� Ŭ���Ǿ��� �� ����Ǵ� �Լ�
        
            uiObject.SetActive(false);
            Debug.Log("UI�� ��Ȱ��ȭ�մϴ�.");
            audioSource.Play();
            minimapline.SetActive(true);
            minimapcam.enabled = true;
            minimapcam2.enabled = true;

    }

}


