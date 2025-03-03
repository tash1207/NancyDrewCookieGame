using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int score = 0;
    int defaultPointsPerCookie = 10;
    int penaltyForWrongCookie = 4;
    int pointsPerCookie;

    void Start()
    {
        pointsPerCookie = defaultPointsPerCookie;
    }

    public int GetScore()
    {
        return score;
    }

    public int GetPointsPerCookie()
    {
        return pointsPerCookie;
    }

    public void WrongCookie()
    {
        pointsPerCookie -= penaltyForWrongCookie;
        Mathf.Clamp(pointsPerCookie, 0, int.MaxValue);
    }

    public void RightCookie()
    {
        ModifyScore(pointsPerCookie);
        pointsPerCookie = defaultPointsPerCookie;
    }

    public void ResetPointsPerCookie()
    {
        pointsPerCookie = defaultPointsPerCookie;
    }

    public void ModifyScore(int amount)
    {
        score += amount;
        Mathf.Clamp(score, 0, int.MaxValue);
    }
}
