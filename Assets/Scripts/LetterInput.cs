using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LetterInput : MonoBehaviour
{
    [SerializeField] TMP_Text letterText;

    string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ ";
    int alphabetIndex = 0;

    public void OnButtonUp()
    {
        alphabetIndex++;
        if (alphabetIndex > 26)
        {
            alphabetIndex = 0;
        }
        letterText.text = alphabet[alphabetIndex].ToString();
    }

    public void OnButtonDown()
    {
        alphabetIndex--;
        if (alphabetIndex < 0)
        {
            alphabetIndex = 26;
        }
        letterText.text = alphabet[alphabetIndex].ToString();
    }
}
