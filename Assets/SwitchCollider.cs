using UnityEngine;

public class SwitchCollider : MonoBehaviour
{
    public GameObject switchCanvas; // 활성화할 SwitchCanvas 참조
    private bool collisionState = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // 충돌한 오브젝트가 "Player" 태그인지 확인
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
            // 특정 SwitchCanvas를 활성화
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