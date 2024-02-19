using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pw : MonoBehaviour
{

    public GameObject PW_INVENui;
    public GameObject PW_GAMEui;
    public GameObject Canvas;
    private BoxCollider2D myCollider;
    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<BoxCollider2D>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("들어간다");
                Canvas.SetActive(true);
                Inventory.InventorySend(PW_INVENui, null, "Password_note");
                PW_GAMEui.SetActive(false);
                myCollider.enabled = false;

                SoundManager.instance.ItemSound.Play();
                
            }

        }
        

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
