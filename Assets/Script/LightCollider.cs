using UnityEngine;

public class LightCollider : MonoBehaviour
{
    public GameObject pointLight;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (pointLight != null)
            {
                pointLight.SetActive(true);
            }
            Destroy(gameObject);
        }
    }
}