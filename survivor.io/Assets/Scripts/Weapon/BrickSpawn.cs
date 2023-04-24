using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Pool;

public class BrickSpawn : MonoBehaviour
{

    public Brick brick;
    public WeaponData brickdata;
    private ObjectPool<Brick> brickPool;
    private WaitForSeconds instantCoolTime;
    private WaitForSeconds coolTime;
    private void Awake()
    {
        brickPool = new ObjectPool<Brick>(
            CreateBrick,
            Get,
            OnRelease,
            OnDestroyPoolObject,
            maxSize: 10);

        brickdata.Atk = 1;
        brickdata.Level = 1;
    }
    private void Start()
    {
        instantCoolTime = new WaitForSeconds(0.3f);
        coolTime = new WaitForSeconds(3.0f);
        StartCoroutine(brickAttack());
    }

    private Brick CreateBrick()
    {
        Brick bricks = Instantiate(brick, WeaponManager.Instance.weaponPos.transform);
        bricks.SetPool(brickPool);
        return bricks;
    }

    private void Get(Brick bricks)
    {
        bricks.gameObject.SetActive(true);
        bricks.transform.position = WeaponManager.Instance.weaponPos.transform.position;
    }

    private void OnRelease(Brick bricks)
    {
        bricks.gameObject.SetActive(false);
    }

    private void OnDestroyPoolObject(Brick bricks)
    {
        Destroy(bricks.gameObject);
    }

    private IEnumerator brickAttack()
    {
        while (true)
        {
            for (int i = 0; i < brickdata.Level; i++)
            {
                brickPool.Get();
                yield return instantCoolTime;
            }
            yield return coolTime;
        }
    }

   
}
