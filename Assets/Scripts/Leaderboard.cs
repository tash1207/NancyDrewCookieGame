using System.Collections;
using System.Collections.Generic;
using Dan.Main;
using TMPro;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    [SerializeField] GameObject leaderboardCanvas;
    [SerializeField] TMP_Text currentScoreText;

    [SerializeField] List<TMP_Text> names;
    [SerializeField] List<TMP_Text> scores;
    [SerializeField] List<TMP_Text> letters;

    [SerializeField] TMP_Text yourName;
    [SerializeField] TMP_Text yourScore;

    string publicKey = "f89591566e2ce0c7d409e7bfd9cf27ba1c2b751b9246d31da3cb0efb80fa415e";

    public void ShowLeaderboard()
    {
        if (currentScoreText != null)
        {
            currentScoreText.text = FindObjectOfType<ScoreKeeper>().GetScore().ToString();
        }
        GetLeaderBoard();
        leaderboardCanvas.SetActive(true);
    }

    public void HideLeaderboard()
    {
        leaderboardCanvas.SetActive(false);
    }

    public void GetLeaderBoard()
    {
        LeaderboardCreator.GetLeaderboard(publicKey, ((msg) =>
        {
            int listLength = (msg.Length < names.Count) ? msg.Length : names.Count;
            for (int i = 0; i < listLength; i++)
            {
                names[i].text = msg[i].Username;
                scores[i].text = msg[i].Score.ToString();
                if (msg[i].IsMine())
                {
                    names[i].color = Color.green;
                    scores[i].color = Color.green;
                }
                else
                {
                    names[i].color = Color.white;
                    scores[i].color = Color.white;
                }
            }
        }));

        LeaderboardCreator.GetPersonalEntry(publicKey, ((msg) =>
        {
            yourName.text = msg.Username;
            yourScore.text = msg.Score.ToString();
        }));
    }

    public void SubmitScore()
    {
        string name = "";
        for (int i = 0; i < letters.Count; i++)
        {
            name += letters[i].text;
        }

        if (name.Length > 0 && name != "      ")
        {
            int score = 0;
            if (FindObjectOfType<ScoreKeeper>() != null)
            {
                score = FindObjectOfType<ScoreKeeper>().GetScore();
            }

            AddLeaderBoardEntry(name.ToUpper(), score);
        }
    }

    void AddLeaderBoardEntry(string username, int score)
    {
        LeaderboardCreator.UploadNewEntry(publicKey, username, score, ((_) =>
        {
            GetLeaderBoard();
        }));
    }
}
