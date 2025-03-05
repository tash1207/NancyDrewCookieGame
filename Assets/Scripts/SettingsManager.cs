using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] GameObject settingsCanvas;

    [SerializeField] Toggle tipModeToggle;
    [SerializeField] Toggle timerModeToggle;
    [SerializeField] Toggle musicToggle;

    bool timerModeJustEnabled = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        ToggleSettingsMenu();
    }

    public void ToggleSettingsMenu()
    {
        if (settingsCanvas.activeSelf)
        {
            if (timerModeJustEnabled)
            {
                timerModeJustEnabled = false;
                FindObjectOfType<GameManager>().StartGame();
            }
            settingsCanvas.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            SetToggleStates();
            settingsCanvas.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void SetToggleStates()
    {
        tipModeToggle.isOn = FindObjectOfType<TipsManager>().IsTipModeEnabled();
        timerModeToggle.isOn = FindObjectOfType<TimerManager>().IsTimerModeEnabled();
        musicToggle.isOn = FindObjectOfType<AudioSource>().isPlaying;
    }

    public void ToggleTipMode(bool enabled)
    {
        if (!enabled)
        {
            // Timer mode needs tip mode enabled.
            FindObjectOfType<TimerManager>().SetTimerModeEnabled(false);
            timerModeToggle.isOn = false;
        }
        FindObjectOfType<TipsManager>().SetTipModeEnabled(enabled);
    }

    public void ToggleTimerMode(bool enabled)
    {
        if (enabled)
        {
            // Timer mode needs tip mode enabled.
            FindObjectOfType<TipsManager>().SetTipModeEnabled(true);
            tipModeToggle.isOn = true;
            timerModeJustEnabled = true;
        }
        FindObjectOfType<TimerManager>().SetTimerModeEnabled(enabled);
    }

    public void ToggleBackgroundMusic(bool enabled)
    {
        if (enabled)
        {
            FindObjectOfType<AudioSource>().Play();
        }
        else
        {
            FindObjectOfType<AudioSource>().Pause();
        }
    }
}
