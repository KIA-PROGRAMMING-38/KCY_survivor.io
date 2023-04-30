using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    public PlayerData playerData;
    public int maxHp;
    private Monster monster;
    public EventManager eventManager;
    private ParticleSystem blood;

    private void Awake()
    {
        maxHp = playerData.Hp;
        blood = GetComponentInChildren<ParticleSystem>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(!collision.gameObject.CompareTag("Monster"))
        {
            return;
        }
        monster = collision.gameObject.GetComponent<Monster>();
       
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Monster"))
        {
            return;
        }
        blood.Play();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Monster"))
        {
            return;
        }
        blood.Stop();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Monster"))
        {
            return;
        }
        blood.Stop();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Monster"))
        {
            return;
        }
        blood.Stop();
    }
}
