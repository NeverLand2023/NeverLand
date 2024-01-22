using UnityEngine;

public class LightCollider : MonoBehaviour
{
    public GameObject pointLight;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            if (pointLight != null)
            {
                pointLight.SetActive(true);
            }

            Destroy(this.gameObject);
        }
    }
}

