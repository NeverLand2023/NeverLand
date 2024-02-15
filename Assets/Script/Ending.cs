using UnityEngine;

public class Ending : MonoBehaviour
{
    public GameObject targetObject;
    public float delay = 18f;

    private float timer = 0f;
    private bool isTimerRunning = false;

    void Start()
    {
        // 스크립트가 활성화될 때 타이머를 시작합니다.
        StartTimer();
    }

    void Update()
    {
        // 타이머가 작동 중이면서, 딜레이 시간이 지나면 대상 오브젝트를 활성화합니다.
        if (isTimerRunning)
        {
            timer += Time.deltaTime;
            if (timer >= delay)
            {
                ActivateObject();
            }
        }
    }

    // 타이머를 시작하는 함수
    void StartTimer()
    {
        isTimerRunning = true;
    }

    // 대상 오브젝트를 활성화하는 함수
    void ActivateObject()
    {
        targetObject.SetActive(true);
        // 타이머를 멈춥니다. (원하는 경우)
        isTimerRunning = false;

    }

}