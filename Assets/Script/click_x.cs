using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class click_x : MonoBehaviour
{
    public GameObject uiObject; // ������� �ϴ� UI ������Ʈ



    void Start()
    {
        // ��ư�� Ŭ�� �̺�Ʈ �߰�
        Button xButton = uiObject.GetComponent<Button>();
        xButton.onClick.AddListener(OnXButtonClick);
    }

    public void OnXButtonClick()
    {
        // ��ư�� Ŭ���Ǿ��� �� ����Ǵ� �Լ�
        
            uiObject.SetActive(false);
            Debug.Log("UI�� ��Ȱ��ȭ�մϴ�.");
        
    }

}


