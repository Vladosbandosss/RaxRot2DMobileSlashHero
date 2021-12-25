using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    [SerializeField] private Canvas gameOverCanvas;

    [SerializeField] private Text currentScore, bestScore;

    private ScoreCounter _scoreCounter;

    private void Awake()
    {
        _scoreCounter = GetComponent<ScoreCounter>();
    }

    public void GameOverShowPanel()
    {
        gameOverCanvas.gameObject.SetActive(true);
        
        Time.timeScale = 0f;
      
        DisplayScore();
        
        CheCkToUnlockNewCharacters(_scoreCounter.GetScore());
    }

    private void DisplayScore()
    {
        currentScore.text = "Score: " + _scoreCounter.GetScore() +"m";
        
    }

    private void CheCkToUnlockNewCharacters(int score)
    {
        
    }
    
    
}
