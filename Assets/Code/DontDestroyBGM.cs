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
 * desc :  파괴하고싶지 않은 오브젝트에 부착해서 사용
 */