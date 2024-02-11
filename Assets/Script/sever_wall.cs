using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sever_wall : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip boom;
    public GameObject invisiblewall;

    public Rigidbody2D nextwall;
    public Collider2D bottomcollider;
    public Collider2D playerCollider;
    public Collider2D obstacle1;
    public Collider2D obstacle2;
    public Collider2D obstacle3;
    public Collider2D obstacle4;

    // Start is called before the first frame update
    void Start()
    {
        //audioSource = GetComponent<AudioSource>();
        audioSource = gameObject.AddComponent<AudioSource>();  // AudioSource ���� �߰�
        audioSource.clip = boom;
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), bottomcollider);
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), playerCollider, false);
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), obstacle1);
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), obstacle2);
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), obstacle3);
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), obstacle4);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "boom")
        {
            invisiblewall.SetActive(true);
            audioSource.Play();

        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.tag == "SimulatedOn")
        {
            nextwall.simulated = true;
            BoxCollider2D collider2D = nextwall.GetComponent<BoxCollider2D>();
            collider2D.enabled = true;
        }

    }

 
    // Update is called once per frame
    void Update()
    {
        
    }
}
