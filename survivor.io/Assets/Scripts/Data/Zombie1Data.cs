using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Zombie1",menuName = "Scriptable Object Asset/Zombie1Stat")]
public class Zombie1Data : ScriptableObject
{
    public int Hp;
    public int Atk;
    public int knockBackPow;
    public bool isDead;
    public Rigidbody2D rigidbody2D;
}
