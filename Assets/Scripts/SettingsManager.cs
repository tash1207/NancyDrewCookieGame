using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] GameObject settingsCanvas;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (settingsCanvas.activeSelf)
        {
            settingsCanvas.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            settingsCanvas.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void ToggleTipMode(bool enabled)
    {
        FindObjectOfType<TipsManager>().SetTipModeEnabled(enabled);
    }
}
