using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GravityMove : MonoBehaviour
{
    public float angleSpeed;
   
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

  

}
