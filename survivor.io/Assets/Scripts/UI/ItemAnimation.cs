using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ItemAnimation : MonoBehaviour
{
    public DropItem[] itemPrefab;
    private ObjectPool<DropItem> dropItemPool;
    private float spawnPer;

    private void Awake()
    {
        dropItemPool = new ObjectPool<DropItem>(
            CreateItem,
            Get,
            OnRelease,
            OnDestroyPoolObject,
            maxSize: 50);
    }

    private DropItem CreateItem()
    {
        DropItem item = Instantiate(itemPrefab[UnityEngine.Random.Range(0, 4)]);
        item.SetPool(dropItemPool);
        return item;
    }

    private void Get(DropItem item)
    {
        item.gameObject.SetActive(true);
        item.transform.position = transform.position;
    }

    private void OnRelease(DropItem item)
    {
        item.gameObject.SetActive(false);
    }

    private void OnDestroyPoolObject(DropItem item)
    {
        Destroy(item.gameObject);
    }

    private void OnEnable()
    {
        dropItemPool.Get();
    }
}
