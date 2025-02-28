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

        GameObject jam = jams[Random.Range(0, jams.Length)];
        GameObject glaze = glazes[Random.Range(0, glazes.Length)];
        cookie.AddToppingToCookie(jam);
        cookie.AddToppingToCookie(glaze);

        cookie.AddToppingToCookie(topCookie);
        GameObject sprinkle = sprinkles[Random.Range(0, sprinkles.Length)];
        cookie.AddToppingToCookie(sprinkle);
        GameObject cutout = cutouts[Random.Range(0, cutouts.Length)];
        cookie.AddCutoutToCookie(cutout);
    }
}
