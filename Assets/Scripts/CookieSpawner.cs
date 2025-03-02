using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieSpawner : MonoBehaviour
{
    [SerializeField] GameObject cookieOrder;

    [SerializeField] GameObject[] jams;
    [SerializeField] GameObject[] sprinkles;
    [SerializeField] GameObject[] glazes;
    [SerializeField] GameObject[] cutouts;
    [SerializeField] GameObject topCookie;

    public void SpawnRandomCookie()
    {
        Cookie cookie = cookieOrder.GetComponent<Cookie>();

        bool useJam = GetBoolWithPercentProbability(90);
        bool useGlaze = GetBoolWithPercentProbability(80);
        bool useSprinkles = GetBoolWithPercentProbability(70);
        bool useCutout = GetBoolWithPercentProbability(80);

        bool useJamAboveTopCookie = useCutout && GetBoolWithPercentProbability(50);
        bool useGlazeAboveTopCookie = useCutout && !useGlaze && GetBoolWithPercentProbability(60);
        bool useSprinklesAboveTopCookie = useCutout && GetBoolWithPercentProbability(50);

        bool useGlazeAboveCutout = useCutout && !useGlaze && !useGlazeAboveTopCookie
            && GetBoolWithPercentProbability(70);
        bool useSprinklesAboveCutout = useCutout && !useSprinkles && !useSprinklesAboveTopCookie
            && GetBoolWithPercentProbability(70);

        bool sprinklesBeforeGlaze = GetBoolWithPercentProbability(40);

        int usedJamIndex = -1;
        int usedSprinklesIndex = -1;
        if (useJam)
        {
            usedJamIndex = Random.Range(0, jams.Length);
            GameObject jam = jams[usedJamIndex];
            cookie.AddToppingToCookie(jam);
        }
        if (useSprinkles && sprinklesBeforeGlaze)
        {
            usedSprinklesIndex = Random.Range(0, sprinkles.Length);
            GameObject sprinkle = sprinkles[usedSprinklesIndex];
            cookie.AddToppingToCookie(sprinkle);
        }
        if (useGlaze)
        {
            GameObject glaze = glazes[Random.Range(0, glazes.Length)];
            cookie.AddToppingToCookie(glaze);
        }
        if (useSprinkles && !sprinklesBeforeGlaze)
        {
            usedSprinklesIndex = Random.Range(0, sprinkles.Length);
            GameObject sprinkle = sprinkles[usedSprinklesIndex];
            cookie.AddToppingToCookie(sprinkle);
        }

        if (useCutout)
        {
            cookie.AddToppingToCookie(topCookie);
            if (useJamAboveTopCookie)
            {
                GameObject jamAboveTopCookie = GetUnusedObjectFromArray(jams, usedJamIndex);
                cookie.AddToppingToCookie(jamAboveTopCookie);
            }
            if (useSprinklesAboveTopCookie && sprinklesBeforeGlaze)
            {
                GameObject sprinkleAboveTopCookie = GetUnusedObjectFromArray(sprinkles, usedSprinklesIndex);
                cookie.AddToppingToCookie(sprinkleAboveTopCookie);
            }
            if (useGlazeAboveTopCookie)
            {
                GameObject glazeAboveTopCookie = glazes[Random.Range(0, sprinkles.Length)];
                cookie.AddToppingToCookie(glazeAboveTopCookie);
            }
            if (useSprinklesAboveTopCookie && !sprinklesBeforeGlaze)
            {
                GameObject sprinkleAboveTopCookie = sprinkles[Random.Range(0, sprinkles.Length)];
                cookie.AddToppingToCookie(sprinkleAboveTopCookie);
            }

            GameObject cutout = cutouts[Random.Range(0, cutouts.Length)];
            cookie.AddCutoutToCookie(cutout);

            if (useSprinklesAboveCutout && sprinklesBeforeGlaze)
            {
                GameObject sprinkleAboveCutout = sprinkles[Random.Range(0, sprinkles.Length)];
                cookie.AddToppingToCookie(sprinkleAboveCutout);
            }
            if (useGlazeAboveCutout)
            {
                GameObject glazeAboveCutout = glazes[Random.Range(0, sprinkles.Length)];
                cookie.AddToppingToCookie(glazeAboveCutout);
            }
            if (useSprinklesAboveCutout && !sprinklesBeforeGlaze)
            {
                GameObject sprinkleAboveCutout = sprinkles[Random.Range(0, sprinkles.Length)];
                cookie.AddToppingToCookie(sprinkleAboveCutout);
            }
        }
    }

    bool GetBoolWithPercentProbability(int percent)
    {
        return Random.Range(0, 100) < percent;
    }

    GameObject GetUnusedObjectFromArray(GameObject[] objects, int usedIndex)
    {
        int randomIndex;
        if (objects.Length == 2)
        {
            randomIndex = usedIndex == 0 ? 1 : 0;
        }
        else
        {
            randomIndex = Random.Range(0, objects.Length);
            while (randomIndex == usedIndex)
            {
                randomIndex = Random.Range(0, objects.Length);
            }   
        }
        return objects[randomIndex];
    }
}
