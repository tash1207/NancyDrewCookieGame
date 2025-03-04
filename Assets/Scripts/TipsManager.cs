using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TipsManager : MonoBehaviour
{
    [SerializeField] TMP_Text tipText;

    float totalTime = 60f;
    float timeLeft;
    int tipPoints = 10;

    void Update()
    {
        if (timeLeft > 0)
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
        return tipPoints;
    }

    public void StartTimer()
    {
        timeLeft = totalTime;
        tipPoints = 10;
    }
}
