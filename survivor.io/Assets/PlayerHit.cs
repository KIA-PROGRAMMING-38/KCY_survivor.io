using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    public PlayerData playerData;
    private Monster monster;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(playerData.Hp);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(!collision.CompareTag("Monster"))
        {
            return;
        }
        monster = collision.GetComponent<Monster>();
        playerData.Hp -= monster.data.Atk;
    }
}
