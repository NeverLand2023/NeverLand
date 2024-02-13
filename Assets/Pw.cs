using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pw : MonoBehaviour
{

    public GameObject PW_ui;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Inventory.InventorySend(PW_ui, null, "Password_note");
                SoundManager.instance.ItemSound.Play();
            }
 
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
