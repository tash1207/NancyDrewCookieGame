using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TipsManager : MonoBehaviour
{
    [SerializeField] GameObject tipCanvas;
    [SerializeField] TMP_Text tipText;

    float totalTime = 60f;
    float timeLeft;
    int tipPoints = 10;

    bool timerOn = false;
    bool tipModeEnabled = true;

    void Update()
    {
        if (tipModeEnabled && timerOn && timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            UpdateTips(timeLeft);
        }
    }

    void UpdateTips(float currentTime)
    {
        tipPoints = (int) Mathf.Ceil(currentTime / 6);
        tipText.text = tipPoints.ToString();
    }

    public int GetTipPoints()
    {
        return tipModeEnabled ? tipPoints : 0;
    }

    public void StartTimer()
    {
        timerOn = true;
        timeLeft = totalTime;
        tipPoints = 10;
    }

    public void StopTimer()
    {
        timerOn = false;
        timeLeft = 0;
        tipPoints = 0;
    }

    public bool IsTipModeEnabled()
    {
        return tipModeEnabled;
    }

    public void SetTipModeEnabled(bool value)
    {
        // To prevent cheating by enabling tip timer after finishing cookie.
        timeLeft = 0;
        tipPoints = 0;
        tipText.text = tipPoints.ToString();

        tipModeEnabled = value;
        tipCanvas.SetActive(tipModeEnabled);
    }
}
