using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.VFX;

public class ItemPool : MonoBehaviour
{
    public Item[] itemPrefab;
    private ObjectPool<Item> itemPool;
    private float spawnPer;
    
    private void Awake()
    {
        itemPool = new ObjectPool<Item>(
            CreateItem,
            Get,
            OnRelease,
            OnDestroyPoolObject,
            maxSize: 200);

        
    }

    private Item CreateItem()
    {
        Item item = Instantiate(itemPrefab[UnityEngine.Random.Range(0, 3)]);
        item.SetPool(itemPool);
        return item;
    }

    private void Get(Item item)
    {
        item.gameObject.SetActive(true);
        item.transform.position = transform.position;
    }

    private void OnRelease(Item item)
    {
        item.gameObject.SetActive(false);
    }

    private void OnDestroyPoolObject(Item item)
    {
        Destroy(item.gameObject);
    }


    public void DropItem()
    {
        spawnPer = UnityEngine.Random.Range(0, 10);

        if (spawnPer >= 2)
        {
            itemPool.Get();
        }
    }
}
