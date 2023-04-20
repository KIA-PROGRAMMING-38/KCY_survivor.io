using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;


public class BrickMove : MonoBehaviour
{
    private Rigidbody2D rigid;
    public float power;
    private float range;
    private Vector2 shootVec;
    public Stack<Brick> brickPool;
   
    // Start is called before the first frame update
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        brickPool = new Stack<Brick>();
    }
    
    private void OnEnable()
    {
        range = UnityEngine.Random.Range(-10, 10);
        shootVec = new Vector2(range, power);
        rigid.AddForce(shootVec, ForceMode2D.Impulse);
    }
}

