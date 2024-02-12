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
        if(peter_hp <= (200 * 0.3))
        {
            //3 page
            make_wall(wall_3p);
        }
        else if(peter_hp <= (200 * 0.7))
        {
            //2 page
            make_wall(wall_2p);
        }

    }

    void make_wall(GameObject wall)
    {
        //위에서 떨어지기
        wall.SetActive(true);

    }
}
