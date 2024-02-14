using System.Collections;
using UnityEngine;

public class Knight : MonoBehaviour
{
    public Animator animator; // Knight의 애니메이터 컴포넌트
    public GameObject swordPrefab; // Sword 프리팹
    public GameObject[] nextObjectPrefab; // 다음 오브젝트 프리팹
    public Transform playerTransform; // 플레이어의 Transform
    public int hp = 200;
    public float attackRange;
    private int result = 0;

    void Start()
    {
        animator = GetComponent<Animator>();

        StartCoroutine(StartAttackSequence());
        StartCoroutine(DisappearAfterDelay());

        attackRange = 10;

        GameObject playerObject = GameObject.Find("Main_Hook"); // "PlayerObjectName"에는 실제 플레이어 오브젝트의 이름을 넣어주세요.

        B2_Monster monster = GetComponentInParent<B2_Monster>();
        if (monster != null)
        {
            hp = monster.GetHP();
        }

        if (playerObject != null)
        {
            playerTransform = playerObject.transform;
        }
    }

    IEnumerator StartAttackSequence()
    {

        // attack 애니메이션 실행
        animator.SetBool("Attack", true);

        yield return new WaitForSeconds(1f); // appear 애니메이션의 길이에 맞춰 조절

        while (true)
        {

            // 플레이어 방향으로 sword 프리팹 생성
            GameObject sword = Instantiate(swordPrefab, transform.position, Quaternion.identity);
            Vector2 direction = (playerTransform.position - transform.position).normalized;
            sword.GetComponent<Rigidbody2D>().velocity = direction * 5f;

            yield return new WaitForSeconds(2f); // 2초마다 실행
        }
    }

    void Update()
    {
        // 플레이어의 방향 계속 업데이트
        Vector3 scale = transform.localScale;
        scale.x = Mathf.Sign(playerTransform.position.x - transform.position.x);
        transform.localScale = scale;

        Collider2D hitCollider = Physics2D.OverlapCircle(transform.position, attackRange, 1 << 3);

        if (hitCollider != null && hitCollider.tag == "PlayerAttack")
        {
            animator.SetTrigger("Hurt");
            hp -= 1;
        }

        if (hp <= 0)
        {
            animator.SetTrigger("Death");
        }

        B2_Monster monster = GetComponentInParent<B2_Monster>();
        if (monster != null)
        {
            monster.SetHP(hp);
        }
    }

    IEnumerator DisappearAfterDelay()
    {
        yield return new WaitForSeconds(10f); // 10초 대기

        // disappear 애니메이션 실행
        animator.SetTrigger("Disappear");

        yield return new WaitForSeconds(0.5f); // disappear 애니메이션의 길이에 맞춰 조절

        // 다음 오브젝트 생성
        result = Random.Range(0, 2);
        GameObject newObject = Instantiate(nextObjectPrefab[result], transform.position, Quaternion.identity);

        B2_Monster monster = GetComponentInParent<B2_Monster>();
        if (monster != null)
        {
            monster.SetHP(hp);
        }

        // 이전 오브젝트 제거
        if (newObject != null)
        {
            newObject.transform.parent = transform.parent;
            Destroy(gameObject);
        }
    }


    public void Death()
    {
        Destroy(gameObject);
    }

}