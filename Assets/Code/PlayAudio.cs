using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{

    private AudioSource audioSource;                // 구매 성공시 사운드

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private IEnumerator Play()
    {
        audioSource.Play();
        yield return new WaitForSeconds(0.5f);
    }
}
