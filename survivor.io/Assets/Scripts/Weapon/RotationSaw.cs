using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class RotationSaw : MonoBehaviour, IWeapon, ILevelup
{
    private Vector3 rotateVec;
    public float radius;
    private Monster monster;
    public WeaponData sawData;
    public float angleSpeed;
    public float rotateSpeed;
    private GameObject saw;
    private float elapsedTime;

    public void Attack()
    {
        saw = GameObject.Find("WeaponPos").transform.Find("SawPos").gameObject;
        saw.SetActive(true);
    }
    private void Start()
    {
        rotateVec = new Vector3(0, 0, 1);
       
    }
    void Update()
    {
        transform.RotateAround(WeaponManager.Instance.weaponPos.transform.position, Vector3.back, angleSpeed * Time.timeScale);
        transform.Rotate(rotateVec, rotateSpeed * Time.timeScale);
        elapsedTime += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Monster"))
            return;

        monster = collision.gameObject.GetComponent<Monster>();
        monster.monsterHealth -= sawData.Atk;
    }

    public void LevelUp()
    {
        sawData.Level++;
        saw.SetActive(false);
        saw.SetActive(true);
    }
}
