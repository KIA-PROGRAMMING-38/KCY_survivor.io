using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Pool;

public class Brick : MonoBehaviour, IWeapon
{
    private float elapsedTime;
    private static Stack<Brick> brickPool;
   
    public int atk;
   
    private Monster monster;
    private Brick brick;

   
    public void Attack()
    {
        if (brickPool == null)
        {
            brickPool = new Stack<Brick>();
           
            elapsedTime = 0;
             
        }
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= 3)
        {
            if (brickPool.Count == 0)
            {
                Instantiate(this, WeaponManager.Instance.weaponPos.transform);

                elapsedTime = 0;


            }
            else
            {
                brick = brickPool.Pop();
                brick.transform.position = WeaponManager.Instance.weaponPos.transform.position;
                brick.gameObject.SetActive(true);

                elapsedTime = 0;
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

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area"))
            return;
        gameObject.SetActive(false);
        brickPool.Push(this);
        
        
    }

   
      
  





}
