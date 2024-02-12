using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
 

    }

    // Update is called once per frame
    void Update()
    {


    }

    public static IEnumerator make_wall(GameObject wall)
    {
        //위에서 떨어지기
        Rigidbody2D[] new_walls = wall.GetComponentsInChildren<Rigidbody2D>();

        foreach(Rigidbody2D w in new_walls)
        {
            w.gravityScale = 1;
        }

        yield return new WaitForSeconds(3);

        foreach (Rigidbody2D w in new_walls)
        {
            w.gravityScale = 0;
            w.constraints = RigidbodyConstraints2D.FreezeAll;
        }

    }

    public static IEnumerator random_fall()
    {
        Rigidbody2D[] walls = GameObject.Find("walls").GetComponentsInChildren<Rigidbody2D>();
        Debug.Log(walls.Length);
        int num = Random.Range(0, walls.Length);
        Vector3 origin = walls[num].GetComponent<Transform>().position;
        walls[num].GetComponentInChildren<Collider2D>(true).gameObject.SetActive(true);

        walls[num].constraints = RigidbodyConstraints2D.None;
        walls[num].constraints = RigidbodyConstraints2D.FreezeRotation;
        walls[num].constraints = RigidbodyConstraints2D.FreezePositionX;
        walls[num].gravityScale = 1;


        yield return new WaitForSeconds(3);


        walls[num].GetComponent<Transform>().position = origin;
        walls[num].GetComponentInChildren<Collider2D>(true).gameObject.SetActive(false);
        walls[num].gravityScale = 0;
        walls[num].constraints = RigidbodyConstraints2D.FreezeAll;

    }
}
