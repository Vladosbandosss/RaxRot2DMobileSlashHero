using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private Text scoreTxt;

    private int scoreCount;

    public int GetScore()
    {
        return scoreCount;
    }
    private float scoreCountTimerTreshHold = 1f;
    private float scoreCountTimer;

    private bool _canCountScore;
    public bool CanCountScore
    {
        get { return _canCountScore; }
        set { _canCountScore = value; }
    }

    private StringBuilder scoreStringBuilder = new StringBuilder();

    private void Start()
    {
        CanCountScore = true;
        scoreCountTimer = Time.time + scoreCountTimerTreshHold;
    }

    private void Update()
    {
        if (!CanCountScore)
        {
            return;
        }

        if (Time.time > scoreCountTimer)
        {
            scoreCountTimer = Time.time + scoreCountTimerTreshHold;
            scoreCount++;
            DisplayScore(scoreCount);
        }
    }

    private void DisplayScore(int score)
    {
        scoreStringBuilder.Length = 0;
        scoreStringBuilder.Append(score);
        scoreStringBuilder.Append("m");
        scoreTxt.text = scoreStringBuilder.ToString();
    }
}
