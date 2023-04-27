using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectWeapon : MonoBehaviour
{
    public AbleWeapons ableWeaponsData; // 사용가능한 무기 데이터
    public List<GameObject> stars; // 재생할 애니메이션이 담긴 오브젝트
    private TMP_Text weaponName;
    private TMP_Text weaponLevelText;
    private WeaponText weaponData;
    private GameObject saveWeapon;
    private Image weaponImage;
    private int weaponIndex;
    private int firstText;
    private int firstStar;
    public List<Animator> starAnime; // 재생할 애니메이터
   
    
    private void Awake()
    {
        weaponImage = transform.Find("WeaponImage").gameObject.GetComponent<Image>();
        weaponName = transform.Find("WeaponName").GetComponent<TMP_Text>();
        weaponLevelText = transform.Find("LevelUpText").GetComponent<TMP_Text>();
        for (int i = 0; i < stars.Count; i++) 
        {
            starAnime.Add(stars[i].GetComponent<Animator>()); // 애니메이터 캐싱
        }
         
        firstText = 0; // 최초 등록 시 갱신될 텍스트가 위치한 배열의 인덱스
        firstStar = 0;
    }

  
    private void OnEnable()
    {
        weaponIndex = Random.Range(0, ableWeaponsData.ableWeapons.Count - 1); // 사용 가능한 무기 풀에서 랜덤으로 뽑는다
        saveWeapon = ableWeaponsData.ableWeapons[weaponIndex]; // 뽑은 무기를 저장
        weaponImage.sprite = ableWeaponsData.ableWeapons[weaponIndex].GetComponent<SpriteRenderer>().sprite; // 뽑은 무기의 이미지를 가져온다.
        weaponName.text = saveWeapon.name; // 저장한 무기의 이름을 표기
        weaponData = saveWeapon.GetComponent<WeaponText>(); // 무기의 레벨 텍스트 정보를 가져온다

        if (WeaponManager.Instance.weapons.ContainsKey(saveWeapon.name)) // 이미 사용중인 무기면
        {
            weaponLevelText.text = weaponData.weaponText.levelupText[weaponData.weaponText.Level]; // 레벨별 설명을 게시

            for (int level = 0; level < weaponData.weaponText.Level; level++)
            {
                starAnime[level].SetTrigger("IsStar"); // 현재 레벨보다 작은 칸의 별은 채워주고
            }

            starAnime[weaponData.weaponText.Level].SetTrigger("IsTwinkle"); // 선택시 도달할 레벨의 별 애니메이션 재생
        }
        else // 사용중인 무기가 아니라면
        {
            weaponLevelText.text = weaponData.weaponText.levelupText[firstText]; // 최초 설명 게시

            starAnime[firstStar].SetTrigger("IsTwinkle"); // 가장 처음 별의 애니메이션 재생
        }

        ableWeaponsData.ableWeapons.Remove(saveWeapon); // 중복된 무기의 등장을 막기 위해 리스트에서 제거
    }

    private void OnDisable()
    {
        ableWeaponsData.ableWeapons.Add(saveWeapon); // 무기선택 후 다시 뽑기 위해 리스트에 추가
    }

    public void WeaponRegistration() // 버튼 선택 시 호출 될 함수
    {
        if (WeaponManager.Instance.weapons.ContainsKey(saveWeapon.name)) // 사용 중인 무기면
        {
            saveWeapon.GetComponent<ILevelup>().LevelUp(); //레벨 업
        }
        else
        {
            WeaponManager.Instance.Registration(saveWeapon); // 사용할 무기에 등록
        }
    }

}
