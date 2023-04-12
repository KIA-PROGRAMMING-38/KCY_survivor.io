using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEngine.Pool;

public class Dagger : MonoBehaviour ,IWeapon
{
    public float speed;
    private IObjectPool<Dagger> daggerPool;
    public void Attack()
    {
        Debug.Log("표창 공격");
    }

    public void SetPool(IObjectPool<Dagger> pool)
    {
        daggerPool = pool;
    }

    public void DestroyObj()
    {
        daggerPool.Release(this);
    }
}


 

