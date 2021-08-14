using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private int slimeNumber = 3;
    private static bool init = false;   // �ʱ� ������ ���� ����
    private AudioSource audioSource;

    private static bool play;       // ����� ����� ���� ����
    public bool Play
    {
        set => play = value;
        get => play;
    }

    private static int money;
    public int Money
    {
        // money�� ���� ������ ���� �ʵ���
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
        if(init == false)    // �ʱ� ��� ����
        {
            init = true;
            money = 100;    // �ʱ� ��� 100��
            for (int i = 0; i < slimeNumber; i++) slimeActive[i] = false;   // ��� ������ ��Ȱ��ȭ
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
