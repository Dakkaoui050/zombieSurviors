using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine.UI;
using TMPro;
using System.Text;
using Unity.VisualScripting;

[Serializable]
public class PlayerData
{
    public string name;
    public int score;
}

public class HighScoreSystem : MonoBehaviour
{
    public Transform leaderboardContent;
    public TextMeshProUGUI leaderboardText;
    public string jsonFileName = "";
    public ScrollRect scrollRect;
    public spawnscript Spawnscript;
    public XP_points xP;
    public player[] p;
    public int maxEntries = 5; // Maximum number of entries to keep in the leaderboard
    private List<PlayerData> leaderboardEntries = new List<PlayerData>();
    [SerializeField] private bool InMenu = false;

    void Start()
    {
        
    }
    private void Awake()
    {
        if(InMenu)
        {
            LoadLeaderboard();
            SortLeaderboard();
            DisplayLeaderboard();
        }
    }
    private void FixedUpdate()
    {
        
            if (p[0].dead || p[1].dead)
            {   
                LoadLeaderboard();
                AddEntry();
                SortLeaderboard();
                DisplayLeaderboard();
                Time.timeScale = 0;
            }

        
    }

    public void SaveLeaderboard()
    {
        // Sort the leaderboard before saving
        // Serialize the leaderboard to JSON
        string jsonData = JsonUtility.ToJson(new LeaderboardData { entries = leaderboardEntries });
        byte[] bytesToEncode = Encoding.UTF8.GetBytes(jsonData);
        string base64Encoded = Convert.ToBase64String(bytesToEncode);
        // Get the path to the Documents folder
        string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        // Combine the Documents path with your desired subfolder (if any) and the file name
        string filePath = Path.Combine(documentsPath, "ZombieSurvivor", jsonFileName);
        string directoryPath = Path.GetDirectoryName(filePath);
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }
        if (!File.Exists(filePath))
        {
            // You can create an empty JSON file here or initialize it with some data.
            // For example, you can create an empty JSON object and save it.
            string emptyJsonData = "{}";
            byte[] ArrayToEncode = Encoding.UTF8.GetBytes(emptyJsonData);
            string EmptyArryBase64 = Convert.ToBase64String(ArrayToEncode);
            File.WriteAllText(filePath, EmptyArryBase64);
            Debug.Log("JSON File created: " + filePath);
        }
        else
        {
            File.WriteAllText(filePath, base64Encoded);
            Debug.Log("Leaderboard saved to: " + filePath);
        }
        // Write the JSON data to the file
        

    }

    public void LoadLeaderboard()
    {
        // Get the path to the Documents folder
        string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        // Combine the Documents path with your desired subfolder (if any) and the file name
        string filePath = Path.Combine(documentsPath, "ZombieSurvivor", jsonFileName);

        // Check if the file exists
        if (File.Exists(filePath))
        {
            // Read the JSON data from the file
            string base64Encoded = File.ReadAllText(filePath);

            // Decode the Base64 data to get the JSON string
            byte[] bytesToDecode = Convert.FromBase64String(base64Encoded);
            string jsonData = Encoding.UTF8.GetString(bytesToDecode);


            // Deserialize the JSON data into the leaderboard list
            LeaderboardData data = JsonUtility.FromJson<LeaderboardData>(jsonData);
            leaderboardEntries = data.entries;

            Debug.Log("Leaderboard loaded from: " + filePath);
        }
        else
        {
            // If the file doesn't exist, create an empty leaderboard
            leaderboardEntries = new List<PlayerData>();
        }
    }

    public void SortLeaderboard()
    {
        // Sort the leaderboard in descending order of score
        if (leaderboardEntries.Count > 1)
        {
            leaderboardEntries.Sort((a, b) => b.score.CompareTo(a.score));
        }

        // Ensure the leaderboard doesn't exceed the maximum number of entries
        if (leaderboardEntries.Count > maxEntries)
        {
            leaderboardEntries.RemoveRange(maxEntries, leaderboardEntries.Count - maxEntries);
        }

        // Save the sorted leaderboard
        SaveLeaderboard();
    }

    public void AddEntry()
    {
        // Create a new player data entry
        if (p[0].player2)
        {
            PlayerData newEntry = new PlayerData { name = PlayerPrefs.GetString("P2"), score = (p[0].killcount * Spawnscript.waveNumber + (int)xP.CurrentLevel)};
            print(newEntry.name + newEntry.score);
            leaderboardEntries.Add(newEntry);
        }
        else
        {
            PlayerData newEntry = new PlayerData { name = PlayerPrefs.GetString("P1"), score = (p[0].killcount * Spawnscript.waveNumber + (int)xP.CurrentLevel) };
            print(newEntry.name + newEntry.score);
            leaderboardEntries.Add(newEntry);
        }
        // Add the entry to the leaderboard

        // Sort the leaderboard with the new entry
        SortLeaderboard();
    }

    public void ClearLeaderboard()
    {
        // Destroy all TextMeshPro children of the leaderboardText object
        foreach (Transform child in leaderboardContent)
        {
            Destroy(child.gameObject);
        }
    }

    public void DisplayLeaderboard()
    {
        // Sort the leaderboard entries by score (you can customize the sorting logic)
        leaderboardEntries.Sort((a, b) => b.score.CompareTo(a.score));
        float totalHeight = 20f;
        // Determine the place dynamically and format each entry
        for (int i = 0; i < leaderboardEntries.Count; i++)
        {
            PlayerData entry = leaderboardEntries[i];

            // Calculate the place (add 1 because it's 0-based)
            int place = i + 1;

            // Instantiate the leaderboard entry TextMeshPro object
            TextMeshProUGUI entryText = Instantiate(leaderboardText, leaderboardContent);

            // Format the entry as a string with two tab spaces
            string formattedEntry = $"{place}\t\t{entry.name}\t\t{entry.score}";

            // Set the Text of the TextMeshPro object
            entryText.text = formattedEntry;

            RectTransform entryTransform = entryText.GetComponent<RectTransform>();
            entryTransform.anchoredPosition = new Vector2(entryTransform.anchoredPosition.x, -totalHeight);

            // Increase the total height
            totalHeight += entryTransform.sizeDelta.y;
        }
        RectTransform contentRectTransform = leaderboardContent.GetComponent<RectTransform>();
        contentRectTransform.sizeDelta = new Vector2(contentRectTransform.sizeDelta.x, totalHeight);

        // Scroll to the top of the content
        scrollRect.normalizedPosition = new Vector2(0, 1);
    }

}

[Serializable]
public class LeaderboardData
{
    public List<PlayerData> entries;
}
