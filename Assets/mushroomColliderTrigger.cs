using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mushroomColliderTrigger : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("mushroomTrigger");
        if (other.CompareTag("Player"))
        {
            foreach (Transform child in gameObject.transform)
            {
                mushroom mushroom = child.GetComponent<mushroom>();
                mushroom.TurnOn();
            }
        }
    }

}
