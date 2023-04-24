using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ExpBar : MonoBehaviour
{
    public PlayerData playerData;
    private Image expBar;

    private void Awake()
    {
        expBar = GetComponent<Image>();

    }

    private void Start()
    {
        StartCoroutine(FillingBar());
    }

    IEnumerator FillingBar()
    {
        while (true)
        {
            expBar.fillAmount = playerData.currentExp / playerData.maxExp;
            yield return null;
        }
    }
}
