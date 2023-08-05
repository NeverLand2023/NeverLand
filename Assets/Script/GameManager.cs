using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 싱글톤 인스턴스
    private static GameManager instance;

    // 플레이어의 최대 HP
    public static float maxHP = 100;

    // 현재 HP
    private static float currentHP;

    // 싱글톤 인스턴스에 접근하기 위한 프로퍼티
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
            currentHP = 0;
            PlayerDeath();
        }
    }

    // 플레이어가 사망한 경우 처리하는 메서드
    private static void PlayerDeath()
    {
        // 사망 처리 로직을 작성하면 됩니다. (예: 게임 종료, 리스폰 등)
        // 여기에 사망 처리를 구현하면 됩니다.
    }
}