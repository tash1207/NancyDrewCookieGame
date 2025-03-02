using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIDisplay : MonoBehaviour
{
    [SerializeField] GameObject infoCanvas;
    [SerializeField] TMP_Text infoText;
    [SerializeField] TMP_Text scoreText;

    ScoreKeeper scoreKeeper;

    void Start()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void Update()
    {
        scoreText.text = scoreKeeper.GetScore().ToString();   
    }

    public void ShowCookieSuccessMessage()
    {
        string successMessage = Random.Range(0, 2) == 0 ? "It's a masterpiece!" : "Done!";
        ShowInfoMessage(successMessage);
    }

    public void ShowCookieWrongMessage()
    {
        ShowInfoMessage("Hmm that wasn't right");
    }

    public void ShowCookieFailedMessage()
    {
        ShowInfoMessage("Is there such a thing as a wrong cookie?");
    }

    public void ShowInfoMessage(string message)
    {
        StartCoroutine(DisplayMessage(message));
    }

    IEnumerator DisplayMessage(string message)
    {
        infoText.SetText(message);
        infoCanvas.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        infoText.SetText("");
        infoCanvas.SetActive(false);
    }
}
