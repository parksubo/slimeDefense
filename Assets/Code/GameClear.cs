using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameClear : MonoBehaviour
{
    [SerializeField]
    private GameObject gameClearUI;
    [SerializeField]
    private GameObject BGM;
    [SerializeField]
    private GameObject enemySpawner;

    private void Awake()
    {
        gameClearUI.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 적이 Gameover Line에 도착하면
        if (collision.CompareTag("Slime"))
        {
            gameClearUI.SetActive(true);
            Destroy(BGM);
            Destroy(enemySpawner);
        }
    }
}
