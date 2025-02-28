using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cookie : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Cookie clicked");
    }

    public void AddToppingToCookie(GameObject topping)
    {
        Instantiate(topping, gameObject.transform);
        // TODO: Set order in layer
    }

    public bool AddCutoutToCookie(GameObject cutout)
    {
        if (HasTopCookie())
        {
            SetMaskInteractions();
            Instantiate(cutout, gameObject.transform);
            return true;
        }
        else
        {
            Debug.Log("Needs top cookie first!!");
            return false;
        }
    }

    bool HasTopCookie()
    {
        for (int i = 1; i < transform.childCount; i++)
        {
            GameObject child = transform.GetChild(i).gameObject;
            if (child.tag == "TopCookie")
            {
                child.GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.VisibleOutsideMask;
                return true;
            }
        }
        return false;
    }

    void SetMaskInteractions()
    {
        bool pastTopCookieLayer = false;
        for (int i = 1; i < transform.childCount; i++)
        {
            GameObject child = transform.GetChild(i).gameObject;
            if (child.tag == "TopCookie")
            {
                pastTopCookieLayer = true;
            }
            child.GetComponent<SpriteRenderer>().maskInteraction =
                pastTopCookieLayer ? SpriteMaskInteraction.VisibleOutsideMask : SpriteMaskInteraction.VisibleInsideMask;
        }
    }

    public void Reset()
    {
        for (int i = 1; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}
