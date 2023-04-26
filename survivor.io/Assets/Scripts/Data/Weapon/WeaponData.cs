using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Scriptable Object Asset/WeaponStat")]
public class WeaponData : ScriptableObject
{
    public int Atk;
    public int Level;
    [TextArea]
    public string[] levelupText = new string[5]; // 무기별 설명

}
