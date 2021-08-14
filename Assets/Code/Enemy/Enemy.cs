using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int damage = 1; // 적 공격력

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 적에게 부딪힌 오브젝트의 태그가 "slime"이면
        if (collision.CompareTag("Slime"))
        {
            // 적 공격력 만큼 슬라임 체력 감소
            collision.GetComponent<SlimeHP>().TakeDamage(damage);
        }
    }

}




/*
 *  Desc :
 * 적 오브젝트에 부착해서 사용
 */
