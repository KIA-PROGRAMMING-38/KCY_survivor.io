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

        if (elapsedTime > 0.5f)
        {
            Spawn();
            elapsedTime = 0f;
        }
    }

    private void Spawn()
    {
        GameObject monster = GameManager.instance.pool.Get(Random.Range(0, 4));
        monster.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
    }

   
}
