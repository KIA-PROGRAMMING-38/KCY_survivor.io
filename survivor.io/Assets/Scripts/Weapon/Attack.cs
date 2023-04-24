using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
  
    public GameObject defaultWeapon;

    private void Awake()
    {
        WeaponManager.Instance.Init();
        
    }
    void Start()
    {
        WeaponManager.Instance.Registration(defaultWeapon);
    }
}
