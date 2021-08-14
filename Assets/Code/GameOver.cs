using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverUI;
    [SerializeField]
    private GameObject BGM;

    private void Awake()
    {
        gameOverUI.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 적이 Gameover Line에 도착하면
        if (collision.CompareTag("Enemy"))
        {
            gameOverUI.SetActive(true);
            Destroy(BGM);
        }
    }
}
