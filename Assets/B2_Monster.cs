using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B2_Monster : MonoBehaviour
{
    private int currnetHP = 200;


    public void SetHP(int hp)
    {
        currnetHP = hp;
    }

    public int GetHP()
    {
        return currnetHP;
    }

}
