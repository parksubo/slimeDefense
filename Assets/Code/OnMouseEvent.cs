using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.Experimental.UIElements;

public class OnMouseEvent : MonoBehaviour
{

    [SerializeField]
    private Collider2D slime;                       // ������ collider
    [SerializeField]
    private GameObject description;                 // �����ӿ� ���� ����
    [SerializeField]
    private GameObject coin;                        // ������ ���� ���� ���� ������
    [SerializeField]
    private GameObject priceUI;                     // ������ ���� UI
    [SerializeField]
    private GameObject noMoneyAlert;                // ������ �����ҽ� ��� UI
    [SerializeField]
    private int price;                              // ������ ����

    [SerializeField]
    private PlayerController playerController;      // ���� ��带 �ҷ����� ����

    [SerializeField]
    private int numberBought;                       // ���� ������ ��ȣ

    private void Awake()
    {
        slime = GetComponent<Collider2D>();
        description.SetActive(false);
        noMoneyAlert.SetActive(false);
    }

    private void Update()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);  // ���콺�� ��ġ�� ��� ����
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

        if (hit.collider != null && hit.collider == slime)  
        {
            OnMouseEnter();   // ���콺 ���� �ø��� ����
            if (Input.GetMouseButtonDown(0))    // ���� ���콺 ��ư Ŭ���� ����
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
        // ������尡 ���Ű��ݺ��� ���ٸ� ����ó��
        if(price <= playerController.Money)
        {
            playerController.Money -= price;
            playerController.Play = true;
            // ������ ������ Ȱ��ȭ �ϱ� ���� �ڵ�
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
