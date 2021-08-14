using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderPositionAutoSetter : MonoBehaviour
{
    [SerializeField]
    private Vector3 distance = Vector3.down * 35.0f;    // Slider UI�� �������� �Ÿ�
    private Transform targetTransform;      // Ÿ���� transform ���� ����
    private RectTransform rectTransform;    // UI�� ��ġ���� ����

    public void Setup(Transform target)
    {
        // Slider UI�� �i�ƴٴ� target ����
        targetTransform = target;
        // RectTransfrom ������Ʈ ���� ������
        rectTransform = GetComponent<RectTransform>();
    }

    private void LateUpdate()
    {
        // ���� �ı��Ǿ� �i�ƴٴ� ����� ������� Slider UI�� ����
        if (targetTransform == null)
        {
            Destroy(gameObject);
            return;
        }

        // ������Ʈ�� ��ġ�� ���ŵ� ���Ŀ�  Slider UI�� �Բ� ��ġ�� �����ϵ��� �ϱ� ����
        // LateUpdate()���� ȣ���Ѵ�

        // ������Ʈ�� ���� ��ǥ�� �������� ȭ�鿡���� ��ǥ���� ����
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(targetTransform.position);
        // ȭ�鳻���� ��ǥ +  distance ��ŭ ������ ��ġ�� Slider UI�� ��ġ�� ����
        rectTransform.position = screenPosition + distance;
    }
}
/*
 * Desc :
 * Slider UI�� �����ؼ� ����ϸ�, target ������Ʈ�� �i�ƴٴϵ��� ��
 * 
 * 
 * 
 */
