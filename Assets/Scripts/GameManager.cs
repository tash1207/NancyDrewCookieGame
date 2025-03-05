using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        ResetToppingsAndWorkingCookie();
        ResetCookieOrder();
    }

    public void ResetToppingsAndWorkingCookie()
    {
        foreach (Topping topping in FindObjectsOfType<Topping>())
        {
            topping.hasBeenAdded = false;
        }

        foreach (Cutout cutout in FindObjectsOfType<Cutout>())
        {
            cutout.hasBeenAdded = false;
        }

        foreach (Cookie cookie in FindObjectsOfType<Cookie>())
        {
            if (cookie.gameObject.tag == "WorkingCookie")
            {
                cookie.Reset();
            }
        }
    }
    
    public void ResetCookieOrder()
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
        
        FindObjectOfType<TipsManager>().StartTimer();
        FindObjectOfType<TimerManager>().StartTimer();
    }

    public void ExitToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
