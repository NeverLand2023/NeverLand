using UnityEngine;

public class MonsterCol : MonoBehaviour
{
    public GameObject readyObject;
    public GameObject monsterObject;
    private bool active = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!active && other.CompareTag("Player"))
        {
            Destroy(readyObject);
            monsterObject.SetActive(true);
            active = true;
        }
        else if (!active && other.CompareTag("PlayerAttack"))
        {
            Destroy(readyObject);
            monsterObject.SetActive(true);
            active = true;
        }
    }
}