using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public GameObject[] enemyPrefabs;   // Array of zombies prefabs for this wave
    public int numberOfEnemies;         // Number of zombies to spawn in this wave
    public float timeBetweenSpawns;     // Time delay tussen zombie spawns
}
