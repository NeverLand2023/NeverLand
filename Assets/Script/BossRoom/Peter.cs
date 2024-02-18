using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Peter : MonoBehaviour
{
    public GameObject wall_2p;
    public GameObject wall_3p;
    public GameObject black_monster;
    public GameObject breads;

    private static int hp = 200;
    bool start_1;
    bool start_2;
    bool start_3;
    bool dead;
    float timer;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        start_1 = false;
        start_2 = false;
        start_3 = false;
        dead = false;
        timer = 0;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            if (!dead)
            {
                StartCoroutine("peter_dead");
                dead = true;
            }
        }
        else if (hp < 200 * 0.3)
        {
            if (!start_3)
            {
                start_3 = true;
                Page_3();
                StartCoroutine(wall.random_fall());
            }

            timer += Time.deltaTime;
            if(timer > 5)
            {
                //벽 공격
                StartCoroutine(wall.random_fall());
                timer = 0;
            }
        }
        else if(hp < 200 * 0.7)
        {
            if (!start_2)
            {
                start_2 = true;
                Page_2();
            }
        }
        else if(hp < 200)
        {
            if (!start_1)
            {
                start_1 = true;
                Page_1();
            }
        }

    }
    public static float GetCurrentHP()
    {
        return hp;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerAttack")
        {
            hp -= 5;
        }
    }

    private void Page_1()
    {
        animator.SetBool("red_cut", true);
        SoundManager.instance.wire.Play();

        // 잡몹 등장
        black_monster.SetActive(true);
    }

    private void Page_2()
    {
        animator.SetBool("yellow_cut", true);
        SoundManager.instance.wire.Play();
        StartCoroutine(wall.make_wall(wall_2p));

        // 전기구슬 공격
        breads.SetActive(true);
    }

    private void Page_3()
    {
        black_monster.SetActive(false);
        breads.SetActive(false);
        animator.SetBool("green_cut", true);
        SoundManager.instance.wire.Play();
        StartCoroutine(wall.make_wall(wall_3p));
    }

    IEnumerator peter_dead()
    {
        SoundManager.instance.peter_explosion.Play();
        animator.SetBool("break", true);

        yield return new WaitForSeconds(5);

        SceneManager.LoadScene("end_news");
    }
}
