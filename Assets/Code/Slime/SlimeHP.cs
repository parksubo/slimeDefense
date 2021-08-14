using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeHP : MonoBehaviour
{
    [SerializeField]
    private float maxHP = 10;   // �ִ� ü��
    private float currentHP;    // ���� ü��
    [SerializeField]
    private float move = -2.0f; // �ǰݽ� �����̴� �Ÿ�

    private SpriteRenderer spriteRenderer;
    private Movement2D movement2D;

    public float MaxHP => maxHP;    // maxHP ������ ������ �� �ִ� property (Get�� ����)
    public float CurrentHP => currentHP;    // currentHP ������ ������ �� �ִ� property (Get�� ����)


    private void Awake()
    {
        movement2D = GetComponent<Movement2D>();
        currentHP = maxHP;  // ���� ü���� �ִ� ü������ �ʱ�ȭ
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float damage)
    {
        // ���� ü���� damage ��ŭ ����
        currentHP -= damage;

        StopCoroutine("HitColorAnimation");
        StartCoroutine("HitColorAnimation");

        // ü���� 0���� = ������ ���
        if (currentHP <= 0)
        {
            // ü���� 0�̸� OnDie() �Լ��� ȣ���ؼ� �׾��� �� ó���� �Ѵ�
            OnDie();
        }
    }

    private IEnumerator HitColorAnimation()
    {
        // �÷��̾� ������ ����������
        spriteRenderer.color = Color.red;
        // �ε����� ���� ������Ʈ�� move ��ŭ �̵�
        gameObject.transform.position = new Vector3(gameObject.transform.position.x + move,
                                                    gameObject.transform.position.y,
                                                    gameObject.transform.position.z);
        // 0.1�� ���� ���
        yield return new WaitForSeconds(0.1f);
        // �÷��̾��� ������ ���� ������ �Ͼ������
        // (���� ������ �Ͼ���� �ƴ� ��� ���� ���� ���� ����)
        spriteRenderer.color = Color.white;
    }

    private void OnDie()
    {
        // ����� �浹���� �ʵ��� �浹 �ڽ� ����
        Destroy(GetComponent<CircleCollider2D>());
        Destroy(gameObject);
    }


}
