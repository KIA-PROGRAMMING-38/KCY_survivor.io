using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectWeapon : MonoBehaviour
{
    public AbleWeapons ableWeaponsData; // 사용가능한 무기 데이터
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
        firstText = 0; // 최초 등록 시 갱신될 텍스트가 위치한 배열의 인덱스
    }


    private void OnEnable()
    {
        weaponIndex = Random.Range(0, ableWeaponsData.ableWeapons.Count - 1);
        saveWeapon = ableWeaponsData.ableWeapons[weaponIndex]; // 뽑은 무기를 저장
        weaponImage.sprite = ableWeaponsData.ableWeapons[weaponIndex].GetComponent<SpriteRenderer>().sprite; // 뽑은 무기의 이미지를 가져온다.
        weaponName.text = saveWeapon.name;
        weaponText = saveWeapon.GetComponent<WeaponText>();
        if (WeaponManager.Instance.weapons.ContainsKey(saveWeapon.name)) // 이미 등록된 무기면
        {
            weaponLevelText.text = weaponText.weaponText.levelupText[weaponText.weaponText.Level]; // 레벨별 설명을 갱신
        }
        else
        {
            weaponLevelText.text = weaponText.weaponText.levelupText[firstText]; // 등록되지 않은 무기라면 최초 설명 갱신
        }
        ableWeaponsData.ableWeapons.Remove(saveWeapon); // 뽑기 시 중복을 제거하기 위해 리스트에서 제거
    }

    private void OnDisable()
    {
        ableWeaponsData.ableWeapons.Add(saveWeapon); // 무기선택 후 다시 뽑기 위해 리스트에 추가
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
