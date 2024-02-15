using UnityEngine;

public class Ending : MonoBehaviour
{
    public GameObject targetObject;
    public float delay = 18f;

    private float timer = 0f;
    private bool isTimerRunning = false;

    void Start()
    {
        // ��ũ��Ʈ�� Ȱ��ȭ�� �� Ÿ�̸Ӹ� �����մϴ�.
        StartTimer();
    }

    void Update()
    {
        // Ÿ�̸Ӱ� �۵� ���̸鼭, ������ �ð��� ������ ��� ������Ʈ�� Ȱ��ȭ�մϴ�.
        if (isTimerRunning)
        {
            timer += Time.deltaTime;
            if (timer >= delay)
            {
                ActivateObject();
            }
        }
    }

    // Ÿ�̸Ӹ� �����ϴ� �Լ�
    void StartTimer()
    {
        isTimerRunning = true;
    }

    // ��� ������Ʈ�� Ȱ��ȭ�ϴ� �Լ�
    void ActivateObject()
    {
        targetObject.SetActive(true);
        // Ÿ�̸Ӹ� ����ϴ�. (���ϴ� ���)
        isTimerRunning = false;

    }

}