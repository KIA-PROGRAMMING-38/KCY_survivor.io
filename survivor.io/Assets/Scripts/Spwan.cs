using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spwan : MonoBehaviour
{
    public Transform[] spawnPoint;
    float elapsedTime;

    private void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
    }
   
    void Update()
    {
        elapsedTime += Time.deltaTime;
        GameManager.instance.gameTimer += Time.deltaTime;

        if (elapsedTime > (GameManager.instance.gameTimer > 10f ? 0.5f : 1f)) 
        {
            Spawn();
            elapsedTime = 0f;
        }
    }

    private void Spawn()
    {
        GameObject monster = GameManager.instance.monsterPool.Get(Random.Range(0, 4),this.transform);
        monster.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
        
    }

   
}
