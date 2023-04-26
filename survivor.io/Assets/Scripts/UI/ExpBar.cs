using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExpBar : MonoBehaviour
{
    public Image expImage;
    public PlayerData playerData; // 플레이어 경험치정보
    public TMP_Text Mainlevel; // 메인 UI 레벨 표시 창
    public TMP_Text UpUILevel; // 레벨 업 UI 레벨 표시 창
  

    void Start()
    {
        StartCoroutine(FillingBar());
    }

    public void SetLevel()
    {
        Mainlevel.text = playerData.Level.ToString();
        UpUILevel.text = Mainlevel.text;
    }

    IEnumerator FillingBar()
    {
        while (true)
        {
            expImage.fillAmount = playerData.currentExp / playerData.maxExp;
            yield return null;
        }
    }
}
