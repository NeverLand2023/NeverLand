using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_slime : MonoBehaviour
{
    Rigidbody2D rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
