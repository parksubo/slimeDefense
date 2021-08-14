using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyBGM : MonoBehaviour
{

    void Awake()
    {
        var objs = FindObjectsOfType<DontDestroyBGM>();
        if (objs.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}

/*
 * 
 * 
 * desc :  �ı��ϰ���� ���� ������Ʈ�� �����ؼ� ���
 */