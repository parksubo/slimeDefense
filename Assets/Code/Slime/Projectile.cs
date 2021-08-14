using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 발사체에 부딪힌 오브젝트의 태그가 "Enemy"이면
        if(collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyHP>().TakeDamage(damage);
            // 발사체 오브젝트 삭제  
            Destroy(gameObject);
        }
    }
}


/*
 *  Desc :
 *  슬라임 캐릭터의 공격 발사체
 */
