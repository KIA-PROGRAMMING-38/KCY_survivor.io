using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System;
using UnityEngine.Assertions;
using UnityEditor;

public class Weapon : MonoBehaviour
{
    WeaponStrategy[] strategy; // �� weapon ������ ���� �迭
    private Dictionary<string, int> weapons;  // weapon ID�� ����ϱ� ���� ����
    private int weaponId;
    private int InputWeaponId = 0;
    public GameObject defaultWeapon;
    

    private void Start()
    {
       
        weapons = new Dictionary<string, int> // ���� ��� �ִ� ����
        {
            { defaultWeapon.name, InputWeaponId } // weapon ID ���
            
        };
        InputWeaponId++; // ��� ID �÷���
        strategy = new WeaponStrategy[5]; // player�� ����� �� �ִ� �ִ� ���� ��
        for (int weaponId = 0; weaponId < 5; weaponId++)
        {
            strategy[weaponId] = new WeaponStrategy();
        }

        weapons.TryGetValue(defaultWeapon.name, out weaponId); // weapon ID �˻�
        strategy[weaponId].SetWeapon(Instantiate(defaultWeapon,transform).GetComponent<IWeapon>());
    }
    void Update()
    {
        for (int weaponId = 0; weaponId < weapons.Count; weaponId++)
        {
            strategy[weaponId].Attack(); // Id�� ��ϵ��� ������ �������� ����
        }
    }
}
