using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class RotationSaw : MonoBehaviour, IWeapon
{
    public int level;
    Vector3 movePos;
    public float radius;
    

    public void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float angle = Mathf.PI * 2;
            for (int i = 1; i <= level + 1; i ++)
            {
                movePos = new Vector3(Mathf.Cos(angle / (level + 1) * i),
               Mathf.Sin(angle / (level + 1) * i)).normalized;
                Instantiate(this, WeaponManager.Instance.weaponPos.transform).transform.position += movePos * radius;

            }
           
            

        }
        

    }
}
