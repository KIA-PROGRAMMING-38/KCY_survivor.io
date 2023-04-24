using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpBar : MonoBehaviour
{
    private Image myImage;
    public PlayerData playerData;

    private void Awake()
    {
        myImage = GetComponent<Image>();
    }
    void Start()
    {
        StartCoroutine(FillingBar());
    }

    IEnumerator FillingBar()
    {
        while (true)
        {
            myImage.fillAmount = playerData.currentExp / playerData.maxExp;
            yield return null;
        }
    }
}
