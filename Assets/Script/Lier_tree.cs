using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lier_tree : MonoBehaviour
{
    SpriteRenderer spriter;

    int state = 0;

    void Awake()
    {
        spriter = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponentInParent<Lier_trees>().count == 0)
        {
            state = 0;
            spriter.color = new Color32(255, 255, 255, 255);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(state == 0)
            {
                state = 1;
                spriter.color = new Color32(100, 100, 100, 255);
                if (gameObject.name == "lier_tree1")
                {
                    GetComponentInParent<Lier_trees>().lier_tree1 *= -1;
                }
                else if (gameObject.name == "lier_tree4")
                {
                    GetComponentInParent<Lier_trees>().lier_tree4 *= -1;
                }
                GetComponentInParent<Lier_trees>().count++;
            }
            else
            {
                state = 0;
                spriter.color = new Color32(255, 255, 255, 255);
                if (gameObject.name == "lier_tree1")
                {
                    GetComponentInParent<Lier_trees>().lier_tree1 *= -1;
                }
                else if (gameObject.name == "lier_tree4")
                {
                    GetComponentInParent<Lier_trees>().lier_tree4 *= -1;
                }
                GetComponentInParent<Lier_trees>().count--;
            }
        }

    }
}
