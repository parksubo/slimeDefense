using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private int slimeNumber = 3;
    private static bool init = false;   // 초기 설정을 위한 변수
    private AudioSource audioSource;

    private static bool play;       // 오디오 재생을 위한 변수
    public bool Play
    {
        set => play = value;
        get => play;
    }

    private static int money;
    public int Money
    {
        // money의 값이 음수가 되지 않도록
        set => money = Mathf.Max(0, value);
        get => money;
    }

    private static bool[] slimeActive = new bool[3];
    public bool GetSlimeActive(int i)
    {
        return slimeActive[i];
    }
    public void SetSlimeActive(int i)
    {
        slimeActive[i] = true;
    }


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if(init == false)    // 초기 골드 설정
        {
            init = true;
            money = 100;    // 초기 골드 100원
            for (int i = 0; i < slimeNumber; i++) slimeActive[i] = false;   // 모든 슬라임 비활성화
        }
        play = false;

    } 

    private void Update()
    {
        if (play == true)
        {
            play = false;
            StartCoroutine("PlayOnce");
        }          
    }

    private IEnumerator PlayOnce()
    {
        audioSource.Play();
        yield return new WaitForSeconds(0.5f);
    }
}
