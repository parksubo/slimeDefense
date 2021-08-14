using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �θ� Ŭ������ ScriptableObject�� ����ϸ� �ش� Ŭ������ �������� ���·� ������ �� �ְ�
// CreateAssetMenu�� ���̸� Project View�� Create("+") �޴��� �޴��� ��ϵȴ�
[CreateAssetMenu]
public class StageData : ScriptableObject  
{
    [SerializeField]
    private Vector2 limitMin;
    [SerializeField]
    private Vector2 limitMax;

    public Vector2 LimitMin => limitMin;
    public Vector2 LimitMax => limitMax;
}

/* Desc : 
 * ���� ���������� ȭ�� �� ����
 * ���� �����ͷ� �����صΰ� ������ �ҷ��ͼ� ���
*/