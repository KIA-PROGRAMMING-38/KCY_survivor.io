using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

public class Dagger : IWeapon
{
    public void Attack()
    {
        Debug.Log("표창 공격");
    }
}

public class RevolutionDagger : IWeapon
{
    public void Attack() 
    {
        Debug.Log("진화 표창 공격");
    }
}
 

