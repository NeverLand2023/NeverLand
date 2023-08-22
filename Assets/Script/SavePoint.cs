using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
    public Color targetColor = new Color(1f, 0.216f, 0.216f);
    public int SavePointNum;
    private bool triggerEnter = false;

    void Start()
    {
        PlayerPrefs.SetInt("SavePointKey", 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            triggerEnter = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            triggerEnter = false;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && triggerEnter)
        {
            PlayerPrefs.SetFloat("SavePoint_x", transform.position.x);
            PlayerPrefs.SetFloat("SavePoint_y", transform.position.y);

            for(int i=0; i<Inventory.invenFilled; i++)
            {
                PlayerPrefs.SetString("Inventory_" + (i).ToString(), GameManager.invenArray[i].Item3);
            }
            PlayerPrefs.SetInt("InvenFilled", Inventory.invenFilled);

            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.color = targetColor;
            }
        }
    }
}