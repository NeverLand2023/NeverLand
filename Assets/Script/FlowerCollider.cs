using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerCollider : MonoBehaviour
{
    public GameObject FlowerWall;
    private bool HookEnter = false;

    private void Update()
    {
        if (HookEnter && Input.GetKeyDown(KeyCode.Space))
        {
            FlowerWall.SetActive(false);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            HookEnter = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            HookEnter = false;
    }
}
