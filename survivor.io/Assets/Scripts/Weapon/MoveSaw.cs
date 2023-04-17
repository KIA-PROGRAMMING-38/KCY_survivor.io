using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSaw : MonoBehaviour
{
    public float angleSpeed;
   
   
    void Update()
    {
        transform.RotateAround(WeaponManager.Instance.weaponPos.transform.position, Vector3.back, angleSpeed);
    }
}
