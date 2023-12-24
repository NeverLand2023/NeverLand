using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEffect : MonoBehaviour
{
    public GameObject hook;
    Transform transform;

    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hook.GetComponent<SpriteRenderer>().flipX)
        {
            transform.localPosition = new Vector3(-0.35f, 0, 0);
        }
        else
        {
            transform.localPosition = new Vector3(0.35f, 0, 0);
        }
    }
    void AttackEffectEnd()
    {
        gameObject.SetActive(false);
    }
}
