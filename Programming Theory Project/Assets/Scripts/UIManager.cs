using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoreText;
    public GameObject gameOverObject;
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        DisplayScore();
    }

    public void UpdateScore(int score)
    {
        if (DataManager.Instance != null)
        {
            DataManager.Instance.Score += score;
            DisplayScore();

            if (DataManager.Instance.Score == 0)
            {
                gameManager.GameOver();
                gameOverObject.SetActive(true);
            }
        }
    }

    void DisplayScore()
    {
        if (DataManager.Instance != null)
        {
            scoreText.text = $"{DataManager.Instance.Name}'s score: {DataManager.Instance.Score}";
        }
    }
}
