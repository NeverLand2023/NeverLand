using UnityEngine;

public class LightCollider : MonoBehaviour
{
    public GameObject pointLight;
    public static bool stillDark = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")&&stillDark)
        {
            if (pointLight != null)
            {
                pointLight.SetActive(true);
                Debug.Log("TooBright");
            }
            
        }

        if (other.CompareTag("Player")&&!stillDark)
        {
            pointLight.SetActive(false);
            Destroy(gameObject);
        }
    }
}