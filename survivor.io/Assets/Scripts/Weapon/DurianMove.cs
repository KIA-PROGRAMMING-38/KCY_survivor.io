using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DurianMove : MonoBehaviour
{
    private Rigidbody2D rigid;
    public float speed;
    public float angleSpeed;
    private Vector2 movePos;
    private Vector2 verticalNormalVec;
    private Vector2 horizontalNormalVec;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {

        movePos = new Vector2(speed, speed);
        horizontalNormalVec = new Vector2(-1, 0);
        verticalNormalVec = new Vector2(0, -1);
        rigid.AddTorque(angleSpeed);

    }

    private void Update()
    {
        rigid.velocity = movePos;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "AngleSideX":
                Vector2 incomingVector = movePos.normalized;
                Vector2 reflectXVector = Vector2.Reflect(incomingVector, horizontalNormalVec);
                movePos = reflectXVector.normalized * speed;
                break;

            case "AngleSideY":
                Vector2 incomingYVector = movePos.normalized;
                Vector2 reflectYVector = Vector2.Reflect(incomingYVector, verticalNormalVec);
                movePos = reflectYVector.normalized * speed;
                break;
        }
    }
}
