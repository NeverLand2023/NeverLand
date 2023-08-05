using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    public Slider slider;

    // HP 바의 최대 값 (플레이어의 최대 HP와 동일)
    public float maxHP;

    public void Update()
    {
        slider.value = GameManager.GetCurrentHP()/ maxHP;
        //Debug.Log("hp "+GameManager.GetCurrentHP());
    }

}