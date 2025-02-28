using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public void Serve()
    {
        // TODO: Check working cookie against cookie order and spawn new cookie.
    }

    public void Reset()
    {
        foreach (Topping topping in FindObjectsOfType<Topping>())
        {
            topping.hasBeenAdded = false;
        }

        FindObjectOfType<Cookie>().Reset();
    }
}
