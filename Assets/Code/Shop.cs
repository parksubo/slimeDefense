using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField]
    private GameObject[] slimeBuyList1 = new GameObject[3];  // 구매시 해당 슬라임번호에 해당하는 슬라임 구매창 비활성화를 위한 변수
    [SerializeField]
    private GameObject[] slimeBuyList2 = new GameObject[3];  // 슬라임 설명 UI 비활성화를 위한 변수
    [SerializeField]
    private GameObject[] slimeBuyList3 = new GameObject[3];  // 슬라임 가격 표시 UI 비활성화를 위한 변수
    private PlayerController playerController;               // 슬라임 구매정보를 얻기 위한 변수

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        IfBuy();
    }


    // 이미 구매한 슬라임이지 확인하는 함수
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
