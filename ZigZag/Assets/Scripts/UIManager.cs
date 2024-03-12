using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] GameObject zigZagPanel;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject tapText;
    [SerializeField] TextMeshProUGUI score;
    [SerializeField] TextMeshProUGUI highScore1;
    [SerializeField] TextMeshProUGUI highScore2;

    private static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.Log("UIManager is NULL");
            }
            return instance;
        }
    }


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        highScore1.text = "High Score: "  + PlayerPrefs.GetInt("highScore");
    }

    public void GameStart()
    {
        tapText.SetActive(false);
        zigZagPanel.GetComponent<Animator>().Play("PanelUp");
    }

    public void GameOver()
    {
        score.text = PlayerPrefs.GetInt("score").ToString();
        highScore2.text = PlayerPrefs.GetInt("highScore").ToString();
        gameOverPanel.SetActive(true);
    }

    public void Reset()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }

}
