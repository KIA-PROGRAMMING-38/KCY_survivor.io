using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraceTarget : MonoBehaviour
{
    public Rigidbody2D target;
    private Rigidbody2D rigid;
    private new SpriteRenderer renderer;
    public float speed;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
    }


    void FixedUpdate()
    {
        Vector2 tracePos = target.transform.position - transform.position;
        rigid.MovePosition(rigid.position + tracePos.normalized * speed * Time.fixedDeltaTime);
        rigid.velocity = Vector2.zero;
    }
    private void LateUpdate()
    {
        if (target.transform.position.x - transform.position.x < 0)
        {
            renderer.flipX = true;
        }
        else
        {
            renderer.flipX = false;
        }
    }

    private void OnEnable()
    {
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
    }
}
