using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Durian : MonoBehaviour, IWeapon
{
    private Monster monster;
    public WeaponData durianStat;
    private Durian durian;
    public void Attack()
    {
        if (durian == null)
        {
            durian = Instantiate(this, WeaponManager.Instance.weaponPos.transform);
        }  
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Monster"))
        {
            return;
        }
        monster = collision.gameObject.GetComponent<Monster>();
        monster.monsterHealth -= durianStat.Atk;
    }
}
