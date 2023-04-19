using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GravityField : MonoBehaviour, IWeapon
{
    private static List<Monster>  monster;
    private float elapsedTime;
    public WeaponData gravityData;
    public void Attack()
    {
        if (monster == null)
        {
            monster = new List<Monster>();
        }
       
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(this, WeaponManager.Instance.weaponPos.transform);
        }
        elapsedTime += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Monster"))
            return;

        monster.Add(collision.GetComponent<Monster>());
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (elapsedTime >= 1)
        {
            foreach (Monster monster in monster)
            {
                monster.monsterHealth = monster.monsterHealth - gravityData.Atk;
            }
            elapsedTime = 0;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Monster"))
            return;

        monster.Remove(collision.GetComponent<Monster>());
    }


}
