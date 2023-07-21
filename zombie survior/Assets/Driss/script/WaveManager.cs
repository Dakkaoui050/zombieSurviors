using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public Wave[] waves;                   // Array of waves 
    public GameObject bossPrefab;          // Reference to the boss zombie prefab
    public float timeBetweenWaves = 5f;    // Time delay between waves
    public Transform spawnPoint;           // Spawn point for enemies and bosses

    private int currentWaveIndex = 0;      // Index of the current wave
    private bool isSpawningWave = false;   // Flag to check if a wave is currently spawning

    private void Start()
    {
        StartNextWave();
    }

    private void Update()
    {
        // Check if the current wave is finished
        if (isSpawningWave && ZombieCount() == 0)
        {
            isSpawningWave = false;
            Invoke("StartNextWave", timeBetweenWaves);
        }
    }

    private void StartNextWave()
    {
        if (currentWaveIndex < waves.Length)
        {
            // Spawn the zombies for the current wave
            StartCoroutine(SpawnZombies(waves[currentWaveIndex]));

            currentWaveIndex++;
        }
        else
        {
            // between waves
            currentWaveIndex = 0;
            StartNextWave();
        }
    }

    private IEnumerator SpawnZombies(Wave wave)
    {
        isSpawningWave = true;
        for (int i = 0; i < wave.numberOfEnemies; i++)
        {
            // Spawn a random zombies
            GameObject enemyPrefab = wave.enemyPrefabs[Random.Range(0, wave.enemyPrefabs.Length)];
            GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);

            yield return new WaitForSeconds(wave.timeBetweenSpawns);
        }

        // Spawn the boss zombie
        if (currentWaveIndex == waves.Length)
        {
            SpawnBoss();
        }
    }

    private void SpawnBoss()
    {
        // Spawn the boss prefab at the spawnPoint
        Instantiate(bossPrefab, spawnPoint.position, Quaternion.identity);
    }

    // Helper method to count the number of zombie in the scene
    private int ZombieCount()
    {
        return GameObject.FindGameObjectsWithTag("Enemy").Length;
    }
}
