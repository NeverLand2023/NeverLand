using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knight_bullet : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D bulletRigidbody;
    Transform playerPos; //�÷��̾� ��ġ
    Vector2 dir;

    void Start()
    {
        playerPos = GameObject.Find("Main_Hook").GetComponent<Transform>();
        dir = playerPos.position - transform.position;
        GetComponent<Rigidbody2D>().AddForce(dir.normalized * Time.deltaTime * 100000);

        Destroy(gameObject, 5f); //5�� �� �ı�

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
