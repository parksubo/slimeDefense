using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlimeHouseSpawner : MonoBehaviour
{
    [SerializeField]
    private StageData stageData;    // �������� ũ�� ����
    [SerializeField]
    private GameObject slimePrefab; // ������ �Ͽ콺 ������
    [SerializeField]
    private GameObject slimeHPSliderPrefab; // ü���� ��Ÿ���� Slider UI ������
    [SerializeField]
    private Transform canvasTransform;  // UI�� ǥ���ϴ� Canvas ������Ʈ�� Transform

    [SerializeField]
    private float houseSize = 3.0f;     // �Ͽ콺 ũ��
    [SerializeField]
    private float houseX = -6.0f;       // �Ͽ콺 x��ġ
    [SerializeField]
    private float houseY = -4.0f;       // �Ͽ콺 y��ġ

    private void Awake()
    {
        StartCoroutine("SpawnSlime");
    }

    private void SpawnSlimeHPSlider(GameObject slime)
    {
        // ������ ü���� ��Ÿ���� Slider UI ����
        GameObject sliderClone = Instantiate(slimeHPSliderPrefab);
        // Slider UI ������Ʈ�� parent("Canvas" ������Ʈ)�� �ڽ����� ����
        // Tip. UI�� ĵ������ �ڽĿ�����Ʈ�� �����Ǿ� �־�� ȭ�鿡 ���δ�. �߿� ��
        sliderClone.transform.SetParent(canvasTransform);

        // Slider UI�� �Ѿƴٴ� ����� �������� ����
        sliderClone.GetComponent<SliderPositionAutoSetter>().Setup(slime.transform);
        // Slider UI�� �ڽ��� ü�� ������ ǥ���ϵ��� ����
        sliderClone.GetComponent<SlimeHPViewer>().Setup(slime.GetComponent<SlimeHP>());
    }


    public void SpawnSlime()
    {
        // ������ ���� ��ġ
        Vector3 position = new Vector3(stageData.LimitMin.x + houseX, houseY, 0.0f);
        // ȸ����
        //Quaternion quaternion = Quaternion.identity;
        //quaternion.eulerAngles = new Vector3(0, 180, 0);
        // ������ ĳ���� ����
        GameObject slimeClone = Instantiate(slimePrefab, position, Quaternion.identity);
        // ������ ü���� ��Ÿ���� Slider UI ���� �� ����
        SpawnSlimeHPSlider(slimeClone);
    }

}
