using UnityEngine;

public class StairLock : MonoBehaviour
{

    private bool colState = false;
    private bool hasKey = true;

    private void Update()
    {
        // 스페이스바를 누르면
        if (colState && Input.GetKeyDown(KeyCode.Space))
        {
            //키 있는지 없는지 확인
            //has key = 
            if (hasKey)
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