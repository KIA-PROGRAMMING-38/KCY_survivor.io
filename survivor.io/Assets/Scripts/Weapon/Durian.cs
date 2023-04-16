using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Durian : MonoBehaviour, IWeapon
{
    private bool isInstance;
    
    public void Attack()
    {
        if (!isInstance)
        {
            Instantiate(this, WeaponManager.Instance.weaponPos.transform);
            isInstance = true;
        }
      
    }

}
