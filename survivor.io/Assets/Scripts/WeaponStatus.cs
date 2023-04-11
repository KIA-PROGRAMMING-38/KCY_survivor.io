using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStatus
{
    public float damage;
    public int per;
    public int index;

    public void Init(float damage, int per, int index)
    {
        this.damage = damage;
        this.per = per;
        this.index = index;
    }
}
