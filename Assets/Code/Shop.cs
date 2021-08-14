using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField]
    private GameObject[] slimeBuyList1 = new GameObject[3];  // ���Ž� �ش� �����ӹ�ȣ�� �ش��ϴ� ������ ����â ��Ȱ��ȭ�� ���� ����
    [SerializeField]
    private GameObject[] slimeBuyList2 = new GameObject[3];  // ������ ���� UI ��Ȱ��ȭ�� ���� ����
    [SerializeField]
    private GameObject[] slimeBuyList3 = new GameObject[3];  // ������ ���� ǥ�� UI ��Ȱ��ȭ�� ���� ����
    private PlayerController playerController;               // ������ ���������� ��� ���� ����

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        IfBuy();
    }


    // �̹� ������ ���������� Ȯ���ϴ� �Լ�
    private void IfBuy()
    {
        for (int i = 0; i < 2; i++)
        {
            if (playerController.GetSlimeActive(i) == true)
            {
                slimeBuyList1[i].SetActive(false);
                slimeBuyList2[i].SetActive(false);
                slimeBuyList3[i].SetActive(false);
            }
        }
    }
}
