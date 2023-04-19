using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MonsterData",menuName = "Scriptable Object Asset/MonsterStat")]
public class MonsterData : ScriptableObject
{

    public int Hp;
    public int Atk;
    public bool isDead;

}
