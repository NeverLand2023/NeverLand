using UnityEngine;

public class Sword : MonoBehaviour
{
    public float rotationSpeed = 180f; // 회전 속도

    void Start()
    {
        // 3초 후에 자기 자신을 파괴
        Destroy(gameObject, 3f);
    }

    void Update()
    {
        // 회전 로직 추가
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // 플레이어와 충돌하면 자기 자신을 파괴
            Destroy(gameObject);
        }
    }
}