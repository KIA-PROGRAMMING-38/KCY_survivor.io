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
    public WeaponStrategy[] strategy; // �� weapon ����� ���� �迭
    public Dictionary<string, int> weapons;  // weapon ID�� ����ϱ� ���� ����
    public GameObject weaponPos;
    IWeapon currentWeapon;
    public int InputWeaponId = 0;
    public void Init()
    {
        strategy = new WeaponStrategy[5];
        for (int i = 0; i < 5; i++)
        {
            strategy[i] = new WeaponStrategy();
        }// ���� ������� ���⸦ ���� �����̳�, �ִ� ��� ������ ���� 5��

        weapons = new Dictionary<string, int>(); // ���� Id�� ������ �����̳�

        weaponPos = GameObject.Find("WeaponPos"); // ���� ��ġ ã��
    }
    public void Registration(GameObject weapon) // ���� ���
    {
        currentWeapon = weapon.GetComponent<IWeapon>();
        weapons.Add(weapon.name, InputWeaponId);
        strategy[InputWeaponId].SetWeapon(currentWeapon);
        strategy[InputWeaponId].Attack();
        InputWeaponId++;
    }
}
