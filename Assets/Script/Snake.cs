using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public float shootForce;

    public GameObject bulletPrefab;
    public Animator animator;

    private bool attackEnd;

    void Start()
    {
        attackEnd = true;
        Attack();
    }

    void Update()
    {
      
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && attackEnd)
        {
            Attack();
        }
    }

    void Attack()
    {
        attackEnd = false;
        animator.SetBool("idle", false);
        animator.SetBool("attack", true);
        StartCoroutine(Shoot(0.3f));
    }

    
    IEnumerator Shoot(float delay)
    {
        yield return new WaitForSeconds(delay);

        animator.SetBool("idle", true);
        animator.SetBool("attack", false);

        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        Rigidbody2D rb2d = bullet.GetComponent<Rigidbody2D>();
        if (rb2d != null)
        {
            rb2d.AddForce(-transform.up * shootForce, ForceMode2D.Impulse);
        }
        attackEnd = true;

        Destroy(bullet, 2f);
    }
}
