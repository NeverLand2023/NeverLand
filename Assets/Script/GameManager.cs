using System;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    // 싱글톤 인스턴스
    private static GameManager instance;

    public static float maxHP = 100;
    private static float currentHP;

    public static bool ContinueKey = false;

    //inventory
    public static Tuple<GameObject, GameObject, string>[] invenArray = new Tuple<GameObject, GameObject, string>[6];
    
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
    }

    private void Start()
    {
        // 시작 시 플레이어의 HP를 최대 HP로 초기화
        currentHP = maxHP;
    }

    // 현재 HP를 반환하는 메서드
    public static float GetCurrentHP()
    {
        return currentHP;
    }

    /*// 플레이어의 HP를 증가시키는 메서드
    public void IncreaseHP(int amount)
    {
        currentHP += amount;

        // 최대 HP를 넘지 않도록 제한
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
    }*/

    public static void EatHealItem()
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

}