using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSaw : MonoBehaviour
{
    private Vector3 movePos;
    public WeaponData sawData;
    public float radius;
    public RotationSaw saw;
    private RotationSaw[] currentSaw;


    private void Awake()
    {
        sawData.Atk = 1;
        sawData.Level = 1;
    }
    private void OnEnable()
    {
        float angle = Mathf.PI * 2;
        for (int i = 1; i <= sawData.Level + 1; i++)
        {
            movePos = new Vector3(Mathf.Cos(angle / (sawData.Level + 1) * i),
            Mathf.Sin(angle / (sawData.Level + 1) * i)).normalized;
            Instantiate(saw, transform).transform.position += movePos * radius;
        }
           
    }

    private void OnDisable()
    {
        currentSaw = GetComponentsInChildren<RotationSaw>();

        foreach(RotationSaw saw in currentSaw)
        {
            Destroy(saw.gameObject);
        }
    }

   
}
