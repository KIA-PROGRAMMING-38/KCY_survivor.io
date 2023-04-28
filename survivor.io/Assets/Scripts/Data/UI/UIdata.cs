using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UiData", menuName = "Scriptable Object Asset/UiData")]
public class UIdata : ScriptableObject
{
    public int killCount;
    public int stageGold;
    public int currentGold;

    public void Init()
    {
        stageGold = 0;
        killCount = 0;
    }
}
