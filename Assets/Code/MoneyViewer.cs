using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;    // textMesh  ���� �����̽��� ����� ���� ����ϱ� ����

public class MoneyViewer : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerController;
    private TextMeshProUGUI money;  // �� UI

    public void Awake()
    {
        money = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        // Text UI�� ���� ���� ������ ������Ʈ
        money.text = "Your Money : " + playerController.Money;
    }


}
