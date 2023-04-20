using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Item : MonoBehaviour
{
    public int AddExp;
    public ItemData itemData;
    public IObjectPool<Item> item1Pool;

    private void Start()
    {
        AddExp = itemData.Addexp;
    }

    public void SetPool(IObjectPool<Item> pool)
    {
        item1Pool = pool;
    }

    public void Ondead()
    {
        item1Pool.Release(this);
    }

    
}
