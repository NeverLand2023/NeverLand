using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class server_machine : MonoBehaviour
{
    bool isWake;
    Vector3 origin;
    public GameObject bottom;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        isWake = true;
        origin = transform.position;
        transform.position += new Vector3(0, 15, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (isWake)
        {
            Debug.Log(1);
            transform.position += new Vector3(0, -0.1f, 0);

            if(transform.position.y < origin.y)
            {
                transform.position = origin;
                isWake = false;

                Collider2D[] col = bottom.GetComponentsInChildren<Collider2D>();
                foreach(Collider2D col2 in col)
                {
                    col2.isTrigger = false;
                }
            }

        }

    }
}
