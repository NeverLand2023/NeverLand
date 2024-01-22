using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hand : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator anim;

    public Transform player;
    public float payerposition;

    void Start()
    {
        //gameObject.SetActive(false);
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        anim.SetBool("idle", false);

    }

    // Update is called once per frame
    void Update()
    {
        

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.SetActive(true);
            anim.SetBool("idle", true);
     
        }
    }
   /* void idle()
    {
        anim.SetBool("idle",true);

    }*/
}
