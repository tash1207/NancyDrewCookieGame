using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    [SerializeField] GameObject timerCanvas;
    [SerializeField] TMP_Text timerText;

    [SerializeField] GameObject gameOverCanvas;
    [SerializeField] TMP_Text gameOverScoreText;

    float totalTime = 60f;
    float timeLeft;

    bool timerOn = false;
    bool timerModeEnabled = true;

    void Update()
    {
        if (timerModeEnabled && timerOn)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                UpdateTimer(timeLeft);
            }
            else
            {
                StopTimer();
                gameOverScoreText.text = FindObjectOfType<ScoreKeeper>().GetScore().ToString();
                gameOverCanvas.SetActive(true);
            }
        }
    }

    void UpdateTimer(float currentTime)
    {
        timerText.text = Mathf.Ceil(currentTime).ToString();
    }

    public void StartTimer()
    {
        if (timerModeEnabled && !timerOn)
        {
            timerOn = true;
            timeLeft = totalTime;
        }
    }

    void StopTimer()
    {
        timeLeft = 0;
        timerOn = false;
        FindObjectOfType<TipsManager>().StopTimer();
    }

    public bool IsTimerModeEnabled()
    {
        return timerModeEnabled;
    }

    public void SetTimerModeEnabled(bool value)
    {
        timeLeft = totalTime;
        UpdateTimer(timeLeft);

        timerModeEnabled = value;
        timerCanvas.SetActive(timerModeEnabled);

        // Reset tip timer and score
        FindObjectOfType<TipsManager>().SetTipModeEnabled(enabled);
        FindObjectOfType<ScoreKeeper>().ResetScore();
    }

    public void PlayAgain()
    {
        gameOverCanvas.SetActive(false);
        FindObjectOfType<ScoreKeeper>().ResetScore();
        FindObjectOfType<GameManager>().StartGame();
    }
}
