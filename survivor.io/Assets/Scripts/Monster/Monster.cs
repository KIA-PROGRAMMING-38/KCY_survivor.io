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
    private WaitForSeconds wait;
    public bool isDead;
    public Rigidbody2D rigid;
    public int monsterHealth;
    public Collider2D coll;
    public float hitreact;
   
   

    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
    }

    
    private void Start()
    {
        wait = new WaitForSeconds(0.2f);
        isDead = data.isDead;
        monsterHealth = data.Hp;
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
        
        StartCoroutine(TakeDamage());
        

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.CompareTag("Weapon"))
            return;

       
        
    }

    IEnumerator TakeDamage()
    {
        if (monsterHealth >= 0)
        {

            animator.SetTrigger("Hit");
            renderer.color = Color.gray;
            yield return wait;
            
            renderer.color = new Color(1, 1, 1);
           
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
        if (!isDead)
        {
            animator.SetTrigger("Dead");
            isDead = true;
        }

        yield return new WaitForSeconds(1f); ;

        Ondead();
        
    }
}
