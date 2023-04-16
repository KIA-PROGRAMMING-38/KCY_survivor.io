using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Monster : MonoBehaviour
{
    public IObjectPool<Monster> monsterPool;

    public void SetPool(IObjectPool<Monster> pool)
    {
        monsterPool = pool;
    }

    public void Ondead()
    {
        monsterPool.Release(this);
    }
}
