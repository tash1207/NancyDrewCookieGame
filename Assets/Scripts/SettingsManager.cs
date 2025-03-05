using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] GameObject settingsCanvas;

    public void OnPointerDown(PointerEventData eventData)
    {
        ToggleSettingsMenu();
    }

    public void ToggleSettingsMenu()
    {
        Debug.Log("toggle menu");
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

    public void ExitToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
