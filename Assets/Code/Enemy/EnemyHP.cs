using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    [SerializeField]
    private float maxHP = 4;    // �ִ� ü��
    private float currentHP;    // ���� ü��
    private Enemy enemy;
    private SpriteRenderer spriteRenderer;
    private Movement2D movement2D;

    [SerializeField]
    private int moneyGet = 100;   // �� óġ�� ȹ�� ���
    [SerializeField]
    private float move = 2.0f;    // �� Ÿ�ݽ� �̵� �Ÿ�

    private PlayerController playerController; // money ������ ��� ����

    public float MaxHP => maxHP;    // �ܺο��� ���� ü�������� �˱� ����
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
        // ���� ü���� damage ��ŭ ����
        currentHP -= damage;

        StopCoroutine("HitColorAnimation");
        StartCoroutine("HitColorAnimation");

        // ü���� 0 ���� �� ���
        if(currentHP <= 0)
        {
            // �� ĳ���� ���
            OnDie();
        }
    }

    private IEnumerator HitColorAnimation()
    {
        // ���� ������ ����������
        spriteRenderer.color = Color.red;
        // �ε����� ���� ������Ʈ�� move ��ŭ �̵�
        gameObject.transform.position = new Vector3(gameObject.transform.position.x + move,
                                                    gameObject.transform.position.y,
                                                    gameObject.transform.position.z);
        // 0.05�� ���� ���
        yield return new WaitForSeconds(0.05f);
        // ���� ������ ���� ������ �Ͼ������
        spriteRenderer.color = Color.white;
    }

    private void OnDie()
    {
        // ����� �浹���� �ʵ��� �浹 �ڽ� ����
        Destroy(GetComponent<CircleCollider2D>());
        Destroy(gameObject);
        playerController.Money += moneyGet;
    }

}
