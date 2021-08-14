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
    private PlayerController playerController;      // 슬라임 구매여부 확인하기 위함


   private void Awake()
    {
        // 구매하지 않은 슬라임 버튼은 비활성화
        if(playerController.GetSlimeActive(slimeNumber) == false)
        {
            spawnSlimeButton.SetActive(false);
        }      
    }


}
