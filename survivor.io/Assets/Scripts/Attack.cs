using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Attack : MonoBehaviour
{
    public GameObject bullet;
    public WeaponStatus weaponStatus;
    private Rigidbody2D rigid;
    private float elapsedTime;
    public float speed;
    public float angleSpeed;
    private void Awake()
    {
      
    }
    public void Start()
    {
        weaponStatus = new WeaponStatus(); // 발사될 무기의 상태 클래스
        weaponStatus.Init(10, 1, 1);

    }


    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= weaponStatus.per) // 일정 주기로 발사하기 위함
        {
            if (GameManager.instance.player.GetComponent<Scaner>().targetPos)
            {
                Shoot();
            }
            elapsedTime = 0;
        }
    }

    void Shoot()
    {
        GameObject spawnWeapon = GameManager.instance.weaponPool.Get(weaponStatus.index); // 풀의 해당하는 프리팹 인덱스를 통해 꺼내온다.
        spawnWeapon.transform.position = transform.position; //생성 위치
        rigid = spawnWeapon.GetComponent<Rigidbody2D>();
        rigid.velocity = (GameManager.instance.player.GetComponent<Scaner>().targetPos.position - transform.position).normalized * speed;
        rigid.AddTorque(angleSpeed); // 투사체 회전
    }

}
