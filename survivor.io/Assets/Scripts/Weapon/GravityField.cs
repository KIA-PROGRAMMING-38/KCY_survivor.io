using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GravityField : MonoBehaviour, IWeapon, ILevelup
{
    private static List<Monster> monster;
    public WeaponData gravityData;
    private GameObject gravity;
    private Transform[] childTransforms;
    public float angleSpeed;
    private WaitForSeconds coolTime;
    public float levelUpSize;
    public void Attack()
    {
        gravity = GameObject.Find("WeaponPos").transform.Find("GravityPos").gameObject;
        gravity.SetActive(true);
    }
    private void Awake()
    {
        childTransforms = GetComponentsInChildren<Transform>();
        coolTime = new WaitForSeconds(0.5f);
    }

    private void Start()
    {
        monster = new List<Monster>();
     
    }

    private void Update()
    {
        childTransforms[1].Rotate(0, 0, angleSpeed * Time.timeScale);
        childTransforms[2].Rotate(0, 0, -angleSpeed * Time.timeScale);
        childTransforms[3].Rotate(0, 0, angleSpeed * Time.timeScale);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Monster"))
            return;

        monster.Add(collision.GetComponent<Monster>());
        StartCoroutine(takeDamage());
    }

    

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Monster"))
            return;

        monster.Remove(collision.GetComponent<Monster>());
    }

    public void LevelUp()
    {
        gravityData.Level++;
        transform.localScale += new Vector3 (levelUpSize,levelUpSize,0);
        gravity.SetActive(false);
        gravity.SetActive(true);
    }

    private IEnumerator takeDamage()
    {
        while (true)
        {
            foreach (Monster monster in monster)
            {
                monster.monsterHealth = monster.monsterHealth - gravityData.Atk;
            }
            yield return coolTime;
        }
    }
}
