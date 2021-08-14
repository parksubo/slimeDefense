using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlyBuySlimeActive : MonoBehaviour
{
    [SerializeField]
    private GameObject spawnSlimeButton;
    [SerializeField]
    private int slimeNumber;

    [SerializeField]
    private PlayerController playerController;      // ������ ���ſ��� Ȯ���ϱ� ����


   private void Awake()
    {
        // �������� ���� ������ ��ư�� ��Ȱ��ȭ
        if(playerController.GetSlimeActive(slimeNumber) == false)
        {
            spawnSlimeButton.SetActive(false);
        }      
    }


}
