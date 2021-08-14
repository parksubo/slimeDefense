using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlimeSpawner : MonoBehaviour
{
    [SerializeField]
    private StageData stageData;    // �� ������ ���� �������� ũ�� ����
    [SerializeField]
    private GameObject slimePrefab; // �����ؼ� ������ �� ĳ���� ������
    [SerializeField]
    private float coolTime;         // ��Ÿ��
    [SerializeField]
    private GameObject slimeHPSliderPrefab; // �� ü���� ��Ÿ���� Slider UI ������
    [SerializeField]
    private Transform canvasTransform;  // UI�� ǥ���ϴ� Canvas ������Ʈ�� Transform

    [SerializeField]
    private Button button;                          // ��ȯ ��ư
    [SerializeField]
    private int price;                              // ������ ����
    [SerializeField]
    private PlayerController playerController;      // ���� ��带 �ҷ����� ����
    [SerializeField]
    private int numberBought;                       // ��ȯ ������ ��ȣ
    [SerializeField]
    private GameObject noMoneyAlert;                // ������ �����ҽ� ��� UI

    private void Awake()
    {
        button.onClick.AddListener(summonSlime);
        noMoneyAlert.SetActive(false);
    }

    private void summonSlime()
    {
        // ������尡 ���Ű��ݺ��� ���ٸ� ����ó��
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
        // ������ ü���� ��Ÿ���� Slider UI ����
        GameObject sliderClone = Instantiate(slimeHPSliderPrefab);
        // Slider UI ������Ʈ�� parent("Canvas" ������Ʈ)�� �ڽ����� ����
        // Tip. UI�� ĵ������ �ڽĿ�����Ʈ�� �����Ǿ� �־�� ȭ�鿡 ���δ�. �߿� ��
        sliderClone.transform.SetParent(canvasTransform);
        // ���� �������� �ٲ� ũ�⸦ �ٽ� (1, 1, 1)�� ����
        //sliderClone.transform.localScale = Vector3.one;

        // Slider UI�� �Ѿƴٴ� ����� �������� ����
        sliderClone.GetComponent<SliderPositionAutoSetter>().Setup(slime.transform);
        // Slider UI�� �ڽ��� ü�� ������ ǥ���ϵ��� ����
        sliderClone.GetComponent<SlimeHPViewer>().Setup(slime.GetComponent<SlimeHP>());
    }


    public void SpawnSlime()
    {
        // ������ ���� ��ġ
        Vector3 position = new Vector3(stageData.LimitMin.x -6.0f, -4.0f, 0.0f);
        // ȸ����
        Quaternion quaternion = Quaternion.identity;
        quaternion.eulerAngles = new Vector3(0, 180, 0);
        // ������ ĳ���� ����
        GameObject slimeClone = Instantiate(slimePrefab, position, quaternion);
        // ������ ü���� ��Ÿ���� Slider UI ���� �� ����
        SpawnSlimeHPSlider(slimeClone);
    }

    private IEnumerator Alert()
    {
        noMoneyAlert.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        noMoneyAlert.SetActive(false);
    }



}
