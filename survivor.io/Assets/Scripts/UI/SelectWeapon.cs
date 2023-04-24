using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectWeapon : MonoBehaviour
{
    public AbleWeapons ableWeaponsData; // 사용가능한 무기 데이터
    private GameObject imageBox; // 무기이미지 공간
    private GameObject saveWeapon;
    private Image weaponImage;
    private int weaponIndex;
    
    private void Awake()
    {
        imageBox = transform.Find("WeaponImage").gameObject;
        weaponImage = imageBox.GetComponent<Image>();
    }

 
    private void OnEnable()
    {
        weaponIndex = Random.Range(0, ableWeaponsData.ableWeapons.Count - 1);
        saveWeapon = ableWeaponsData.ableWeapons[weaponIndex];
        weaponImage.sprite = ableWeaponsData.ableWeapons[weaponIndex].GetComponent<SpriteRenderer>().sprite;
        ableWeaponsData.ableWeapons.Remove(saveWeapon);
    }

    private void OnDisable()
    {
        ableWeaponsData.ableWeapons.Add(saveWeapon);
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
