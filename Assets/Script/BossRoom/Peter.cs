using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peter : MonoBehaviour
{
    private static int hp = 200;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static float GetCurrentHP()
    {
        return hp;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "PlayerAttack")
        {
            hp -= 10;
        }
    }
}
