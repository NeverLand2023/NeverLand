using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTurnOff : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pointLight;
    public static bool notYet = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")&&notYet)
        {
            if (pointLight != null)
            {
                pointLight.SetActive(false);
            }
            
        }

        if (other.CompareTag("Player") && !notYet)
        {
            pointLight.SetActive(false);
            Destroy(gameObject);
        }
    }
}
