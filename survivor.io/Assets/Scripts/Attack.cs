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
        weaponStatus = new WeaponStatus(); // �߻�� ������ ���� Ŭ����
        weaponStatus.Init(10, 1, 1);

    }


    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= weaponStatus.per) // ���� �ֱ�� �߻��ϱ� ����
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
        GameObject spawnWeapon = GameManager.instance.weaponPool.Get(weaponStatus.index); // Ǯ�� �ش��ϴ� ������ �ε����� ���� �����´�.
        spawnWeapon.transform.position = transform.position; //���� ��ġ
        rigid = spawnWeapon.GetComponent<Rigidbody2D>();
        rigid.velocity = (GameManager.instance.player.GetComponent<Scaner>().targetPos.position - transform.position).normalized * speed;
        rigid.AddTorque(angleSpeed); // ����ü ȸ��
    }

}
