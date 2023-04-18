using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityField : MonoBehaviour, IWeapon
{

    private static float elapsedTime;
    private static List<Monster> monster;
    public int atk;
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
           foreach (Monster m in monster) 
            {
                m.monsterHealth = m.monsterHealth - atk;
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
