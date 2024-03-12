using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Elements")]
    public static GameManager instance;
    PlatformSpawner spawner;

    [Header("Settings")]
    public bool isGameOver;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        spawner = FindObjectOfType<PlatformSpawner>().GetComponent<PlatformSpawner>();
    }


    public void StartGame()
    {
        UIManager.Instance.GameStart();
        ScoreManager.instance.StartScore();
        spawner.StartSpawning();
        
    }

    public void GameOver()
    {
        UIManager.Instance.GameOver();
        ScoreManager.instance.StopScore();
        isGameOver = true;
    }
}
