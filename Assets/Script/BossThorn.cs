using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossThorn : MonoBehaviour
{
    [Header("Preset Fields")]
    [SerializeField] private Animator animator;

    private bool warningDone = false;

    // Update is called once per frame
    void Update()
    {
        if (warningDone)
        {
            animator.SetBool("Attack", true);
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }

    }

    public void WarnAnimationEnd()
    {
        warningDone = true;
    }
    public void ThornAttackAnimationEnd()
    {
        Destroy(gameObject);
    }
}
