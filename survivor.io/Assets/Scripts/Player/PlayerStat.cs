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
        Debug.Log($"현재 레벨 : {data.Level}");
        Debug.Log($"현재 경험치 : {data.currentExp}");
        Debug.Log($"다음 레벨업 까지 :{data.maxExp}");
    }

    public void OnDead()
    {
        Time.timeScale = 0;
    }

   
    
   
}
