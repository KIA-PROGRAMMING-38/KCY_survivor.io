using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CountKill : MonoBehaviour
{
   
    public TMP_Text killCountText;
    public UIdata data;

    private void Awake()
    {
        data.Init();
    }
    private void Start()
    {
        StartCoroutine(setUI());
    }
    IEnumerator setUI()
    {
        while (true)
        {
            killCountText.text = data.killCount.ToString();
            yield return null;
        }
    }


}
