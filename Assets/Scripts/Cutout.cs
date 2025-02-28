using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cutout : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] GameObject mask;
    [SerializeField] Transform cookie;

    public bool hasBeenAdded = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        AddMaskToCookie();
    }

    void AddMaskToCookie()
    {
        if (!HasAlreadyAddedCutout() && mask != null && cookie != null)
        {
            hasBeenAdded = cookie.gameObject.GetComponent<Cookie>().AddCutoutToCookie(mask);
        }
    }

    bool HasAlreadyAddedCutout()
    {
        foreach (Cutout cutout in FindObjectsOfType<Cutout>())
        {
            if (cutout.hasBeenAdded)
            {
                return true;
            }
        }
        return false;
    }
}
