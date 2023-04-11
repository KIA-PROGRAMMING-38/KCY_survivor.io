using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System;
using UnityEngine.Assertions;

public class Attack : MonoBehaviour
{
    private WeaponStrategy[] strategy; // �� weapon ������ ���� �迭
    private Dictionary<string, int> weapons; // weapon ID�� ����ϱ� ���� ����
    private int weaponId; 
    private void Awake()
    {
      
    }
    private void Start()
    {
        
        weapons = new Dictionary<string, int>
        {
            { "Dagger", 0 } // weapon ID ���
            
        };
        strategy = new WeaponStrategy[weapons.Count];

        for (int weaponId = 0; weaponId < strategy.Length; weaponId++)
        {
            strategy[weaponId] = new WeaponStrategy();
        }

        weapons.TryGetValue("Dagger", out weaponId); // weapon ID �˻�
        strategy[weaponId].SetWeapon(new Dagger()); 
    }


    // Update is called once per frame
    void Update()
    {
        strategy[weaponId].Attack();
    }
}
