using System;
using System.Collections.Generic;
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
    public List<GameObject> invenObjects = new List<GameObject>();
    public List<GameObject> clickObjects = new List<GameObject>();

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

        if (ContinueKey)
        {
            Debug.Log("Inven");
            Inventory.InventoryStart();
            LoadInventory();
        }
    }

    private void Start()
    {
        // ���� �� �÷��̾��� HP�� �ִ� HP�� �ʱ�ȭ
        currentHP = maxHP;

        healSound = GetComponent<AudioSource>();

        // �κ��丮 �ʱ�ȭ
        for (int i = 0; i < invenArray.Length; i++)
        {
            invenArray[i] = new Tuple<GameObject, GameObject, string>(null, null, null);
        }

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

    public static void ResetHP()
    {
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

    public void LoadInventory()
    {
        Debug.Log("InvenFilling");
        Inventory.invenFilled = 0;
        int invenNumber = PlayerPrefs.GetInt("InvenFilled");

        for (int i = 0; i < invenNumber; i++)
        {
            string itemName = PlayerPrefs.GetString("Inventory_" + (i).ToString());
            Debug.Log("itemName: " + itemName);
            if (itemName == "NumberNote0")
            {
                Inventory.InventorySend(invenObjects[0], clickObjects[2], "NumberNote0");
            }
            else if (itemName == "NumberNote2")
            {
                Inventory.InventorySend(invenObjects[0], clickObjects[1], "NumberNote2");
            }
            else if (itemName == "NumberNote6")
            {
                Inventory.InventorySend(invenObjects[0], clickObjects[0], "NumberNote6");
            }
            else if (itemName == "DiaryNote0")
            {
                Inventory.InventorySend(invenObjects[1], clickObjects[3], "DiaryNote0");
            }
            else if (itemName == "Lighter")
            {
                Inventory.InventorySend(invenObjects[2], null, "Lighter");
            }
            else if (itemName == "Key")
            {
                Inventory.InventorySend(invenObjects[3], null, "Key");
            }
        }
    }


}