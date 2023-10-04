using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamemaster : MonoBehaviour
{
    public GameObject playerPrefab;
    public Transform[] spawnPoints;
    public int numberOfPlayers;

    void Start()
    {
        StartCoopGame();
    }

    void StartCoopGame()
    {
        // Instantiate player prefabs for each player
        for (int i = 0; i < numberOfPlayers; i++)
        {
            GameObject playerObject = Instantiate(playerPrefab, spawnPoints[i].position, Quaternion.identity);
            player playerInstance = playerObject.GetComponent<player>();
            playerInstance.playerIndex = i + 1; // Assign a unique player index
        }
    }

}
