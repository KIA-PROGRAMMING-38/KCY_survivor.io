using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float InputX;
    private float InputY;
    public float _speed;
    private Rigidbody2D playerBody;
    // Start is called before the first frame update
    void Start()
    {
        
        playerBody = GetComponent<Rigidbody2D>();
       
    }
   
    // Update is called once per frame
    void Update()
    {
        InputX = Input.GetAxis("Horizontal");
        InputY = Input.GetAxis("Vertical");
        Vector2 pos = new Vector2(InputX * _speed, InputY * _speed);
        playerBody.velocity = pos;

        
    }
}
