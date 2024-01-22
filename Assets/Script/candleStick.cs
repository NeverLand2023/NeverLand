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

    public static bool playerEnter;

    // Start is called before the first frame update
    void Start()
    {
        playerEnter = false;

        animator = GetComponent<Animator>();
        animator.enabled = false;

        candleLight = gameObject.GetComponent<UnityEngine.Rendering.Universal.Light2D>();
        candleLight.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //�д�� �÷��̾� �浹 ����
        hit = Physics2D.OverlapBoxAll(transform.position, new Vector2(2, 2.5f), 0);

        //�д� �Һ��� ���� �浹 ����
        ghostHit = Physics2D.OverlapCircleAll(transform.position, 4);

        if (Array.Exists(hit, x => x.tag.Equals("Player")))
        {
            playerEnter = true;

            if(Array.Exists(GameManager.invenArray, x => x.Item3 == "Lighter"))
            {
                if (Input.GetKeyUp(KeyCode.Space) && !candleLight.enabled)
                {
                    candleLight.enabled = true;
                    animator.enabled = true;
                    RemoveGhosts();
                }
            }
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector2(1.7f, 2.5f));
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, 4);
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
        Debug.Log("�׾�� ����");
    }
}
