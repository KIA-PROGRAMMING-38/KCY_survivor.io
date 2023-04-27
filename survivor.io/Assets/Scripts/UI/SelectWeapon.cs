using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectWeapon : MonoBehaviour
{
    public AbleWeapons ableWeaponsData; // ��밡���� ���� ������
    public List<GameObject> stars;
    private TMP_Text weaponName;
    private TMP_Text weaponLevelText;
    private WeaponText weaponText;
    private GameObject saveWeapon;
    private Image weaponImage;
    private int weaponIndex;
    private int firstText;
    public List<Animator> starAnime;
   
    
    private void Awake()
    {
        weaponImage = transform.Find("WeaponImage").gameObject.GetComponent<Image>();
        weaponName = transform.Find("WeaponName").GetComponent<TMP_Text>();
        weaponLevelText = transform.Find("LevelUpText").GetComponent<TMP_Text>();
        for (int i = 0; i < stars.Count; i++) 
        {
            starAnime.Add(stars[i].GetComponent<Animator>());
        }
         
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
            for (int i = 0; i < weaponText.weaponText.Level; i++)
            {
                starAnime[i].SetTrigger("IsStar");
            }
            starAnime[weaponText.weaponText.Level].SetTrigger("IsTwinkle");
        }
        else
        {
            weaponLevelText.text = weaponText.weaponText.levelupText[firstText]; // ��ϵ��� ���� ������ ���� ���� ����
            starAnime[0].SetTrigger("IsTwinkle"); // ���� ��� ������ ��� ���� ó�� ���� �ִϸ��̼� ���
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
