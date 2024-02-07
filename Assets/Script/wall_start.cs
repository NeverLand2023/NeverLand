using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall_start : MonoBehaviour
{

   // public GameObject firstwall;
    public Rigidbody2D firstwall;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            firstwall.simulated = true;
            BoxCollider2D collider2D = firstwall.GetComponent<BoxCollider2D>();
            collider2D.enabled = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
