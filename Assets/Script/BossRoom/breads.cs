using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breads : MonoBehaviour
{
    public GameObject bread_circle;
    public GameObject bread_linear;
    public GameObject bread_fan;

    float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        StartCoroutine("attack_1");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        // 3�ʿ� �ѹ��� ���� 1~3 �� �ϳ� �����ؼ� ����
        if(timer > 13)
        {
            int pattern_num = Random.Range(1, 4);
            switch (pattern_num)
            {
                case 1:
                    StartCoroutine("attack_1");
                    break;
                case 2:
                    StartCoroutine("attack_2");
                    break;
                case 3:
                    StartCoroutine("attack_3");
                    break;
            }
            timer = 0;
        }
           
    }

    IEnumerator attack_1()
    {
        // ��ä��
        //GameObject fan = Instantiate(bread_fan, transform);
        bread_fan.SetActive(true);

        yield return new WaitForSeconds(10);

        //Destroy(fan);
        bread_fan.SetActive(false);
    }
    IEnumerator attack_2()
    {
        // ����
        //GameObject linear = Instantiate(bread_linear, transform);
        bread_linear.SetActive(true);

        yield return new WaitForSeconds(10);

        //Destroy(linear);
        bread_linear.SetActive(false);
    }

    IEnumerator attack_3()
    {
        // ���� �� ����
        //GameObject circle = Instantiate(bread_circle, transform);
        bread_circle.SetActive(true);

        yield return new WaitForSeconds(12);

        //Destroy(circle);
        bread_circle.SetActive(false);
    }
}
