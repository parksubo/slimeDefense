using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int damage = 1; // �� ���ݷ�

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ������ �ε��� ������Ʈ�� �±װ� "slime"�̸�
        if (collision.CompareTag("Slime"))
        {
            // �� ���ݷ� ��ŭ ������ ü�� ����
            collision.GetComponent<SlimeHP>().TakeDamage(damage);
        }
    }

}




/*
 *  Desc :
 * �� ������Ʈ�� �����ؼ� ���
 */
