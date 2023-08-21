using System;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    // �̱��� �ν��Ͻ�
    private static GameManager instance;

    public static float maxHP = 100;
    private static float currentHP;

    public static bool ContinueKey = false;
    public static bool RestartKey = false; 

    //inventory
    public static Tuple<GameObject, GameObject, string>[] invenArray = new Tuple<GameObject, GameObject, string>[6];

    public static AudioSource healSound;

    public static GameManager Instance
    {
        get
        {
            // �ν��Ͻ��� ������ ����
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        // �ν��Ͻ��� �̹� �����ϸ� ���� �������� �ʰ� ���� �ν��Ͻ��� ���
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        // ���� �� �÷��̾��� HP�� �ִ� HP�� �ʱ�ȭ
        currentHP = maxHP;

        healSound = GetComponent<AudioSource>();
    }

    // ���� HP�� ��ȯ�ϴ� �޼���
    public static float GetCurrentHP()
    {
        return currentHP;
    }

    public static void EatHealItem()
    {
        healSound.Play();
        currentHP = maxHP;
    }

    // �÷��̾��� HP�� ���ҽ�Ű�� �޼���
    public static void DecreaseHP(float amount)
    {
        currentHP -= amount;

        // ü���� 0���� �۰ų� ������ �÷��̾ ��� ó��
        if (currentHP <= 0)
        {
            GameObject mainHookObject = GameObject.Find("Main_Hook");
            if (mainHookObject != null)
            {
                Main_Hook mainHook = mainHookObject.GetComponent<Main_Hook>();
                if (mainHook != null)
                {
                    mainHook.PlayerDeath();
                }
            }
            currentHP = 0;
        }
    }    

}