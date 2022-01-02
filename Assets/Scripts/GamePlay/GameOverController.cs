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

    private string HSCORE = "hightScore";

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
        
    }

    private void DisplayScore()
    {
        currentScore.text = "Score: " + _scoreCounter.GetScore() +"m";
        if (PlayerPrefs.HasKey(HSCORE))
        {
            if (_scoreCounter.GetScore() > PlayerPrefs.GetInt(HSCORE))
            {
                PlayerPrefs.SetInt(HSCORE,_scoreCounter.GetScore());
                bestScore.text ="HighScore: " + _scoreCounter.GetScore().ToString() + "m";
            } 
            else
            {
                bestScore.text ="HighScore:" +PlayerPrefs.GetInt(HSCORE).ToString() + "m";
            }
        }
        
        else
        {
            PlayerPrefs.SetInt(HSCORE,_scoreCounter.GetScore());
            bestScore.text ="HighScore:" +  _scoreCounter.GetScore().ToString() +"m";
        }
        
    }
    
}
