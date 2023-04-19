using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Durian : MonoBehaviour, IWeapon
{
    public void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(this, WeaponManager.Instance.weaponPos.transform);
            
        }
      
    }
}
