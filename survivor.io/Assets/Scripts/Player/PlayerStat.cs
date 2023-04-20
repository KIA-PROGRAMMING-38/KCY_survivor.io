using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    public PlayerData data;
    public EventManager eventManager;
    
    void Start()
    {
        data.Init();
      
    }
    private void Update()
    {
       
       if (data.Hp <= 0)
        {
            eventManager.playerDead.Invoke();
        }

       if (data.currentExp > data.maxExp)
        {
            data.LevelUp();
        }
        Debug.Log($"���� ���� : {data.Level}");
        Debug.Log($"���� ����ġ : {data.currentExp}");
        Debug.Log($"���� ������ ���� :{data.maxExp}");
    }

    public void OnDead()
    {
        Time.timeScale = 0;
    }

   
    
   
}
