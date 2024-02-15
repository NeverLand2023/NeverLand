using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterControl : MonoBehaviour
{
    public static int deadMonster = 0;
    public GameObject door;

    void Start()
    {
        
    }

    void Update()
    {
        if (deadMonster >= 6)
        {
            door.SetActive(true);
        }
    }
}
