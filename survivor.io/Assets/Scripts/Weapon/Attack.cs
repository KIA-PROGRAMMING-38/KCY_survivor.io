using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
  
    public GameObject defaultWeapon;
    void Start()
    {
        WeaponManager.Instance.Init();
        WeaponManager.Instance.Registration(defaultWeapon);
    }

    
    void Update()
    {
        for (int i = 0; i < WeaponManager.Instance.weapons.Count; i++)
        {
            WeaponManager.Instance.strategy[i].Attack();
        }
    }


}
