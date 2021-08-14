using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   // UI 변수 다룰때 추가

public class SlimeHPViewer : MonoBehaviour
{
    private SlimeHP slimeHP;
    private Slider hpSlider;

    public void Setup(SlimeHP slimeHP)
    {
        this.slimeHP = slimeHP;
        hpSlider = GetComponent<Slider>();
    }

    private void Update()
    {
        hpSlider.value = slimeHP.CurrentHP / slimeHP.MaxHP;
    }
}

/*
 * Desc :
 * 슬라임의 체력 정보를 Slider UI에 업데이트
 */