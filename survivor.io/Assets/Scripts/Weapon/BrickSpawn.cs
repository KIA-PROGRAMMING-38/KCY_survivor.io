using Cysharp.Threading.Tasks;
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
    private const float INSTANT_COOLTIME = 0.3f;
    private const float COOLTIME = 3f;
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
        BrickAttack().Forget();
    }

    private Brick CreateBrick()
    {
        Brick bricks = Instantiate(brick, transform);
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

   
    private async UniTaskVoid BrickAttack()
    {
        while (true)
        {
            for (int i = 0; i < brickdata.Level; i++)
            {
                brickPool.Get();
                await UniTask.Delay(TimeSpan.FromSeconds(INSTANT_COOLTIME));
            }
            await UniTask.Delay(TimeSpan.FromSeconds(COOLTIME));
        }
    }
   
}
