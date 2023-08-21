using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake_U : MonoBehaviour
{
    public float shootForce;
    public float bulletInterval;

    public GameObject bulletPrefab;
    public Animator animator;

    private bool canShoot;

    public AudioSource attckSound;

    void Start()
    {
        canShoot = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canShoot = true;
            animator.SetBool("attack", true);
            InvokeRepeating("ShootBullet", 0.5f, bulletInterval);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("attack", false);
            StopShooting();
        }
    }

    private void ShootBullet()
    {
        if (canShoot)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position + new Vector3(0, 2, 0), Quaternion.identity);

            Rigidbody2D rb2d = bullet.GetComponent<Rigidbody2D>();
            if (rb2d != null)
            {
                attckSound.Play();
                rb2d.AddForce(transform.up * shootForce, ForceMode2D.Impulse);
            }

            Destroy(bullet, 1f);
        }
    }

    private void StopShooting()
    {
        canShoot = false;
        CancelInvoke("ShootBullet");
    }

}