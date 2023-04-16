using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Brick : MonoBehaviour, IWeapon
{
    private float elapsedTime;

    public void Attack()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= 2)
        {
            Instantiate(this, WeaponManager.Instance.weaponPos.transform);
            elapsedTime = 0;
        }
    }
}
