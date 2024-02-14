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

    // Start is called before the first frame update
    void Start()
    {
        // �Է� �ʵ��� onValueChanged �̺�Ʈ�� �Լ��� ���
        inputField.onValueChanged.AddListener(OnInputValueChanged);
    }

    // �Է��� ����� �� ȣ��Ǵ� �Լ�
    void OnInputValueChanged(string input)
    {
        // �Էµ� �ؽ�Ʈ ��������
        string inputText = inputField.text;

        // ���ڿ��� ���ڷ� ��ȯ �������� Ȯ��
        if (int.TryParse(inputText, out int result))
        {
            Debug.Log("�Է¼���" +result);
            // �Էµ� ���ڰ� 4567�̸� PcUI_control ��ũ��Ʈ�� ���� UInum�� 1�� ����
            if (result == 4653 && PcUIControl != null)
            {
                
                PcUIControl.UInum = 1;
  
                PCUI_off.SetActive(false);
                locker.SetActive(true);

            }
        }
    }
}