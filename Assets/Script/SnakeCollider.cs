using UnityEngine;


public class SnakeCollider : MonoBehaviour
{
    public GameObject Snake;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (!Snake.activeSelf)
            {
                Snake.SetActive(true);
            }
        }
    }


}


