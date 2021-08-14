using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    [SerializeField]
    private int damage = 1; // ������ ���ݷ�
    [SerializeField]
    private int slimeNumber; // ������ ��ȣ
    private Enemy enemy;



    private void Awake()
    {
        enemy = GetComponent<Enemy>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ������ �ε��� ������Ʈ�� �±װ� "Slime"�̸�
        if (collision.CompareTag("Enemy"))
        {
            // ������ ���ݷ¸�ŭ ��ü�� ����
            collision.GetComponent<EnemyHP>().TakeDamage(damage);
        }
    }

}
