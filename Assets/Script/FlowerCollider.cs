using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerCollider : MonoBehaviour
{
    public GameObject FlowerWall;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        FlowerWall.SetActive(false);
    }
}
