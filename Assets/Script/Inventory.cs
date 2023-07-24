using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static int invenFilled = 0;
    public static GameObject[] invenArray = new GameObject[6];
    public static RectTransform[] transArray = new RectTransform[6];

    void Start()
    {
        for(int i=1; i<7; i++)
        {
            string invenName = $"Inventory{i}";
            GameObject inven= GameObject.Find(invenName);
            transArray[i-1] = inven.GetComponent<RectTransform>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void InventorySetting(bool add)
    {
        if(add)
        {
            GameObject newInven = Instantiate(invenArray[invenFilled], transArray[invenFilled].position, transArray[invenFilled].rotation);
            newInven.transform.SetParent(transArray[invenFilled]);
            invenFilled++;
        }
    }
}
