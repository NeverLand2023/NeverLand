using UnityEngine;

public class SwitchCollider : MonoBehaviour
{
    public GameObject switchCanvas; // Ȱ��ȭ�� SwitchCanvas ����
    private bool collisionState = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // �浹�� ������Ʈ�� "Player" �±����� Ȯ��
        {
            collisionState = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            switchCanvas.SetActive(false);
            Main_Hook.attackAvailable = true;
        }
    }

    void Update()
    {
        if (collisionState)
        {
            // Ư�� SwitchCanvas�� Ȱ��ȭ
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (switchCanvas != null)
                {
                    switchCanvas.SetActive(true);
                    Main_Hook.attackAvailable = false;
                }
            }
        }
    }
}