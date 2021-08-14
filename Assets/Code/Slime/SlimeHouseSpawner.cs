using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlimeHouseSpawner : MonoBehaviour
{
    [SerializeField]
    private StageData stageData;    // 스테이지 크기 정보
    [SerializeField]
    private GameObject slimePrefab; // 슬라임 하우스 프리팹
    [SerializeField]
    private GameObject slimeHPSliderPrefab; // 체력을 나타내는 Slider UI 프리팹
    [SerializeField]
    private Transform canvasTransform;  // UI를 표현하는 Canvas 오브젝트의 Transform

    [SerializeField]
    private float houseSize = 3.0f;     // 하우스 크기
    [SerializeField]
    private float houseX = -6.0f;       // 하우스 x위치
    [SerializeField]
    private float houseY = -4.0f;       // 하우스 y위치

    private void Awake()
    {
        StartCoroutine("SpawnSlime");
    }

    private void SpawnSlimeHPSlider(GameObject slime)
    {
        // 슬라임 체력을 나타내는 Slider UI 생성
        GameObject sliderClone = Instantiate(slimeHPSliderPrefab);
        // Slider UI 오브젝트를 parent("Canvas" 오브젝트)의 자식으로 설정
        // Tip. UI는 캔버스의 자식오브젝트로 설정되어 있어야 화면에 보인다. 중요 ★
        sliderClone.transform.SetParent(canvasTransform);

        // Slider UI가 쫓아다닐 대상을 본인으로 설정
        sliderClone.GetComponent<SliderPositionAutoSetter>().Setup(slime.transform);
        // Slider UI에 자신의 체력 정보를 표시하도록 설정
        sliderClone.GetComponent<SlimeHPViewer>().Setup(slime.GetComponent<SlimeHP>());
    }


    public void SpawnSlime()
    {
        // 슬라임 스폰 위치
        Vector3 position = new Vector3(stageData.LimitMin.x + houseX, houseY, 0.0f);
        // 회전값
        //Quaternion quaternion = Quaternion.identity;
        //quaternion.eulerAngles = new Vector3(0, 180, 0);
        // 슬라임 캐릭터 생성
        GameObject slimeClone = Instantiate(slimePrefab, position, Quaternion.identity);
        // 슬라임 체력을 나타내는 Slider UI 생성 및 설정
        SpawnSlimeHPSlider(slimeClone);
    }

}
