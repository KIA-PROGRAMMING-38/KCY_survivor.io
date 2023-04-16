using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityField : MonoBehaviour, IWeapon
{
   
    public void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(this, WeaponManager.Instance.weaponPos.transform);
        }
       
    }
}
