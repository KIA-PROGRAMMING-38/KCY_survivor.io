using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Spwan : MonoBehaviour
{
    public Monster[] monsterPrefab;
    public Transform[] spawnPoint;
    private float elapsedTime;
    private ObjectPool<Monster> monsterPool;
    

    private void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
        monsterPool = new ObjectPool<Monster>(
            CreateMonster,
            Get,
            OnRelease,
            OnDestroyPoolObject,
            maxSize : 200);
    }

    private Monster CreateMonster()
    {
        Monster monster = Instantiate(monsterPrefab[Random.Range(0, 3)], spawnPoint[Random.Range(1,spawnPoint.Length)]);
        monster.SetPool(monsterPool);
        return monster;
    }

    private void Get(Monster monster)
    {
        monster.gameObject.SetActive(true);
    }

    private void OnRelease(Monster monster)
    {
        monster.gameObject.SetActive(false);
    }

    private void OnDestroyPoolObject(Monster monster)
    {
        Destroy(monster.gameObject);
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        GameManager.instance.gameTimer += Time.deltaTime;

        if (elapsedTime > (GameManager.instance.gameTimer > 10f ? 0.5f : 1f)) 
        {
            monsterPool.Get();
            elapsedTime = 0f;
        }
       
    }
   
    
   
}
