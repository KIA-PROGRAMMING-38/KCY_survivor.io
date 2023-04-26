using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Xml.Serialization;
using UnityEngine;

public class DurianSpawn : MonoBehaviour
{
    public WeaponData durianData;
    public Durian durian;
    private Durian currentDurian;

    private void Awake()
    {
        durian.transform.localScale = new Vector3(2f, 2f, 0);
        durianData.Atk = 3;
        durianData.Level = 1;
    }

    private void OnEnable()
    {
        currentDurian = Instantiate(durian,transform);
    }

    private void OnDisable()
    {
        Destroy(currentDurian.gameObject);
    }

}
