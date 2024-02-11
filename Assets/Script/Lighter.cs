using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighter : MonoBehaviour
{
    public GameObject lighter;
    public GameObject lighter_ui;

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
        if(collision.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Inventory.InventorySend(lighter_ui, null, "Lighter");
                SoundManager.instance.ItemSound.Play();
                lighter.SetActive(false);
            }
        }
    }
}
