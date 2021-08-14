using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;    // textMesh  네임 스페이스에 저장된 값을 사용하기 위함

public class MoneyViewer : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerController;
    private TextMeshProUGUI money;  // 돈 UI

    public void Awake()
    {
        money = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        // Text UI에 현재 점수 정보를 업데이트
        money.text = "Your Money : " + playerController.Money;
    }


}
