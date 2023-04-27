using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    public Image hpBar;
    public PlayerData playerData;
    private float maxHp;
    // Start is called before the first frame update
    void Start()
    {
        maxHp = playerData.Hp;
        StartCoroutine(FillingBar());
    }

    IEnumerator FillingBar() // 경험치 UI를 채워출 코루틴
    {
        while (true)
        {
            hpBar.fillAmount = playerData.Hp / maxHp;

            yield return null;
        }
    }

    public void HalfHp() // 플레이어의 체력이 절반 아래로 떨어질 때 호출될 함수
    {
        hpBar.color = Color.yellow;
    }

    public void LowHp() // 플레이어의 체력이 30% 아래로 떨어질 때 호출될 함수
    {
        hpBar.color = Color.red;
    }
   
}
