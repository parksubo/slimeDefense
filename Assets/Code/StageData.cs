using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 부모 클래스로 ScriptableObject를 사용하면 해당 클래스를 에셋파일 형태로 저장할 수 있고
// CreateAssetMenu를 붙이면 Project View의 Create("+") 메뉴에 메뉴로 등록된다
[CreateAssetMenu]
public class StageData : ScriptableObject  
{
    [SerializeField]
    private Vector2 limitMin;
    [SerializeField]
    private Vector2 limitMax;

    public Vector2 LimitMin => limitMin;
    public Vector2 LimitMax => limitMax;
}

/* Desc : 
 * 현재 스테이지의 화면 내 범위
 * 에셋 데이터로 저장해두고 정보를 불러와서 사용
*/