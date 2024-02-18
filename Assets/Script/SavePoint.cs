using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
    public Color targetColor = new Color(1f, 0.216f, 0.216f);
    public int SavePointNum;
    public int sceneNum;
    private bool triggerEnter = false;

    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private bool isChangingColor = false;

    void Start()
    {
        PlayerPrefs.SetInt("SavePointKey", 0);
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;

        PlayerPrefs.SetInt("MissionNunber", sceneNum);
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

    IEnumerator ChangeColorAndRestore()
    {
        if (spriteRenderer != null)
        {
            isChangingColor = true;
            spriteRenderer.color = targetColor;

            yield return new WaitForSeconds(2f);

            spriteRenderer.color = originalColor;
            isChangingColor = false;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && triggerEnter && !isChangingColor)
        {
            SetSavePoint();

            StartCoroutine(ChangeColorAndRestore());
        }
    }

    void SetSavePoint()
    {
        PlayerPrefs.SetFloat("SavePoint_x", transform.position.x);
        PlayerPrefs.SetFloat("SavePoint_y", transform.position.y);

        for (int i = 0; i < Inventory.invenFilled; i++)
        {
            PlayerPrefs.SetString("Inventory_" + (i).ToString(), GameManager.invenArray[i].Item3);
        }
        PlayerPrefs.SetInt("InvenFilled", Inventory.invenFilled);
        PlayerPrefs.SetInt("MissionNunber", sceneNum);
    }
}