using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   // UI ���� �ٷ궧 �߰�

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
 * �������� ü�� ������ Slider UI�� ������Ʈ
 */