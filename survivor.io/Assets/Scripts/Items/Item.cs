using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Item : MonoBehaviour
{
    public int AddExp;
    public ItemData itemData;
    public IObjectPool<Item> itemPool;

    private void Start()
    {
        AddExp = itemData.Addexp;
    }

    public void SetPool(IObjectPool<Item> pool)
    {
        itemPool = pool;
    }

    public void Ondead()
    {
        itemPool.Release(this);
    }

    
}
