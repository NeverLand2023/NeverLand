using UnityEngine;

public class RotateAroundPoint : MonoBehaviour
{
    public Transform rotationCenter;  // ȸ�� �߽���
    public float rotationSpeed; // ȸ�� �ӵ� (90����)
    public float timeInterval;
    public bool isRotatingClockwise; // �ð���� ȸ�� ����
    public float damage;
    

    void Start()
    {
        // 4�ʸ��� RotateDirectionToggle �Լ��� �ݺ� ȣ��
        InvokeRepeating("RotateDirectionToggle", 0f, timeInterval);
    }

    void RotateDirectionToggle()
    {
        // ȸ�� ���� ����
        isRotatingClockwise = !isRotatingClockwise;
    }

    void Update()
    {
        // ȸ��
        RotateAround();
    }

    void RotateAround()
    {
        float direction = isRotatingClockwise ? 1f : -1f;

        // ���� ���� (0���� 360�� ���̷� ����)
        float currentRotation = Mathf.Repeat(transform.eulerAngles.z, 360f);

        // ��ǥ ȸ�� ���� ��� (90����)
        float targetRotation = currentRotation + (90f * direction);

        // ȸ�� �ӵ��� �ð��� ���� õõ�� ȸ��
        transform.RotateAround(rotationCenter.position, Vector3.back, rotationSpeed * direction * Time.deltaTime);

        // ȸ���� ��ǥ�� �����ϸ� �ݴ� �������� ����
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