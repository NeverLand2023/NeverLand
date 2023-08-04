using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    public Slider slider;

    // HP ���� �ִ� �� (�÷��̾��� �ִ� HP�� ����)
    public float maxHP;

    public void Update()
    {
        slider.value = GameManager.GetCurrentHP()/ maxHP;
        //Debug.Log("hp "+GameManager.GetCurrentHP());
    }

}