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
        // �Է� �ʵ��� onValueChanged �̺�Ʈ�� �Լ��� ���
        inputField.onValueChanged.AddListener(OnInputValueChanged);
        audioSource = gameObject.AddComponent<AudioSource>();  // AudioSource ���� �߰�
        audioSource.clip = bip;
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