using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;

// Leaderboard: DNF
public class LeaderboardScript : MonoBehaviour
{
    public float templateHeight = 45f;
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<HighScoreEntry> highscoreEntryList;
    private List<Transform> highscoreEntryTransformList;


    private void Awake()
    {
        entryContainer = transform.Find("HighScoreContainer");
        entryTemplate = entryContainer.Find("HighScoreEntryTemplate");
        entryTemplate.gameObject.SetActive(false);
        //highscoreEntryList = new List<HighScoreEntry>()
    
    }

    private void CreatHighScoreEntryTransform(HighScoreEntry highscoreEntry, Transform container, List<Transform> transformList)
    {
            templateHeight = 30f;

            Transform entryTransform = Instantiate(entryTemplate, container);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
            entryTransform.gameObject.SetActive(true);

            // Leaderboard ranking
            int rank = transformList.Count + 1;
            string rankString;

            switch (rank)
            {
                default:
                    rankString = rank + "TH";
                    break;
                case 1: rankString = "1ST";
                    break;
                case 2: rankString = "2ND";
                    break;
                case 3: rankString = "3RD";
                    break;
            }

            entryTransform.Find("Pos").GetComponent<Text>().text = rankString;
            
            string name = highscoreEntry.name;
            entryTransform.Find("Name").GetComponent<Text>().text = name;
          
            int score = highscoreEntry.score;
            entryTransform.Find("Score").GetComponent<Text>().text = score.ToString();

            transformList.Add(entryTransform);
    }
    private class HighScoreEntry
    {
        public int score;
        public string name;
    }

}
