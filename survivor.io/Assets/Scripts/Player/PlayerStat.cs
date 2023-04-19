using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    public PlayerData data;
    
    void Start()
    {
        data.Init();
    }
    private void Update()
    {
       if (data.Hp <=0 )
        {
            Time.timeScale = 0;
        }
    }

   
    
   
}
