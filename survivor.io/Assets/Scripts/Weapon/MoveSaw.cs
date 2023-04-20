using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSaw : MonoBehaviour
{
    public float angleSpeed;
    public float rotateSpeed;
    private Vector3 rotateVec;

    private void Start()
    {
        rotateVec = new Vector3 (0,0, -rotateSpeed);
    }
    void Update()
    {
        transform.RotateAround(WeaponManager.Instance.weaponPos.transform.position, Vector3.back, angleSpeed * Time.timeScale);
        transform.Rotate(rotateVec, rotateSpeed * Time.timeScale );
    }
}
