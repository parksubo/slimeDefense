using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMoveMent : MonoBehaviour
{
    [SerializeField]
    private StageData stageData;
    private Movement2D movement2D;

    public void Awake()
    {
        movement2D = GetComponent<Movement2D>();
    }

    private void Update()
    {
        // ����Ű�� ī�޶� �̵�
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        movement2D.MoveTo(new Vector3(x, 0, 0));
    }

    private void LateUpdate()
    {
        // ī�޶� ȭ�� ���� ������ ������ ���ϰ� ��
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, stageData.LimitMin.x, stageData.LimitMax.x),
                                         Mathf.Clamp(transform.position.y, stageData.LimitMin.y, stageData.LimitMax.y), -10);
    }
}
