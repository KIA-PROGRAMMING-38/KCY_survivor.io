using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SetStageUI : MonoBehaviour
{
   
    public TMP_Text killCountText;
    public TMP_Text resultKillCount;
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
            resultKillCount.text = data.killCount.ToString();
            yield return null;
        }
    }


}
