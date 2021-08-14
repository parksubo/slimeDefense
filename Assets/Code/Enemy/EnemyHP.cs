using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    [SerializeField]
    private float maxHP = 4;    // 최대 체력
    private float currentHP;    // 현재 체력
    private Enemy enemy;
    private SpriteRenderer spriteRenderer;
    private Movement2D movement2D;

    [SerializeField]
    private int moneyGet = 100;   // 적 처치시 획득 골드
    [SerializeField]
    private float move = 2.0f;    // 적 타격시 이동 거리

    private PlayerController playerController; // money 정보를 얻기 위함

    public float MaxHP => maxHP;    // 외부에서 적의 체력정보를 알기 위함
    public float CurrentHP => currentHP;

    private void Awake()
    {
        currentHP = maxHP;
        enemy = GetComponent<Enemy>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        movement2D = GetComponent<Movement2D>();
        playerController = GetComponent<PlayerController>();
    }

    public void TakeDamage(float damage)
    {
        // 현재 체력을 damage 만큼 감소
        currentHP -= damage;

        StopCoroutine("HitColorAnimation");
        StartCoroutine("HitColorAnimation");

        // 체력이 0 이하 적 사망
        if(currentHP <= 0)
        {
            // 적 캐릭터 사망
            OnDie();
        }
    }

    private IEnumerator HitColorAnimation()
    {
        // 적의 색상을 빨간색으로
        spriteRenderer.color = Color.red;
        // 부딪히면 게임 오브젝트를 move 만큼 이동
        gameObject.transform.position = new Vector3(gameObject.transform.position.x + move,
                                                    gameObject.transform.position.y,
                                                    gameObject.transform.position.z);
        // 0.05초 동안 대기
        yield return new WaitForSeconds(0.05f);
        // 적의 색상을 원래 색상인 하얀색으로
        spriteRenderer.color = Color.white;
    }

    private void OnDie()
    {
        // 적들과 충돌하지 않도록 충돌 박스 삭제
        Destroy(GetComponent<CircleCollider2D>());
        Destroy(gameObject);
        playerController.Money += moneyGet;
    }

}
