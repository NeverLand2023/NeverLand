using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall_collider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            float player_hp = GameManager.GetCurrentHP();
            GameManager.DecreaseHP(player_hp / 3);
        }
    }
}
