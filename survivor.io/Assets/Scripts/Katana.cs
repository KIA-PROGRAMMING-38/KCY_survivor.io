using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

public class Katana : IWeapon
{
    public void Attack()
    {
        Debug.Log("카타나 공격");
    }
}

