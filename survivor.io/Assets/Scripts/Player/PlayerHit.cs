using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    public PlayerData playerData;
    public int maxHp;
    private Monster monster;
    public EventManager eventManager;

    private void Awake()
    {
        maxHp = playerData.Hp;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(!collision.CompareTag("Monster"))
        {
            return;
        }
        monster = collision.GetComponent<Monster>();
        playerData.Hp -= monster.data.Atk;


        if (playerData.Hp <= maxHp * 0.5f)
        {
            eventManager.playerHpHalf.Invoke();
        }
        if (playerData.Hp <= maxHp * 0.3f)
        {
            eventManager.playerHpLow.Invoke();
        }
        if (playerData.Hp <= 0)
        {
            eventManager.playerDead.Invoke();
        }
    }
}
