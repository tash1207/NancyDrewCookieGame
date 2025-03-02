using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cookie : MonoBehaviour, IPointerDownHandler
{
    int currentSortingOrder = 1;

    public void OnPointerDown(PointerEventData eventData)
    {
        // Debug.Log("Cookie clicked");
    }

    public void AddToppingToCookie(GameObject topping)
    {
        GameObject toppingGameObject = Instantiate(topping, gameObject.transform);
        toppingGameObject.GetComponent<SpriteRenderer>().sortingOrder = currentSortingOrder;
        currentSortingOrder++;
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
            FindObjectOfType<UIDisplay>().ShowInfoMessage("I need a top cookie first!");
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
            SpriteRenderer spriteRenderer = child.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.maskInteraction = pastTopCookieLayer
                    ? SpriteMaskInteraction.VisibleOutsideMask
                    : SpriteMaskInteraction.VisibleInsideMask;
            }
        }
    }

    public void Reset()
    {
        for (int i = 1; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        currentSortingOrder = 1;
    }
}
