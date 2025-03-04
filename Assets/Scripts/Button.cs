using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    GameObject workingCookie;
    GameObject cookieOrder;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void PlayDemo()
    {
        SceneManager.LoadScene(2);
    }

    public void ExitDemo()
    {
        SceneManager.LoadScene(0);
    }

    public void Serve()
    {
        foreach (Cookie cookie in FindObjectsOfType<Cookie>())
        {
            if (cookie.gameObject.tag == "WorkingCookie")
            {
                workingCookie = cookie.gameObject;
            }
            else
            {
                cookieOrder = cookie.gameObject;
            }
        }

        bool cookiesMatch = CheckIfCookiesMatch(workingCookie, cookieOrder);
        Reset();

        if (cookiesMatch)
        {
            FindObjectOfType<UIDisplay>().ShowCookieSuccessMessage();
            FindObjectOfType<ScoreKeeper>().RightCookie();
            StartCoroutine(ResetAndSpawnCookie());
        }
        else
        {            
            FindObjectOfType<ScoreKeeper>().WrongCookie();
            if (FindObjectOfType<ScoreKeeper>().GetPointsPerCookie() < 1)
            {
                FindObjectOfType<UIDisplay>().ShowCookieFailedMessage();
                StartCoroutine(ResetAndSpawnCookie());
                return;
            }
            FindObjectOfType<UIDisplay>().ShowCookieWrongMessage();
        }
    }

    IEnumerator ResetAndSpawnCookie()
    {
        FindObjectOfType<ScoreKeeper>().ResetPointsPerCookie();
        cookieOrder.GetComponent<Cookie>().Reset();
        yield return new WaitForEndOfFrame();
        FindObjectOfType<CookieSpawner>().SpawnRandomCookie();
        if (FindObjectOfType<TipsManager>() != null)
        {
            FindObjectOfType<TipsManager>().StartTimer();
        }
    }

    bool CheckIfCookiesMatch(GameObject cookie1, GameObject cookie2)
    {
        if (cookie1 != null && cookie2 != null)
        {
            if (cookie1.transform.childCount == cookie2.transform.childCount)
            {
                for (int i = 1; i < cookie1.transform.childCount; i++)
                {
                    GameObject child1 = cookie1.transform.GetChild(i).gameObject;
                    GameObject child2 = cookie2.transform.GetChild(i).gameObject;
                    if (child1.tag != child2.tag)
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        return false;
    }

    public void Reset()
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
}
