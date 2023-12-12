using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class spawnscript : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] normalZombiesP;
    public GameObject[] bossZombiesP;
    public GameObject WaveTemplate;
    public Enemy[] enemies;
    public int waveCooldown = 30;
    public int normalZombiesPerWave = 2;
    public int bossWaveInterval = 6;
    public int Diff = 1;
    public int waveNumber = 0;
    private int currentNormalZombie = 0;
    public player player;

    public bool isSpawning = false;
    public float currentCooldownTimer; // Timer for the current cooldown

    

    void Start()
    {
        Diff = PlayerPrefs.GetInt("Diff");
        if(Diff == 0)
        {
            Diff = 1;
        }
        bossWaveInterval -= Diff;
        normalZombiesPerWave += Diff;
        player = gameObject.GetComponentInParent<player>();

        // Start the initial wave spawn
        StartWaveSpawn();
    }

    public void Update()
    {
       

        // If not already spawning and all enemies are dead, start the next wave spawn
        if (!isSpawning && AreAllEnemiesDead())
        {
            StartWaveSpawn();
        }
        if (currentCooldownTimer <= 0f)
        {
            StartWaveSpawn();
        }

        currentCooldownTimer -= Time.deltaTime;
        // Update the cooldown timer

    }

    void StartWaveSpawn()
    {
        isSpawning = true;
        currentCooldownTimer = waveCooldown; // Reset the timer
        StartCoroutine(SpawnWave());
    }

    IEnumerator SpawnWave()
    {
        Debug.Log($"de normal zombies per wave is {normalZombiesPerWave}" );
        waveNumber++;
        normalZombiesPerWave += 2 * Diff;
        currentNormalZombie = normalZombiesPerWave;
        


        for (int i = 0; i < currentNormalZombie; i++)
        {
            int randomNormalEnemyIndex = Random.Range(0, normalZombiesP.Length);
            int randomSpawnPointIndex = Random.Range(0, spawnPoints.Length);
            SpawnEnemy(normalZombiesP[randomNormalEnemyIndex], spawnPoints[randomSpawnPointIndex]);
            yield return new WaitForSeconds(1f);
        }

        if (waveNumber % bossWaveInterval == 0)
        {
            int randomBossEnemyIndex = Random.Range(0, bossZombiesP.Length);
            int randomSpawnPointIndex = Random.Range(0, spawnPoints.Length);
            SpawnEnemy(bossZombiesP[randomBossEnemyIndex], spawnPoints[randomSpawnPointIndex]);
        }

        while (currentCooldownTimer > 0)
        {
            yield return null;
            isSpawning = false;
        }

    }
    private void InstanciateWave()
    {
        Instantiate(WaveTemplate);
    }

    private void SpawnEnemy(GameObject enemyPrefab, Transform spawnPoint)
    {
        Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
    }

    private bool AreAllEnemiesDead()
    {
        enemies = FindObjectsOfType<Enemy>();

        if (enemies.Length == 0)
        {
            return true;
        }
        else
        {
            return false; // All enemies are dead

        }
    }
}



