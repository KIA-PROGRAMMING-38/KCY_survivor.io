using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectWeapon : MonoBehaviour
{
    public AbleWeapons ableWeaponsData; // 사용가능한 무기 데이터
    private GameObject imageBox; // 무기이미지 공간
    private TMP_Text weaponName;
    private GameObject saveWeapon;
    private Image weaponImage;
    private int weaponIndex;
    
    private void Awake()
    {
        imageBox = transform.Find("WeaponImage").gameObject;
        weaponImage = imageBox.GetComponent<Image>();
        weaponName = transform.Find("WeaponName").GetComponent<TMP_Text>();
    }

 
    private void OnEnable()
    {
        weaponIndex = Random.Range(0, ableWeaponsData.ableWeapons.Count - 1);
        saveWeapon = ableWeaponsData.ableWeapons[weaponIndex];
        weaponImage.sprite = ableWeaponsData.ableWeapons[weaponIndex].GetComponent<SpriteRenderer>().sprite;
        weaponName.text = saveWeapon.name;
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
