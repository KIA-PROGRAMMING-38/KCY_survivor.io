using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    public PlayerData playerData;
    private Monster monster;
    public EventManager eventManager;
   
   
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(!collision.CompareTag("Monster"))
        {
            return;
        }
        monster = collision.GetComponent<Monster>();
        playerData.Hp -= monster.data.Atk;

        if (playerData.Hp <= 0)
        {
           // eventManager.playerDead.Invoke();
        }
    }
}
