using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lier_trees : MonoBehaviour
{
    public int lier_tree1 = -1;
    public int lier_tree4 = -1;
    public int count = 0;
    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (count == 2)
        {
            timer += Time.deltaTime;
            if(timer > 2f)
            {
                if (lier_tree1 == 1 && lier_tree4 == 1)
                {

                }
                else
                {
                    GameObject.Find("Main_Hook").transform.position = new Vector2(10, 129);
                    lier_tree1 = -1;
                    lier_tree4 = -1;
                    count = 0;
                    timer = 0;
                }
            }

        }
    }
}
