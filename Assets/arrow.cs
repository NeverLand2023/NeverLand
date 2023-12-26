using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{
    private bool collided = false;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("collided", false);
    }

    // �ٸ� �ݶ��̴��� �浹���� �� ȣ��Ǵ� �Լ�
    // �ٸ� �ݶ��̴��� �浹���� �� ȣ��Ǵ� �Լ�
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim.SetBool("collided", true);
            Debug.Log("�÷��̾�� �浹!");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        anim.SetBool("collided", false);
        collided = false;
    }
    // �� �����Ӹ��� ȣ��Ǵ� �Լ�
    private void Update()
    {
        // �߰����� ������ �ʿ��� ��� ���⿡ �ۼ�
    }
}
