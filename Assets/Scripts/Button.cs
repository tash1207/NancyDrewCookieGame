using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    GameObject workingCookie;
    GameObject cookieOrder;

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
        Debug.Log("Cookies match: " + cookiesMatch);
        Reset();

        // TODO: Add to score
        if (cookiesMatch)
        {
            StartCoroutine(ResetAndSpawnCookie());
        }
    }

    IEnumerator ResetAndSpawnCookie()
    {
        cookieOrder.GetComponent<Cookie>().Reset();
        yield return new WaitForEndOfFrame();
        FindObjectOfType<CookieSpawner>().SpawnRandomCookie();
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
