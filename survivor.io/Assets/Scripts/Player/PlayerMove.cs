using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float InputX;
    private float InputY;
    public float _speed;
    private Rigidbody2D playerBody;

    private void Awake()
    {
        playerBody = GetComponent<Rigidbody2D>();
    }
   
    void Update()
    {
        InputX = Input.GetAxis("Horizontal");
        InputY = Input.GetAxis("Vertical");
        Vector2 pos = new Vector2(InputX, InputY).normalized * _speed;
        playerBody.velocity = pos;
    }
}
