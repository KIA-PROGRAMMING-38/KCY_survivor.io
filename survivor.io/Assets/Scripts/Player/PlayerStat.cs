using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    public PlayerData data;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        data.Init();
    }
    private void Update()
    {
        Debug.Log(data.currentExp);
    }
    // Update is called once per frame
   
}
