using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityMove : MonoBehaviour
{
    public float angleSpeed;
    public float attackRange;
    private Transform[] childTransforms;

    private void Awake()
    {
        childTransforms = GetComponentsInChildren<Transform>();
    }
  
    private void Update()
    {
        childTransforms[1].Rotate(0, 0, angleSpeed);
        childTransforms[2].Rotate(0, 0, -angleSpeed);
        childTransforms[3].Rotate(0, 0, angleSpeed);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.CompareTag("Monster"))
            return;

        Debug.Log("몬스터 공격");
    }
}
