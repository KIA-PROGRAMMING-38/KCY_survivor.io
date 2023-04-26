using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GravitySpawn : MonoBehaviour
{
    public GravityField gravityField;
    public WeaponData weaponData;
    private GameObject gravity;
    private void Awake()
    {
        gravityField.transform.localScale = new Vector3(0.5f, 0.5f, 0);
        weaponData.Atk = 5;
        weaponData.Level = 1;

    }
    private void OnEnable()
    {
        gravity = Instantiate(gravityField,WeaponManager.Instance.weaponPos.transform).gameObject;
    }

    private void OnDisable()
    {
        Destroy(gravity);
    }
}
