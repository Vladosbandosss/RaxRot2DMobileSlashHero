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
        SoundManager.instance.PlayGameOverSound();
        gameOverCanvas.gameObject.SetActive(true);
        
        Time.timeScale = 0f;
      
        DisplayScore();
        
        CheCkToUnlockNewCharacters(_scoreCounter.GetScore());
    }

    private void DisplayScore()
    {
        currentScore.text = "Score: " + _scoreCounter.GetScore() +"m";
        if (PlayerPrefs.HasKey("hightScore"))
        {
            if (_scoreCounter.GetScore() > PlayerPrefs.GetInt("hightScore"))
            {
                PlayerPrefs.SetInt("hightScore",_scoreCounter.GetScore());
                bestScore.text ="HighScore: " + _scoreCounter.GetScore().ToString() + "m";
            } 
            else
            {
                bestScore.text ="HighScore:" +PlayerPrefs.GetInt("hightScore").ToString() + "m";
            }
        }
        else
        {
            PlayerPrefs.SetInt("hightScore",_scoreCounter.GetScore());
            bestScore.text ="HighScore:" +  _scoreCounter.GetScore().ToString() +"m";
        }
        
    }

    private void CheCkToUnlockNewCharacters(int score)
    {
        
    }
    
    
}
