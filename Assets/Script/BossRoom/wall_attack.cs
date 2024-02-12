using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall_attack : MonoBehaviour
{
    public GameObject bottom;
    public GameObject top;

    Transform[] b;
    Transform[] t;

    float timer;

    // Start is called before the first frame update
    void Start()
    {
        b = bottom.GetComponentsInChildren<Transform>();
        t = top.GetComponentsInChildren<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 5)
        {
            int a = Random.Range(0, b.Length - 1);
            GameObject b_attacker = b[a].gameObject;
            GameObject t_attacker = t[Random.Range(0, t.Length - 1)].gameObject;

            StartCoroutine(Fall(b_attacker, -1));
            StartCoroutine(Fall(t_attacker, 1));
            timer = 0;
        }
    }

    IEnumerator Fall(GameObject attacker, float gravity)
    {
        Vector3 origin = attacker.transform.position;

        attacker.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        attacker.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        attacker.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;

        attacker.GetComponent<Rigidbody2D>().gravityScale = gravity;
        attacker.GetComponent<Collider2D>().isTrigger = true;

        yield return new WaitForSeconds(3.0f);

        attacker.transform.position = origin;
        attacker.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;

        attacker.GetComponent<Rigidbody2D>().gravityScale = 0;
        attacker.GetComponent<Collider2D>().isTrigger = false;

    }
}
