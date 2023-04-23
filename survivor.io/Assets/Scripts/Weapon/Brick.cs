using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;


public class Brick : MonoBehaviour, IWeapon
{
    private Rigidbody2D rigid;
    public float power;
    private float range;
    private Vector2 shootVec;
    private Monster monster;
    public WeaponData brickData;
    public IObjectPool<Brick> brickPool;
   
    // Start is called before the first frame update
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    public void SetPool(IObjectPool<Brick> pool)
    {
        brickPool = pool;
    }

    public void Ondead()
    {
        brickPool.Release(this);
    }
    
    private void OnEnable()
    {
        range = UnityEngine.Random.Range(-10, 10);
        shootVec = new Vector2(range, power);
        rigid.AddForce(shootVec, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Monster"))
            return;

        monster = collision.gameObject.GetComponent<Monster>();
        monster.monsterHealth -= brickData.Atk;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area"))
        {
            return;
        }
        Ondead();
    }

    public void Attack()
    {
        GameObject.Find("WeaponPos").transform.Find("brickPos").gameObject.SetActive(true);
    }
}

