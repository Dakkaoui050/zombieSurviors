using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreTable : MonoBehaviour
{
    player_Kale_Man player;
    spawnscript spawnscript;
    public GameObject higscoreScreen;
    bool updated = false;

    private float templateHeight = 20f;
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<HighscoreEntry> highscoreEntryList;
    private List<Transform> highsoreEntryTransformList;

    private void Update()
    {
        if (player.HP <= 0 && updated == false) 
        {
            updated = true;
            AddHighscoreEntry(spawnscript.waveNumber, "name");
            higscoreScreen.SetActive(true);
        }
    }
    private void Awake()
    {
        spawnscript = GameObject.FindGameObjectWithTag("spawnmanager").GetComponent<spawnscript>(); // pakt de spawnscript voor de wave nummer
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<player_Kale_Man>(); // pakt de player zijn health

        entryContainer = transform.Find("HighscoreEntryContainer");
        entryTemplate = entryContainer.Find("highscoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);

        //AddHighscoreEntry(1000000, "POL");
        Debug.Log(PlayerPrefs.GetString("highscoreTable"));

        //highscoreEntryList = new List<HighscoreEntry>()
        // {
        //     new HighscoreEntry{score = 0, name = "AAA" },
        //     new HighscoreEntry{score = 0, name = "AAA" },
        //     new HighscoreEntry{score = 0, name = "AAA" },
        //     new HighscoreEntry{score = 0, name = "AAA" },
        //     new HighscoreEntry{score = 0, name = "AAA" },
        //     new HighscoreEntry{score = 0, name = "AAA" },
        //     new HighscoreEntry{score = 0, name = "AAA" },
        //     new HighscoreEntry{score = 0, name = "AAA" },
        // };

        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores1 = JsonUtility.FromJson<Highscores>(jsonString);


        //sort entry list by score
        for (int i = 0; i <highscores1.highscoreEntryList.Count; i++) {
            for (int j = i + 1; j < highscores1.highscoreEntryList.Count; j++){
                if (highscores1.highscoreEntryList[j].score > highscores1.highscoreEntryList[i].score){
                    //swap
                    HighscoreEntry tmp = highscores1.highscoreEntryList[i];
                    highscores1.highscoreEntryList[i] = highscores1.highscoreEntryList[j];
                    highscores1.highscoreEntryList[j] = tmp;
                }
            }
        }

        highsoreEntryTransformList = new List<Transform>();
        foreach (HighscoreEntry highscoreEntry in highscores1.highscoreEntryList)
        {
            CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highsoreEntryTransformList);
        }

        


    }

    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList)
    {
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(20, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString;
        switch (rank)
        {
            default:
                rankString = rank + "TH"; break;
            case 1: rankString = "1ST"; break;
            case 2: rankString = "2ND"; break;
            case 3: rankString = "3RD"; break;
        }

        entryTransform.Find("posText").GetComponent<Text>().text = rankString;

        int score = highscoreEntry.score; //moet wave nummer worden
        entryTransform.Find("scoreText").GetComponent<Text>().text = score.ToString();

        string name = highscoreEntry.name;
        entryTransform.Find("nameText").GetComponent<Text>().text = name;

        transformList.Add(entryTransform);
    }

    private void AddHighscoreEntry(int score, string name)
    {
        HighscoreEntry highscoreEntry = new HighscoreEntry { score = score, name = name };

        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores1 = JsonUtility.FromJson<Highscores>(jsonString);

        highscores1.highscoreEntryList.Add(highscoreEntry);

        string json = JsonUtility.ToJson(highscores1);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();

    }

    private class Highscores
    {
        public List<HighscoreEntry> highscoreEntryList;
    }

    [System.Serializable]
    private class HighscoreEntry
    {
        public int score;
        public string name;

       
    }


}
