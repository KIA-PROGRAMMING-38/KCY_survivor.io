using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Durian : MonoBehaviour, IWeapon
{
    private bool isInstance;
    private int atk;
    private Monster monster;

    private void Start()
    {
        atk = 1;
        isInstance = false;
    }

    public void Attack()
    {
        if (!isInstance)
        {
            Instantiate(this, WeaponManager.Instance.weaponPos.transform);
            isInstance = true;
        }
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Monster"))
            return;

        monster = collision.gameObject.GetComponent<Monster>();
        monster.monsterHealth -= atk;
    }

}
