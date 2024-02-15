using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class input : MonoBehaviour
{
    public TMP_InputField inputField;
    public PcUI_control PcUIControl;
    public GameObject PCUI_off;
    public GameObject locker;
    private AudioSource audioSource;
    public AudioClip bip;
    public GameObject minimapline;
    public Camera minimapcam;
    public Camera minimapcam2;

    // Start is called before the first frame update
    void Start()
    {
        // 입력 필드의 onValueChanged 이벤트에 함수를 등록
        inputField.onValueChanged.AddListener(OnInputValueChanged);
        audioSource = gameObject.AddComponent<AudioSource>();  // AudioSource 동적 추가
        audioSource.clip = bip;
    }

    // 입력이 변경될 때 호출되는 함수
    void OnInputValueChanged(string input)
    {
        // 입력된 텍스트 가져오기
        string inputText = inputField.text;

        // 문자열이 숫자로 변환 가능한지 확인
        if (int.TryParse(inputText, out int result))
        {
            Debug.Log("입력숫자" +result);
            // 입력된 숫자가 4567이면 PcUI_control 스크립트의 변수 UInum을 1로 변경
            if (result == 4653 && PcUIControl != null)
            {
                
                PcUIControl.UInum = 1;
                
                PCUI_off.SetActive(false);
                locker.SetActive(true);
                minimapline.SetActive(true);
                minimapcam.enabled = true;
                minimapcam2.enabled = true;
                // audioSource.Play();

            }
            else
            {
                result = 0;
                audioSource.Play();

            }
            
        }
    }
}