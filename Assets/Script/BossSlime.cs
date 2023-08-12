using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSlime : MonoBehaviour
{
    SpriteRenderer spriter;
    Animator anim;

    public GameObject player;
    public float distance;

    private void Awake()
    {
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        anim.SetFloat("Pdistance", distance);
        if(transform.position.x > player.transform.position.x)
        {
            spriter.flipX = true;
        }
        else
        {
            spriter.flipX = false;
        }
    }
}
