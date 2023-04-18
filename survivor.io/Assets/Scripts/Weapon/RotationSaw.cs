using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class RotationSaw : MonoBehaviour, IWeapon
{
    public int level;
    private Vector3 movePos;
    public float radius;
    private int atk;
    private Monster monster;

    private void Start()
    {
        level = 1;
        atk = 1;

    }

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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Monster"))
            return;

        monster = collision.gameObject.GetComponent<Monster>();
        monster.monsterHealth -= atk;
    }
}
