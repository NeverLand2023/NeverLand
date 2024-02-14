using UnityEngine;
using UnityEngine.UI;

public class hp_Bar_b2Monster : MonoBehaviour
{
    public Slider slider;

    // HP 바의 최대 값
    public float maxHP = 200;
    public GameObject Monster;
    private int currentHP;

    public void Update()
    {
        B2_Monster monster = GetComponentInParent<B2_Monster>();
        if (monster != null)
        {
            currentHP = monster.GetHP();
        }

        slider.value = currentHP / maxHP;
    }

}