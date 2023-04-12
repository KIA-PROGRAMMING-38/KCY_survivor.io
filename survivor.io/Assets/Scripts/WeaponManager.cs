using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System;
using UnityEngine.Assertions;
using UnityEditor;

public class Weapon : MonoBehaviour
{
    WeaponStrategy[] strategy; // 각 weapon 전략을 담을 배열
    private Dictionary<string, int> weapons;  // weapon ID를 등록하기 위한 사전
    private int weaponId;
    private int InputWeaponId = 0;
    public GameObject defaultWeapon;
    

    private void Start()
    {
       
        weapons = new Dictionary<string, int> // 현재 들고 있는 무기
        {
            { defaultWeapon.name, InputWeaponId } // weapon ID 등록
            
        };
        InputWeaponId++; // 등록 ID 올려줌
        strategy = new WeaponStrategy[5]; // player가 사용할 수 있는 최대 무기 수
        for (int weaponId = 0; weaponId < 5; weaponId++)
        {
            strategy[weaponId] = new WeaponStrategy();
        }

        weapons.TryGetValue(defaultWeapon.name, out weaponId); // weapon ID 검색
        strategy[weaponId].SetWeapon(Instantiate(defaultWeapon,transform).GetComponent<IWeapon>());
    }
    void Update()
    {
        for (int weaponId = 0; weaponId < weapons.Count; weaponId++)
        {
            strategy[weaponId].Attack(); // Id가 등록되지 않으면 공격하지 않음
        }
    }
}
