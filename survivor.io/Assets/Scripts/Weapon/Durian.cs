using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Durian : MonoBehaviour, IWeapon
{
    private Monster monster;
    public WeaponData durianStat;
    public void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(this, WeaponManager.Instance.weaponPos.transform);
            
        }
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        monster = collision.gameObject.GetComponent<Monster>();
        
    }
}
