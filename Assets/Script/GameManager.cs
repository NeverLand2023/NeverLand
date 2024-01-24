using System;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    // 싱글톤 인스턴스
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
            // 인스턴스가 없으면 생성
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        // 인스턴스가 이미 존재하면 새로 생성하지 않고 기존 인스턴스를 사용
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
        // 시작 시 플레이어의 HP를 최대 HP로 초기화
        currentHP = maxHP;

        healSound = GetComponent<AudioSource>();

        // 인벤토리 초기화
        for (int i = 0; i < invenArray.Length; i++)
        {
            invenArray[i] = new Tuple<GameObject, GameObject, string>(null, null, null);
        }

    }

    // 현재 HP를 반환하는 메서드
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

    // 플레이어의 HP를 감소시키는 메서드
    public static void DecreaseHP(float amount)
    {
        currentHP -= amount;

        // 체력이 0보다 작거나 같으면 플레이어를 사망 처리
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