using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeHP : MonoBehaviour
{
    [SerializeField]
    private float maxHP = 10;   // 최대 체력
    private float currentHP;    // 현재 체력
    [SerializeField]
    private float move = -2.0f; // 피격시 움직이는 거리

    private SpriteRenderer spriteRenderer;
    private Movement2D movement2D;

    public float MaxHP => maxHP;    // maxHP 변수에 접근할 수 있는 property (Get만 가능)
    public float CurrentHP => currentHP;    // currentHP 변수에 접근할 수 있는 property (Get만 가능)


    private void Awake()
    {
        movement2D = GetComponent<Movement2D>();
        currentHP = maxHP;  // 현재 체력을 최대 체력으로 초기화
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float damage)
    {
        // 현재 체력을 damage 만큼 감소
        currentHP -= damage;

        StopCoroutine("HitColorAnimation");
        StartCoroutine("HitColorAnimation");

        // 체력이 0이하 = 슬라임 사망
        if (currentHP <= 0)
        {
            // 체력이 0이면 OnDie() 함수를 호출해서 죽었을 때 처리를 한다
            OnDie();
        }
    }

    private IEnumerator HitColorAnimation()
    {
        // 플레이어 색상을 빨간색으로
        spriteRenderer.color = Color.red;
        // 부딪히면 게임 오브젝트를 move 만큼 이동
        gameObject.transform.position = new Vector3(gameObject.transform.position.x + move,
                                                    gameObject.transform.position.y,
                                                    gameObject.transform.position.z);
        // 0.1초 동안 대기
        yield return new WaitForSeconds(0.1f);
        // 플레이어의 색상을 원래 색상인 하얀색으로
        // (원래 색상이 하얀색이 아닐 경우 원래 색상 변수 선언)
        spriteRenderer.color = Color.white;
    }

    private void OnDie()
    {
        // 적들과 충돌하지 않도록 충돌 박스 삭제
        Destroy(GetComponent<CircleCollider2D>());
        Destroy(gameObject);
    }


}
