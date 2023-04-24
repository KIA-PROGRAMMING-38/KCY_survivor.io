using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectWeapon : MonoBehaviour
{
    public AbleWeapons ableWeaponsData; // ��밡���� ���� ������
    private TMP_Text weaponName;
    private TMP_Text weaponLevelText;
    private WeaponText weaponText;
    private GameObject saveWeapon;
    private Image weaponImage;
    private int weaponIndex;
    private int firstText;
    
    private void Awake()
    {
        weaponImage = transform.Find("WeaponImage").gameObject.GetComponent<Image>();
        weaponName = transform.Find("WeaponName").GetComponent<TMP_Text>();
        weaponLevelText = transform.Find("LevelUpText").GetComponent<TMP_Text>();
    }

    private void Start()
    {
        firstText = 0; // ���� ��� �� ���ŵ� �ؽ�Ʈ�� ��ġ�� �迭�� �ε���
    }


    private void OnEnable()
    {
        weaponIndex = Random.Range(0, ableWeaponsData.ableWeapons.Count - 1);
        saveWeapon = ableWeaponsData.ableWeapons[weaponIndex]; // ���� ���⸦ ����
        weaponImage.sprite = ableWeaponsData.ableWeapons[weaponIndex].GetComponent<SpriteRenderer>().sprite; // ���� ������ �̹����� �����´�.
        weaponName.text = saveWeapon.name;
        weaponText = saveWeapon.GetComponent<WeaponText>();
        if (WeaponManager.Instance.weapons.ContainsKey(saveWeapon.name)) // �̹� ��ϵ� �����
        {
            weaponLevelText.text = weaponText.weaponText.levelupText[weaponText.weaponText.Level]; // ������ ������ ����
        }
        else
        {
            weaponLevelText.text = weaponText.weaponText.levelupText[firstText]; // ��ϵ��� ���� ������ ���� ���� ����
        }
        ableWeaponsData.ableWeapons.Remove(saveWeapon); // �̱� �� �ߺ��� �����ϱ� ���� ����Ʈ���� ����
    }

    private void OnDisable()
    {
        ableWeaponsData.ableWeapons.Add(saveWeapon); // ���⼱�� �� �ٽ� �̱� ���� ����Ʈ�� �߰�
    }

    public void WeaponRegistration()
    {
        if (WeaponManager.Instance.weapons.ContainsKey(saveWeapon.name))
        {
            saveWeapon.GetComponent<ILevelup>().LevelUp();
        }
        else
        {
            WeaponManager.Instance.Registration(saveWeapon);
        }
    }

}
