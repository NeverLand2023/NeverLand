using UnityEngine;

public class Sword : MonoBehaviour
{
    public float rotationSpeed = 180f; // ȸ�� �ӵ�

    void Start()
    {
        // 3�� �Ŀ� �ڱ� �ڽ��� �ı�
        Destroy(gameObject, 3f);
    }

    void Update()
    {
        // ȸ�� ���� �߰�
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // �÷��̾�� �浹�ϸ� �ڱ� �ڽ��� �ı�
            Destroy(gameObject);
        }
    }
}