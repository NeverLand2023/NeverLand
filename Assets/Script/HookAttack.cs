using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookAttack : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("PlayerAttack"))
        {
            Debug.Log("ouch");
            BossSkeleton.MinusHP();
        }
    }
}
