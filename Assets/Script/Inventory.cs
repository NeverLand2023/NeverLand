using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour
{
    public GameObject inventory;
    public static int invenFilled = 0;
    public static RectTransform[] transArray = new RectTransform[6];

    private bool invenOpen;

    void Start()
    {
        invenOpen = false;
        //InventoryStart();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!invenOpen)
            {
                invenOpen=true;
                inventory.SetActive(true);
                InventoryStart();
            }
            else
            {
                invenOpen=false;
                inventory.SetActive(false);
            }
        }
        for (int i = 1; i <= 6; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha0 + i))
            {
                int index = i - 1;

                if (GameManager.invenArray[index].Item2 != null)
                {
                    GameObject clickInven = Instantiate(GameManager.invenArray[index].Item2, transform);
                    SoundManager.instance.playSFX(SoundManager.SFX.����_��ġ��, false);
                }                    
            }
        }
    }
    public static void InventoryStart()
    {
        for (int i = 1; i < 7; i++)
        {
            string invenName = $"Inventory{i}";
            GameObject inven = GameObject.Find(invenName);
            transArray[i - 1] = inven.GetComponent<RectTransform>();
        }
    }

    public static void InventorySend(GameObject invenObj, GameObject clickObj, string objName)
    {
        GameManager.invenArray[invenFilled] = new Tuple<GameObject, GameObject, string>(invenObj, clickObj, objName);
        Debug.Log(invenFilled + objName);
        InventorySetting();
    }

    public static void InventorySetting()
    {
        GameObject newInven = Instantiate(GameManager.invenArray[invenFilled].Item1, transArray[invenFilled].position, transArray[invenFilled].rotation);
        newInven.transform.SetParent(transArray[invenFilled]);
        invenFilled++;
        Debug.Log(invenFilled);

    }

}
