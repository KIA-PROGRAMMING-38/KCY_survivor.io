using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Scaner : MonoBehaviour
{
    public float scanRange;
    public LayerMask targetLayer;
    public RaycastHit2D[] targets;
    public Transform targetPos;

    void FixedUpdate()
    {
        targets = Physics2D.CircleCastAll(transform.position, scanRange, Vector2.zero, 0, targetLayer);
        targetPos = GetNearest();

        Debug.Log(targetPos);
    }

    Transform GetNearest()
    {
        Transform result = null;

        float diff = 100;

        foreach (RaycastHit2D target in targets)
        {
            Vector2 myPos = transform.position;
            Vector2 targetPos = target.transform.position;

            float diffPos = Vector2.Distance(myPos,targetPos);

            if (diff > diffPos)
            {
                diff = diffPos;
                result = target.transform;
            }
        }

        return result;
    }
}
