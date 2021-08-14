using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private StageData stageData;    // 적 생성을 위한 스테이지 크기 정보
    [SerializeField]
    private GameObject enemyPrefab; // 복제해서 생성할 적 캐릭터 프리팹
    [SerializeField]
    private float spawnTime;    // 생성주기
    [SerializeField]
    private float enemySize = 3.0f;    // 적 크기
    [SerializeField]
    private float enemyX = 6.0f;       // 적 스폰 x위치
    [SerializeField]
    private float enemyY = -4.0f;       // 적 스폰 y위치
    [SerializeField]
    private GameObject enemyHPSliderPrefab; // 적 체력을 나타내는 Slider UI 프리팹
    [SerializeField]
    private Transform canvasTransform;  // UI를 표현하는 Canvas 오브젝트의 Transform

    private void Awake()
    {
        StartCoroutine("SpawnEnemy");
    }

    private IEnumerator SpawnEnemy()
    {
        while(true)
        {
            // 적 스폰 위치
            Vector3 position = new Vector3(stageData.LimitMax.x + enemyX, enemyY, 0.0f);
            // 적 캐릭터 생성
            GameObject enemyClone = Instantiate(enemyPrefab, position, Quaternion.identity);
            // 적 크기 설정
            enemyClone.transform.localScale = new Vector3(enemySize, enemySize, 0.0f);
            // 적 체력을 나타내는 Slider UI 생성 및 설정
            SpawnEnemyHPSlider(enemyClone);
            
            // spawnTime만큼 대기
            yield return new WaitForSeconds(spawnTime);
        }
    }

    private void SpawnEnemyHPSlider(GameObject enemy)
    {
        // 적 체력을 나타내는 Slider UI 생성
        GameObject sliderClone = Instantiate(enemyHPSliderPrefab);
        // Slider UI 오브젝트를 parent("Canvas" 오브젝트)의 자식으로 설정
        // Tip. UI는 캔버스의 자식오브젝트로 설정되어 있어야 화면에 보인다. 중요 ★
        sliderClone.transform.SetParent(canvasTransform);
        // 계층 설정으로 바뀐 크기를 다시 (1, 1, 1)로 설정
        sliderClone.transform.localScale = Vector3.one;

        // Slider UI가 쫓아다닐 대상을 본인으로 설정
        sliderClone.GetComponent<SliderPositionAutoSetter>().Setup(enemy.transform);
        // Slider UI에 자신의 체력 정보를 표시하도록 설정
        sliderClone.GetComponent<EnemyHPViewer>().Setup(enemy.GetComponent<EnemyHP>());
    }

}
