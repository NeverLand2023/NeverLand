using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class black_monsters : MonoBehaviour
{
    public GameObject black_monster;
    public GameObject bossArea;

    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 30)
        {
            Spawn();
            timer = 0;
        }
    }

    void Spawn()
    {
        BoxCollider2D area = bossArea.GetComponent<BoxCollider2D>();

        float range_x = area.bounds.size.x;
        float range_y = area.bounds.size.y;

        for(int i = 0; i < 3; i++)
        {
            float x = Random.Range((range_x / 2) * (-1), range_x / 2);
            float y = Random.Range((range_y / 2) * (-1), range_y / 2);
            Vector3 position = new Vector3(x, y, 0);
            GameObject monster = Instantiate(black_monster, gameObject.transform);
            monster.transform.position = bossArea.transform.position + position;
        }
        
    }
}
