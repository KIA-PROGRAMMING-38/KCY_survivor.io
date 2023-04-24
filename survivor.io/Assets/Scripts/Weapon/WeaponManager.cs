using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System;
using UnityEngine.Assertions;
using UnityEditor;

public class WeaponManager
{
    private static WeaponManager instance;
    public static WeaponManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new WeaponManager();
            }
            return instance;
        }
    }
    public WeaponStrategy[] strategy; // 각 weapon 기능을 담을 배열
    public Dictionary<string, int> weapons;  // weapon ID를 등록하기 위한 사전
    public GameObject weaponPos;
    IWeapon currentWeapon;
    public int InputWeaponId = 0;
    public void Init()
    {
        strategy = new WeaponStrategy[5];
        for (int i = 0; i < 5; i++)
        {
            strategy[i] = new WeaponStrategy();
        }// 현재 사용중인 무기를 담을 컨테이너, 최대 사용 가능한 무기 5개

        weapons = new Dictionary<string, int>(); // 무기 Id를 저장할 컨테이너

        weaponPos = GameObject.Find("WeaponPos"); // 스폰 위치 찾기
    }
    public void Registration(GameObject weapon) // 무기 등록
    {
        currentWeapon = weapon.GetComponent<IWeapon>();
        weapons.Add(weapon.name, InputWeaponId);
        strategy[InputWeaponId].SetWeapon(currentWeapon);
        strategy[InputWeaponId].Attack();
        InputWeaponId++;
    }
}
