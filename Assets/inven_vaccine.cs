using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class inven_vaccine : MonoBehaviour
{
    public GameObject inGameVaccine;
    public GameObject toinvenVaccine;
    public PcUI_control PcUIControl;
    private BoxCollider2D myCollider;

    private void Start()
    {
        myCollider = GetComponent<BoxCollider2D>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {

                Debug.Log("½¹");
                Inventory.InventorySend(toinvenVaccine, null, "Vaccine");
                SoundManager.instance.ItemSound.Play();
                myCollider.enabled = false;
                inGameVaccine.SetActive(false);

                PcUIControl.UInum = 3;


            }

        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
