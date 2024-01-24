using UnityEngine;

public class StairLock : MonoBehaviour
{

    private bool colState = false;

    private void Update()
    {
        // 스페이스바를 누르면
        if (colState && Input.GetKeyDown(KeyCode.Space))
        {
            if (artwork.hasKey)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 충돌이 발생하면
        if (collision.gameObject.CompareTag("Player"))
        {
            colState = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // 충돌이 발생하면
        if (collision.gameObject.CompareTag("Player"))
        {
            colState = false;
        }
    }
}