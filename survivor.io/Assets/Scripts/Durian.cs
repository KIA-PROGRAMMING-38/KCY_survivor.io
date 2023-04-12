using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Durian : MonoBehaviour, IWeapon
{
    Rigidbody2D rigid;
    public float speed;
    private Vector2 movePos;
    private Vector2 rightNormalVec;
    private Vector2 leftNormalVec;
    private Vector2 upNormalVec;
    private Vector2 downNormalVec;
   
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        movePos = new Vector2(speed, speed);
        rightNormalVec = new Vector2(1, 0);
        leftNormalVec= new Vector2(-1, 0);
        upNormalVec = new Vector2(0, 1);
        downNormalVec = new Vector2(0, -1);
    }
    public void Attack()
    {
        rigid.velocity = movePos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "AngleSideX":
               if (this.transform.position.x < collision.transform.position.x)
                {
                    Vector2 incomingVector = movePos.normalized;
                    Vector2 reflectXVector = Vector2.Reflect(incomingVector, leftNormalVec);
                    movePos = reflectXVector.normalized * speed;
                  
                }

                if (this.transform.position.x > collision.transform.position.x)
                {
                    Vector2 incomingVector = movePos.normalized;
                    Vector2 reflectXVector = Vector2.Reflect(incomingVector, rightNormalVec);
                    movePos = reflectXVector.normalized * speed;
                }
                break;

            case "AngleSideY":
                if (this.transform.position.y < collision.transform.position.y)
                {
                    Vector2 incomingVector = movePos.normalized;
                    Vector2 reflectXVector = Vector2.Reflect(incomingVector, downNormalVec);
                    movePos = reflectXVector.normalized * speed;

                }

                if (this.transform.position.y > collision.transform.position.y)
                {
                    Vector2 incomingVector = movePos.normalized;
                    Vector2 reflectXVector = Vector2.Reflect(incomingVector, upNormalVec);
                    movePos = reflectXVector.normalized * speed;
                }
                break;
        }
    }
}
