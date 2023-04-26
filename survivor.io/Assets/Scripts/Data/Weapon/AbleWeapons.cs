using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AbleWeapon", menuName = "Scriptable Object Asset/Able Weapons")]
public class AbleWeapons : ScriptableObject
{
    public List<GameObject> ableWeapons = new List<GameObject>();
}
