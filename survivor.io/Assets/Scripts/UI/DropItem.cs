using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class DropItem : MonoBehaviour
{
    public IObjectPool<DropItem> dropItempool;

    public void SetPool(IObjectPool<DropItem> pool)
    {
        dropItempool = pool;
    }

    public void Ondead()
    {
        dropItempool.Release(this);
    }


}
