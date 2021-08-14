using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.Experimental.UIElements;

public class OnMouseEvent : MonoBehaviour
{

    [SerializeField]
    private Collider2D slime;                       // 슬라임 collider
    [SerializeField]
    private GameObject description;                 // 슬라임에 대한 설명
    [SerializeField]
    private GameObject coin;                        // 슬라임 가격 옆의 코인 아이콘
    [SerializeField]
    private GameObject priceUI;                     // 슬라임 가격 UI
    [SerializeField]
    private GameObject noMoneyAlert;                // 소지금 부족할시 경고 UI
    [SerializeField]
    private int price;                              // 슬라임 가격

    [SerializeField]
    private PlayerController playerController;      // 소지 골드를 불러오기 위함

    [SerializeField]
    private int numberBought;                       // 구매 슬라임 번호

    private void Awake()
    {
        slime = GetComponent<Collider2D>();
        description.SetActive(false);
        noMoneyAlert.SetActive(false);
    }

    private void Update()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);  // 마우스의 위치를 얻기 위함
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

        if (hit.collider != null && hit.collider == slime)  
        {
            OnMouseEnter();   // 마우스 위에 올릴시 실행
            if (Input.GetMouseButtonDown(0))    // 왼쪽 마우스 버튼 클릭시 실행
            {
                OnMouseDown();
            }
        }    
        else OnMouseExit();
    }

    private void OnMouseEnter()
    {
        description.SetActive(true);
    }

    private void OnMouseExit()
    {
        description.SetActive(false);
    }

    private void OnMouseDown()
    {
        // 소지골드가 구매가격보다 많다면 구매처리
        if(price <= playerController.Money)
        {
            playerController.Money -= price;
            playerController.Play = true;
            // 구매한 아이템 활성화 하기 위한 코드
            playerController.SetSlimeActive(numberBought);
            Destroy(coin);
            Destroy(priceUI);
            Destroy(description);
            Destroy(gameObject);
        }
        else
        {
            StartCoroutine("Alert");
        }
    }

    private IEnumerator Alert()
    {
        noMoneyAlert.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        noMoneyAlert.SetActive(false);
    }

}
