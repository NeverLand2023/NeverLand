using UnityEngine;

public class GameManager : MonoBehaviour
{
    // �̱��� �ν��Ͻ�
    private static GameManager instance;

    // �÷��̾��� �ִ� HP
    public static float maxHP = 100;

    // ���� HP
    private static float currentHP;

    // �̱��� �ν��Ͻ��� �����ϱ� ���� ������Ƽ
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
    }

    // ���� HP�� ��ȯ�ϴ� �޼���
    public static float GetCurrentHP()
    {
        return currentHP;
    }

    /*// �÷��̾��� HP�� ������Ű�� �޼���
    public void IncreaseHP(int amount)
    {
        currentHP += amount;

        // �ִ� HP�� ���� �ʵ��� ����
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
    }*/

    public static void EatHealItem()
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
            currentHP = 0;
            PlayerDeath();
        }
    }

    // �÷��̾ ����� ��� ó���ϴ� �޼���
    private static void PlayerDeath()
    {
        // ��� ó�� ������ �ۼ��ϸ� �˴ϴ�. (��: ���� ����, ������ ��)
        // ���⿡ ��� ó���� �����ϸ� �˴ϴ�.
    }
}