using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class DaggerSpawn : MonoBehaviour
{
    public Dagger dagger;
    public WeaponData daggerData;
    private ObjectPool<Dagger> daggerPool;
    private WaitForSeconds instantCoolTime;
    private WaitForSeconds coolTime;
    public Transform releasePoint;
   
   
    private void Awake()
    {
        daggerPool = new ObjectPool<Dagger>(
            CreateDagger,
            OnGet,
            OnRelease,
            OnDestroyPoolObject,
            maxSize: 50);

        daggerData.Atk = 10;
        daggerData.Level = 1;
        
    }
    void Start()
    {
        instantCoolTime = new WaitForSeconds(0.3f);
        coolTime = new WaitForSeconds(1.5f);
      
        StartCoroutine(daggerAttack());
    }

    private Dagger CreateDagger()
    {
        Dagger daggers = Instantiate(dagger, transform);
        daggers.SetPool(daggerPool);
        return daggers;
    }

    private void OnGet(Dagger daggers)
    {
        daggers.gameObject.SetActive(true);
        daggers.transform.position = transform.position;
    }

    private void OnRelease(Dagger daggers)
    {
        daggers.gameObject.SetActive(false);
    }

    private void OnDestroyPoolObject(Dagger daggers)
    {
        Destroy(daggers.gameObject);
    }
    
    private IEnumerator daggerAttack()
    {
        while (true)
        {
            for (int i = 0; i < daggerData.Level + 1; i++)
            {
                if (GameManager.instance.player.GetComponent<Scaner>().targetPos)
                {
                    daggerPool.Get();
                    
                    yield return instantCoolTime;
                }
            }
            yield return coolTime;
        }
    }

    
}
