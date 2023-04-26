using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Monster : MonoBehaviour
{
    public IObjectPool<Monster> monsterPool;
    public MonsterData data;
    private new SpriteRenderer renderer;
    private Animator animator;
    private WaitForSeconds waitEnter;
    private WaitForSeconds waitStay;
    private WaitForSeconds deadAction;
    public bool isDead;
    public Rigidbody2D rigid;
    public int monsterHealth;
    public Collider2D coll;
    private Color defaultColor;
    private ItemPool itemPool;
   
    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        itemPool = GetComponentInChildren<ItemPool>();
    }

    
    private void Start()
    {
        waitEnter = new WaitForSeconds(0.2f);
        waitStay = new WaitForSeconds(0.5f);
        deadAction = new WaitForSeconds(0.8f);
        isDead = data.isDead;
        monsterHealth = data.Hp;
        defaultColor = new Color(1, 1, 1);
    }
    public void SetPool(IObjectPool<Monster> pool)
    {
        monsterPool = pool;
    }

    public void Ondead()
    {
        monsterPool.Release(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Weapon"))
            return;
        
        StartCoroutine(TakeDamageEnter());
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.CompareTag("Weapon"))
            return;

        StartCoroutine(TakeDamageStay());
    }



    IEnumerator TakeDamageEnter()
    {
        if (monsterHealth >= 0)
        {
            animator.SetTrigger("Hit");
            renderer.color = Color.gray;
            yield return waitEnter;
            renderer.color = defaultColor;
        }
        else
        {
            coll.isTrigger = true;
            rigid.constraints = RigidbodyConstraints2D.FreezeAll;
            StartCoroutine(DeadAction());
        }
    }

    IEnumerator TakeDamageStay()
    {
        if (monsterHealth >= 0)
        {
            renderer.color = Color.gray;
            yield return waitStay;
            renderer.color = defaultColor;
        }
        else
        {
            coll.isTrigger = true;
            rigid.constraints = RigidbodyConstraints2D.FreezeAll;
            StartCoroutine(DeadAction());
        }
    }

    IEnumerator DeadAction()
    {
        renderer.color = Color.gray;
        yield return waitStay;
        renderer.color = defaultColor;
        if (!isDead)
        {
            
            animator.SetTrigger("Dead");
            isDead = true;
        }

        yield return deadAction;
        itemPool.DropItem();
        Ondead();
    }
}
