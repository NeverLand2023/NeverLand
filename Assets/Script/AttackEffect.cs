using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEffect : MonoBehaviour
{
    public GameObject hook;
    Transform transform;
    bool start = true;

    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // 초기 위치 설정
        if (start)
        {
            if (hook.GetComponent<SpriteRenderer>().flipX)
            {
                transform.localPosition = new Vector3(-0.25f, 0, 0);
            }
            else
            {
                transform.localPosition = new Vector3(0.25f, 0, 0);
            }
        }
        start = false;

    }

    void AttackEffectEnd()
    {
        start = true;
        hook.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        hook.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        gameObject.SetActive(false);
    }
}
