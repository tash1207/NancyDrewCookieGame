using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        foreach (Cookie cookie in FindObjectsOfType<Cookie>())
        {
            if (cookie.gameObject.tag == "CookieOrder")
            {
                ResetAndSpawnCookie(cookie);
            }
        }
    }

    public void ResetAndSpawnCookie(Cookie cookieOrder)
    {
        StartCoroutine(ResetThenSpawnCookie(cookieOrder));
    }

    IEnumerator ResetThenSpawnCookie(Cookie cookieOrder)
    {
        FindObjectOfType<ScoreKeeper>().ResetPointsPerCookie();
        cookieOrder.Reset();
        yield return new WaitForEndOfFrame();
        FindObjectOfType<CookieSpawner>().SpawnRandomCookie();
        if (FindObjectOfType<TipsManager>() != null)
        {
            FindObjectOfType<TipsManager>().StartTimer();
        }
    }
}
