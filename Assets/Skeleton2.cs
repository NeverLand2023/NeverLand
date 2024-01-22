using System.Collections;
using UnityEngine;

public class Skeleton2 : MonoBehaviour
{
    public float MonsterHP = 100;
    Animator anim;
    public GameObject skeleton;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerAttack")
        {
            MonsterHP -= 30;

            if (MonsterHP <= 0)
            {
                anim.SetBool("die", true);

                // 1초 후에 DeleteSkeleton 함수 호출
                Invoke("DeleteSkeleton", 1f);
            }
        }
    }

    void DeleteSkeleton()
    {
        Destroy(skeleton);
    }
}
