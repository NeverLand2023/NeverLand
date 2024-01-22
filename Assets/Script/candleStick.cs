using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class candleStick : MonoBehaviour
{
    private UnityEngine.Rendering.Universal.Light2D candleLight;
    private Animator animator;
    private Collider2D[] hit;
    private Collider2D[] ghostHit;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.enabled = false;

        candleLight = gameObject.GetComponent<UnityEngine.Rendering.Universal.Light2D>();
        candleLight.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //촛대와 플레이어 충돌 감지
        hit = Physics2D.OverlapBoxAll(transform.position, new Vector2(2, 2.5f), 0);

        //촛대 불빛과 유령 충돌 감지
        ghostHit = Physics2D.OverlapCircleAll(transform.position, 6);
        foreach (Collider2D col in ghostHit)
        {
            Debug.Log(col.tag);
        }

        if (Array.Exists(hit, x => x.tag.Equals("Player")))
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                candleLight.enabled = true;
                animator.enabled = true;
                RemoveGhosts();
            }
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector2(2f, 2.5f));
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, 6);
    }

    void RemoveGhosts()
    {
        foreach(Collider2D col in ghostHit)
        {
            if(col.tag == "Monster")
            {
                col.gameObject.SetActive(false);
            }
        }
        Debug.Log("죽어라 유령");
    }
}
