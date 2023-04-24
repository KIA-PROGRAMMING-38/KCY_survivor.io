using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject player;
    public float gameTimer;
 
    private void Awake()
    {
        instance = this;
    }

}
