using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpBar : MonoBehaviour
{
    public Image expImage;
    public PlayerData playerData; // �÷��̾� ����ġ����
  

    void Start()
    {
        StartCoroutine(FillingBar());
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
