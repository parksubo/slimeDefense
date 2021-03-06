using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private GameObject projectilePrefab;  // 공격할 때 생성되는 발사체 프리팹
    [SerializeField]
    private float attackRate = 1.0f;      // 공격 속도
    private AudioSource audioSource;      // 사운드 재생 컴포넌트

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // 각각 TryAttack을 시작 종료
    public void StartFiring()
    {
        StartCoroutine("TryAttack");
    }

    public void StopFiring()
    {
        StopCoroutine("TryAttack");
    }

    private IEnumerator TryAttack()
    {
        while(true)
        {
            // 발사체 오브젝트 생성
            Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            // 공격 사운드 재생
            audioSource.Play();
            // attackRate 시간만큼 대기
            yield return new WaitForSeconds(attackRate);
        }
    }


    // Tip. Movement2D에 접근한 방식과 같은 방식으로
    // Projectile 클래스의 damage 변수에 접근할 수 있도록 설정 한 후 공격력도 다르게 설정 가능
}
