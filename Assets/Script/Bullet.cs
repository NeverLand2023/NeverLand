using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.DecreaseHP(50f);
            GameObject mainHookObject = GameObject.Find("Main_Hook");
            mainHookObject.GetComponent<Animator>().SetTrigger("Hurt");
            Destroy(gameObject);
        }
    }
}
