using System.Collections;
using UnityEngine;

public class Skeleton2 : MonoBehaviour
{
    private static int MonsterHP = 200;
    Animator anim;
    public GameObject skeleton;
    public GameObject hands;

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

    public static float GetCurrentHP()
    {
        return MonsterHP;
    }

    void DeleteSkeleton()
    {
        Destroy(hands);
        Destroy(skeleton);
        

    }
}
