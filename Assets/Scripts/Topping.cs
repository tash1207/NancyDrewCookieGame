using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Topping : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] GameObject topping;
    [SerializeField] Transform cookie;

    public bool hasBeenAdded = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        AddObjectToCookie();
    }

    void AddObjectToCookie()
    {
        if (!hasBeenAdded && topping != null && cookie != null)
        {
            cookie.gameObject.GetComponent<Cookie>().AddToppingToCookie(topping);
            hasBeenAdded = true;
        }
    }
}
