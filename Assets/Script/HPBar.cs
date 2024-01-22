using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    public Slider slider;

    // HP 바의 최대 값
    public float maxHP;

    public enum Character
    {
        Hook,
        BossSlime,
        BossTree,
        BossSkeleton
    }

    public Character characterSelect;
    public void Update()
    {
        switch (characterSelect)
        {
            case Character.Hook:
                slider.value = GameManager.GetCurrentHP() / maxHP;
                break;
            case Character.BossSlime:
                slider.value = BossSlime.GetCurrentHP()/ maxHP;
                break;
            case Character.BossTree:
                slider.value = BossTree.GetCurrentHP() / maxHP;
                break;
            case Character.BossSkeleton:
                slider.value = BossSkeleton.GetCurrentHP() / maxHP;
                break;
            default:
                Debug.LogError("Character not selected");
                break;
        }
    }

}