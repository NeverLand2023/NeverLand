using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall : MonoBehaviour
{
    public GameObject wall_1p;
    public GameObject wall_2p;
    public GameObject wall_3p;

    // Start is called before the first frame update
    void Start()
    {
        make_wall(wall_1p);
    }

    // Update is called once per frame
    void Update()
    {
        float peter_hp = Peter.GetCurrentHP();

    }

    void make_wall(GameObject wall)
    {
        //위에서 떨어지기
        wall.SetActive(true);
        Vector3 origin = wall.transform.position;
        wall.transform.position += new Vector3(0, 15, 0);

        while(wall.transform.position.y > origin.y)
        {
            wall.transform.position = new Vector3(0, -0.5f, 0);
        }

        wall.transform.position = origin;

    }
}
