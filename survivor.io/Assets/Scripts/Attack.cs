using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System;
using UnityEngine.Assertions;

public class Attack : MonoBehaviour
{
    private WeaponStrategy[] strategy; // 각 weapon 전략을 담을 배열
    private Dictionary<string, int> weapons; // weapon ID를 등록하기 위한 사전
    private int weaponId; 
    private void Awake()
    {
      
    }
    private void Start()
    {
        
        weapons = new Dictionary<string, int>
        {
            { "Dagger", 0 } // weapon ID 등록
            
        };
        strategy = new WeaponStrategy[weapons.Count];

        for (int weaponId = 0; weaponId < strategy.Length; weaponId++)
        {
            strategy[weaponId] = new WeaponStrategy();
        }

        weapons.TryGetValue("Dagger", out weaponId); // weapon ID 검색
        strategy[weaponId].SetWeapon(new Dagger()); 
    }


    // Update is called once per frame
    void Update()
    {
        strategy[weaponId].Attack();
    }
}
