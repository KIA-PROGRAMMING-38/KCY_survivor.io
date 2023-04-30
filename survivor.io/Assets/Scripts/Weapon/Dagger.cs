using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEngine.Pool;

public class Dagger : MonoBehaviour ,IWeapon, ILevelup
{
    private Rigidbody2D rigid;
    private Monster monster;
    private Transform target;
    public WeaponData daggerData;
    public PlayerData playerData;
    public float speed;
    public IObjectPool<Dagger> daggerPool;
    private Transform myPos;
    private GameObject spawner;
    private WaitForSeconds releaseTime;
    public float rotatePow;

    
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        myPos = GameManager.instance.player.transform;
        releaseTime = new WaitForSeconds(1.5f);
    }

    
    public void Attack()
    {
        spawner = GameObject.FindWithTag("WeaponPos").transform.Find("DaggerPos").gameObject;
        spawner.SetActive(true);
    }

    public void SetPool(IObjectPool<Dagger> pool)
    {
        daggerPool = pool;
    }

    public void Ondead()
    {
        daggerPool.Release(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Monster"))
        {
            return;
        }
        monster = collision.GetComponent<Monster>();
        monster.monsterHealth -= daggerData.Atk * playerData.Atk;

        
    }

    private void OnEnable()
    {
        rigid.AddTorque(rotatePow);
        target = GameManager.instance.player.GetComponent<Scaner>().targetPos;
        rigid.velocity = (target.position - myPos.position).normalized * speed;
        StartCoroutine(release());
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area"))
        {
            return;
        }
        
    }

    public void LevelUp()
    {
        daggerData.Level++;
    }

    IEnumerator release()
    {
        yield return releaseTime;
        Ondead();
    }
}


 

