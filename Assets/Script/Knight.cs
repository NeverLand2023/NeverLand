using System.Collections;
using UnityEngine;

public class Knight : MonoBehaviour
{
    public Animator animator; // Knight�� �ִϸ����� ������Ʈ
    public GameObject swordPrefab; // Sword ������
    public GameObject[] nextObjectPrefab; // ���� ������Ʈ ������
    public Transform playerTransform; // �÷��̾��� Transform
    public int hp = 200;
    public float attackRange;
    private int result = 0;

    void Start()
    {
        animator = GetComponent<Animator>();

        StartCoroutine(StartAttackSequence());
        StartCoroutine(DisappearAfterDelay());

        attackRange = 10;

        GameObject playerObject = GameObject.Find("Main_Hook"); // "PlayerObjectName"���� ���� �÷��̾� ������Ʈ�� �̸��� �־��ּ���.

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

        // attack �ִϸ��̼� ����
        animator.SetBool("Attack", true);

        yield return new WaitForSeconds(1f); // appear �ִϸ��̼��� ���̿� ���� ����

        while (true)
        {

            // �÷��̾� �������� sword ������ ����
            GameObject sword = Instantiate(swordPrefab, transform.position, Quaternion.identity);
            Vector2 direction = (playerTransform.position - transform.position).normalized;
            sword.GetComponent<Rigidbody2D>().velocity = direction * 5f;

            yield return new WaitForSeconds(2f); // 2�ʸ��� ����
        }
    }

    void Update()
    {
        // �÷��̾��� ���� ��� ������Ʈ
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
        yield return new WaitForSeconds(10f); // 10�� ���

        // disappear �ִϸ��̼� ����
        animator.SetTrigger("Disappear");

        yield return new WaitForSeconds(0.5f); // disappear �ִϸ��̼��� ���̿� ���� ����

        // ���� ������Ʈ ����
        result = Random.Range(0, 2);
        GameObject newObject = Instantiate(nextObjectPrefab[result], transform.position, Quaternion.identity);

        B2_Monster monster = GetComponentInParent<B2_Monster>();
        if (monster != null)
        {
            monster.SetHP(hp);
        }

        // ���� ������Ʈ ����
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