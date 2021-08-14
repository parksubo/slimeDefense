using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlimeSpawner : MonoBehaviour
{
    [SerializeField]
    private StageData stageData;    // 적 생성을 위한 스테이지 크기 정보
    [SerializeField]
    private GameObject slimePrefab; // 복제해서 생성할 적 캐릭터 프리팹
    [SerializeField]
    private float coolTime;         // 쿨타임
    [SerializeField]
    private GameObject slimeHPSliderPrefab; // 적 체력을 나타내는 Slider UI 프리팹
    [SerializeField]
    private Transform canvasTransform;  // UI를 표현하는 Canvas 오브젝트의 Transform

    [SerializeField]
    private Button button;                          // 소환 버튼
    [SerializeField]
    private int price;                              // 슬라임 가격
    [SerializeField]
    private PlayerController playerController;      // 소지 골드를 불러오기 위함
    [SerializeField]
    private int numberBought;                       // 소환 슬라임 번호
    [SerializeField]
    private GameObject noMoneyAlert;                // 소지금 부족할시 경고 UI

    private void Awake()
    {
        button.onClick.AddListener(summonSlime);
        noMoneyAlert.SetActive(false);
    }

    private void summonSlime()
    {
        // 소지골드가 구매가격보다 많다면 구매처리
        if (price <= playerController.Money)
        {
            playerController.Money -= price;
            SpawnSlime();
        }
        else
        {
            StartCoroutine("Alert");
        }
    }

    private void SpawnSlimeHPSlider(GameObject slime)
    {
        // 슬라임 체력을 나타내는 Slider UI 생성
        GameObject sliderClone = Instantiate(slimeHPSliderPrefab);
        // Slider UI 오브젝트를 parent("Canvas" 오브젝트)의 자식으로 설정
        // Tip. UI는 캔버스의 자식오브젝트로 설정되어 있어야 화면에 보인다. 중요 ★
        sliderClone.transform.SetParent(canvasTransform);
        // 계층 설정으로 바뀐 크기를 다시 (1, 1, 1)로 설정
        //sliderClone.transform.localScale = Vector3.one;

        // Slider UI가 쫓아다닐 대상을 본인으로 설정
        sliderClone.GetComponent<SliderPositionAutoSetter>().Setup(slime.transform);
        // Slider UI에 자신의 체력 정보를 표시하도록 설정
        sliderClone.GetComponent<SlimeHPViewer>().Setup(slime.GetComponent<SlimeHP>());
    }


    public void SpawnSlime()
    {
        // 슬라임 스폰 위치
        Vector3 position = new Vector3(stageData.LimitMin.x -6.0f, -4.0f, 0.0f);
        // 회전값
        Quaternion quaternion = Quaternion.identity;
        quaternion.eulerAngles = new Vector3(0, 180, 0);
        // 슬라임 캐릭터 생성
        GameObject slimeClone = Instantiate(slimePrefab, position, quaternion);
        // 슬라임 체력을 나타내는 Slider UI 생성 및 설정
        SpawnSlimeHPSlider(slimeClone);
    }

    private IEnumerator Alert()
    {
        noMoneyAlert.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        noMoneyAlert.SetActive(false);
    }



}
