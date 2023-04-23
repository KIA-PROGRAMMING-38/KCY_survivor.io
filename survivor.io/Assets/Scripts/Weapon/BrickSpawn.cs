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
    private void Awake()
    {
        brickPool = new ObjectPool<Brick>(
            CreateBrick,
            Get,
            OnRelease,
            OnDestroyPoolObject,
            maxSize: 10);
    }
    private void Start()
    {
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
                yield return new WaitForSeconds(0.3f);
            }
            yield return new WaitForSeconds(3f);
        }
    }












}
