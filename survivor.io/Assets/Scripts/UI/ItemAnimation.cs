using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;

public class ItemAnimation : MonoBehaviour
{
    public DropItem[] DropItems;
    private ObjectPool<DropItem> dropItemPool;
    private WaitForSecondsRealtime spawnTime;
    private Vector3 spawnPos;
    private float spawnX;
    private RectTransform rectTransform;
    private Vector3 originScasle;
    

    private void Awake()
    {
        dropItemPool = new ObjectPool<DropItem>(
            CreateItem,
            Get,
            OnRelease,
            OnDestroyPoolObject,
            maxSize: 50);
        rectTransform = GetComponent<RectTransform>();
       
    }

    private void Start()
    {
        spawnTime = new WaitForSecondsRealtime(0.1f);
        spawnPos = new Vector3(spawnX, rectTransform.localPosition.y);
        originScasle = new Vector3(0.5f, 0.5f, 1f);
    }

    private DropItem CreateItem()
    {
        DropItem item = Instantiate(DropItems[UnityEngine.Random.Range(0, 3)],rectTransform);
        item.SetPool(dropItemPool);
        return item;
    }

    private void Get(DropItem item)
    {
        item.gameObject.SetActive(true);
        spawnX = Random.Range(-390f, 390f);
        spawnPos = new Vector3(spawnX, 0);
        item.rectTransform.localPosition = spawnPos;
        item.rectTransform.localScale = originScasle;
        
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
        StartCoroutine(SpawnAnimation());
    }

    private IEnumerator SpawnAnimation()
    {
        while (true)
        {
            dropItemPool.Get();
            yield return spawnTime;
        }
    }
}
