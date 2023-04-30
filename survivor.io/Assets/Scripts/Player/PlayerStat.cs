using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    public PlayerData data;
    private void Awake()
    {
        data.Init();
    }
}
