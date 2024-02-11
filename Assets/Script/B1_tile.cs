using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B1_tile : MonoBehaviour
{
    public GameObject Obstacle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Obstacle.SetActive(true);
        }
    }
        void Update()
    {
        
    }
}
