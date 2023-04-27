using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectWeapon : MonoBehaviour
{
    public AbleWeapons ableWeaponsData; // ��밡���� ���� ������
    public List<GameObject> stars; // ����� �ִϸ��̼��� ��� ������Ʈ
    private TMP_Text weaponName;
    private TMP_Text weaponLevelText;
    private WeaponText weaponData;
    private GameObject saveWeapon;
    private Image weaponImage;
    private int weaponIndex;
    private int firstText;
    private int firstStar;
    public List<Animator> starAnime; // ����� �ִϸ�����
   
    
    private void Awake()
    {
        weaponImage = transform.Find("WeaponImage").gameObject.GetComponent<Image>();
        weaponName = transform.Find("WeaponName").GetComponent<TMP_Text>();
        weaponLevelText = transform.Find("LevelUpText").GetComponent<TMP_Text>();
        for (int i = 0; i < stars.Count; i++) 
        {
            starAnime.Add(stars[i].GetComponent<Animator>()); // �ִϸ����� ĳ��
        }
         
        firstText = 0; // ���� ��� �� ���ŵ� �ؽ�Ʈ�� ��ġ�� �迭�� �ε���
        firstStar = 0;
    }

  
    private void OnEnable()
    {
        weaponIndex = Random.Range(0, ableWeaponsData.ableWeapons.Count - 1); // ��� ������ ���� Ǯ���� �������� �̴´�
        saveWeapon = ableWeaponsData.ableWeapons[weaponIndex]; // ���� ���⸦ ����
        weaponImage.sprite = ableWeaponsData.ableWeapons[weaponIndex].GetComponent<SpriteRenderer>().sprite; // ���� ������ �̹����� �����´�.
        weaponName.text = saveWeapon.name; // ������ ������ �̸��� ǥ��
        weaponData = saveWeapon.GetComponent<WeaponText>(); // ������ ���� �ؽ�Ʈ ������ �����´�

        if (WeaponManager.Instance.weapons.ContainsKey(saveWeapon.name)) // �̹� ������� �����
        {
            weaponLevelText.text = weaponData.weaponText.levelupText[weaponData.weaponText.Level]; // ������ ������ �Խ�

            for (int level = 0; level < weaponData.weaponText.Level; level++)
            {
                starAnime[level].SetTrigger("IsStar"); // ���� �������� ���� ĭ�� ���� ä���ְ�
            }

            starAnime[weaponData.weaponText.Level].SetTrigger("IsTwinkle"); // ���ý� ������ ������ �� �ִϸ��̼� ���
        }
        else // ������� ���Ⱑ �ƴ϶��
        {
            weaponLevelText.text = weaponData.weaponText.levelupText[firstText]; // ���� ���� �Խ�

            starAnime[firstStar].SetTrigger("IsTwinkle"); // ���� ó�� ���� �ִϸ��̼� ���
        }

        ableWeaponsData.ableWeapons.Remove(saveWeapon); // �ߺ��� ������ ������ ���� ���� ����Ʈ���� ����
    }

    private void OnDisable()
    {
        ableWeaponsData.ableWeapons.Add(saveWeapon); // ���⼱�� �� �ٽ� �̱� ���� ����Ʈ�� �߰�
    }

    public void WeaponRegistration() // ��ư ���� �� ȣ�� �� �Լ�
    {
        if (WeaponManager.Instance.weapons.ContainsKey(saveWeapon.name)) // ��� ���� �����
        {
            saveWeapon.GetComponent<ILevelup>().LevelUp(); //���� ��
        }
        else
        {
            WeaponManager.Instance.Registration(saveWeapon); // ����� ���⿡ ���
        }
    }

}
