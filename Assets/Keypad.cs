using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Keypad : MonoBehaviour
{

    Animator ani;

    List<int> input = new List<int>();
    List<int> answer = new List<int>() { 2, 0, 6 };

    public TMP_Text Num1;
    public TMP_Text Num2;
    public TMP_Text Num3;

    void Start()
    {
        ani = GetComponent<Animator>();

    }
    
    void Update()
    {
        Num1.text = (input.Count > 0) ? input[0].ToString() : "";
        Num2.text = (input.Count > 1) ? input[1].ToString() : "";
        Num3.text = (input.Count > 2) ? input[2].ToString() : "";
    }


    public void click_(int num)
    {
        ani.SetTrigger("click_"+num.ToString());
        if (input.Count < 3)
        {
            input.Add(num);
        }
    }

    public void click_0()
    {
        click_(0);
    }

    public void click_1()
    {
        click_(1);
    }

    public void click_2()
    {
        click_(2);
    }

    public void click_3()
    {
        click_(3);
    }

    public void click_4()
    {
        click_(4);
    }

    public void click_5()
    {
        click_(5);
    }

    public void click_6()
    {
        click_(6);
    }

    public void click_7()
    {
        click_(7);
    }

    public void click_8()
    {
        click_(8);
    }

    public void click_9()
    {
        click_(9);
    }

    public void click_c()
    {
        ani.SetTrigger("click_c");

        if (AreListsEqual(input, answer))
        {
            //성공
            Debug.Log("성공");
        }
        else
        {
            //실패
            Debug.Log("실패");
        }
        
    }

    public void click_x()
    {
        ani.SetTrigger("click_x");
        if (input.Count > 0)
        input.RemoveAt(input.Count - 1);
    }


    private bool AreListsEqual(List<int> a, List<int> b)
    {
        if (a.Count != b.Count)
        {
            return false;
        }

        for (int i = 0; i < a.Count; i++)
        {
            if (a[i] != b[i])
            {
                return false;
            }
        }

        return true;
    }
}
