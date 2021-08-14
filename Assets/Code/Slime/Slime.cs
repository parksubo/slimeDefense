using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    [SerializeField]
    private int damage = 1; // 슬라임 공격력
    [SerializeField]
    private int slimeNumber; // 슬라임 번호
    private Enemy enemy;



    private void Awake()
    {
        enemy = GetComponent<Enemy>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 적에게 부딪힌 오브젝트의 태그가 "Slime"이면
        if (collision.CompareTag("Enemy"))
        {
            // 슬라임 공격력만큼 적체력 감소
            collision.GetComponent<EnemyHP>().TakeDamage(damage);
        }
    }

}
