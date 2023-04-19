using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
  
    public GameObject defaultWeapon;
    public GameObject secondWeapon;
    public GameObject thirdWeapon;
    public GameObject fourthWeapon;
   
    void Start()
    {
        WeaponManager.Instance.Init();
        WeaponManager.Instance.Registration(defaultWeapon);
        WeaponManager.Instance.Registration(secondWeapon);
        WeaponManager.Instance.Registration(thirdWeapon);
        WeaponManager.Instance.Registration(fourthWeapon);
    }

    
    void Update()
    {
        for (int i = 0; i < WeaponManager.Instance.weapons.Count; i++)
        {
            WeaponManager.Instance.strategy[i].Attack();
        }
    }


}
