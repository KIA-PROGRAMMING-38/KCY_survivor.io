using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Scriptable Object Asset/PlayerStat")]
public class PlayerData : ScriptableObject
{
    public int Hp;
    public int Atk;
    public int Level;
    public bool isDead;
    public float currentExp;
    public float maxExp;

    public void Init()
    {
        Hp = 200;
        Level = 1;
        isDead = false;
        currentExp = 0;
        maxExp = 10;
    }

    public void LevelUp()
    {
        Level++;
        currentExp = currentExp - maxExp;
        maxExp = maxExp * 1.3f;
    }
}
