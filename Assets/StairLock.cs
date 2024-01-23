using UnityEngine;

public class StairLock : MonoBehaviour
{

    private bool colState = false;
    private bool hasKey = true;

    private void Update()
    {
        // �����̽��ٸ� ������
        if (colState && Input.GetKeyDown(KeyCode.Space))
        {
            //Ű �ִ��� ������ Ȯ��
            //has key = 
            if (hasKey)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �浹�� �߻��ϸ�
        if (collision.gameObject.CompareTag("Player"))
        {
            colState = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // �浹�� �߻��ϸ�
        if (collision.gameObject.CompareTag("Player"))
        {
            colState = false;
        }
    }
}