using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickedInventoryItem : MonoBehaviour
{
    private float time = 0;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time >= 3f)
        {
            Destroy(gameObject);
        }
    }
}
