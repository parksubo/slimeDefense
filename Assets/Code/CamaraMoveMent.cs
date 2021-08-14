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
        // 방향키로 카메라 이동
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        movement2D.MoveTo(new Vector3(x, 0, 0));
    }

    private void LateUpdate()
    {
        // 카메라가 화면 범위 밖으로 나가지 못하게 함
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, stageData.LimitMin.x, stageData.LimitMax.x),
                                         Mathf.Clamp(transform.position.y, stageData.LimitMin.y, stageData.LimitMax.y), -10);
    }
}
