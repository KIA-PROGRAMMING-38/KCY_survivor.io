using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;


public class AcquiredItem : MonoBehaviour
{
    private Item item;
    public PlayerData playerData;
    public Rigidbody2D rigid;
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Item"))
        {
            return;
        }

        item = collision.GetComponent<Item>();
        rigid = collision.GetComponent<Rigidbody2D>();
        playerData.currentExp += item.AddExp;
        item.itemPool.Release(item);
        
    }
}
