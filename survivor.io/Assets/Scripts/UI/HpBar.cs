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

    IEnumerator FillingBar()
    {
        while (true)
        {
            hpBar.fillAmount = playerData.Hp / maxHp;
            yield return null;
        }
    }
   
}
