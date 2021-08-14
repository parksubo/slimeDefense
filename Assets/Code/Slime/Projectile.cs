using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �߻�ü�� �ε��� ������Ʈ�� �±װ� "Enemy"�̸�
        if(collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyHP>().TakeDamage(damage);
            // �߻�ü ������Ʈ ����  
            Destroy(gameObject);
        }
    }
}


/*
 *  Desc :
 *  ������ ĳ������ ���� �߻�ü
 */
