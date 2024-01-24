using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class artwork : MonoBehaviour
{
    public GameObject art;
    public GameObject key_ui;
    public static bool hasKey = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Inventory.InventorySend(key_ui, null, "Key");
                hasKey = true;
                art.SetActive(false);
            }
        }
    }
}
