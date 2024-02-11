using UnityEngine;

public class RotateAroundPoint : MonoBehaviour
{
    public Transform rotationCenter;  // 회전 중심점
    public float rotationSpeed; // 회전 속도 (90도씩)
    public float timeInterval;
    public bool isRotatingClockwise; // 시계방향 회전 여부
    public float damage;
    

    void Start()
    {
        // 4초마다 RotateDirectionToggle 함수를 반복 호출
        InvokeRepeating("RotateDirectionToggle", 0f, timeInterval);
    }

    void RotateDirectionToggle()
    {
        // 회전 방향 변경
        isRotatingClockwise = !isRotatingClockwise;
    }

    void Update()
    {
        // 회전
        RotateAround();
    }

    void RotateAround()
    {
        float direction = isRotatingClockwise ? 1f : -1f;

        // 현재 각도 (0부터 360도 사이로 유지)
        float currentRotation = Mathf.Repeat(transform.eulerAngles.z, 360f);

        // 목표 회전 각도 계산 (90도씩)
        float targetRotation = currentRotation + (90f * direction);

        // 회전 속도와 시간을 곱해 천천히 회전
        transform.RotateAround(rotationCenter.position, Vector3.back, rotationSpeed * direction * Time.deltaTime);

        // 회전이 목표에 도달하면 반대 방향으로 변경
        //if ((direction > 0f && currentRotation >= targetRotation) || (direction < 0f && currentRotation <= targetRotation))
        //{
        //    isRotatingClockwise = !isRotatingClockwise;
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision");
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("player");
            GameManager.DecreaseHP(damage);
        }
    }
}