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
        // �ʱ� ���� ����
        SetObjectsState();

        // UI ��ư�� Ŭ�� �̺�Ʈ �ڵ鷯 �߰�
        if (button != null)
        {
            button.onClick.AddListener(ToggleState);
        }
    }

    public void ToggleState()
    {
        Debug.Log("click");
        // up ���¸� down����, down ���¸� up���� ��ȯ
        isUpState = !isUpState;

        // ��ȯ�� ���¿� ���� ������Ʈ Ȱ��ȭ �� ��Ȱ��ȭ
        SetObjectsState();
        SoundManager.instance.analogButtonSound.Play();
    }

    void SetObjectsState()
    {
        up.SetActive(isUpState);
        down.SetActive(!isUpState);
    }
}