using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Interactable : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] GameObject topping;
    [SerializeField] Transform cookie;

    bool hasBeenAdded = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Topping clicked");
        AddObjectToCookie();
    }

    void AddObjectToCookie()
    {
        if (!hasBeenAdded && topping != null && cookie != null)
        {
            GameObject toppingGameObject =
                Instantiate(topping, cookie.position, topping.transform.rotation);
            hasBeenAdded = true;
        }
    }
}
