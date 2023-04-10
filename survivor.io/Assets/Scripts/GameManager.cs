using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject player;
    public float gameTimer;
    public ObjectPool monsterPool;
    public ObjectPool weaponPool;

    private void Awake()
    {
        instance = this;
    }
}
