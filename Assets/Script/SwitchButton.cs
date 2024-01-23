using UnityEngine;
using UnityEngine.UI;

public class SwitchButton : MonoBehaviour
{
    public GameObject up;
    public GameObject down;
    public Button button;

    public bool isUpState = true;

    void Start()
    {
        // 초기 상태 설정
        SetObjectsState();

        // UI 버튼에 클릭 이벤트 핸들러 추가
        if (button != null)
        {
            button.onClick.AddListener(ToggleState);
        }
    }

    public void ToggleState()
    {
        Debug.Log("click");
        // up 상태면 down으로, down 상태면 up으로 전환
        isUpState = !isUpState;

        // 전환된 상태에 따라 오브젝트 활성화 및 비활성화
        SetObjectsState();
        SoundManager.instance.analogButtonSound.Play();
    }

    void SetObjectsState()
    {
        up.SetActive(isUpState);
        down.SetActive(!isUpState);
    }
}