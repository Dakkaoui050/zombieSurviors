using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnscript : MonoBehaviour
{
    public Transform[] spawnPoints; // Array of spawn points
    public GameObject[] normalZombiesP; // Array met normale zombie prefabs
    public GameObject[] bossZombiesP;   // Array met baas zombie prefabs
    public float waveCooldown = 30f;    // Cooldown tussen golven in seconden
    public int normalZombiesPerWave = 5; // Aantal normale zombies om te spawnen in elke golf
    public int bossWaveInterval = 6;    // Tijdsinterval voor het spawnen van baas zombies
    public int Diff;
    public int waveNumber = 0;          // Huidig golftellingnummer
    private int currentNormalZombie = 0; // Teller voor het aantal normale zombies gespawnd in de huidige golf

    void Start()
    {
        StartCoroutine(SpawnWave()); // Start met het spawnen van golven
        Diff = PlayerPrefs.GetInt("Diff");
        bossWaveInterval -= Diff;
        normalZombiesPerWave += Diff;
    }

    IEnumerator SpawnWave()
    {

        while (true)
        {
            waveNumber++; // Increase the wave number for each new wave
            currentNormalZombie += 2; // Increase the number of normal zombies by 2 for each new wave

            // Spawn normal zombies for the current wave
            for (int i = 0; i < currentNormalZombie; i++)
            {
                int randomNormalEnemyIndex = Random.Range(0, normalZombiesP.Length);
                int randomSpawnPointIndex = Random.Range(0, spawnPoints.Length);
                SpawnEnemy(normalZombiesP[randomNormalEnemyIndex], spawnPoints[randomSpawnPointIndex]);
                yield return new WaitForSeconds(1f); // Delay between spawning normal enemies
            }

            // Check if there are any enemies alive
            bool allEnemiesDead = AreAllEnemiesDead();

            // If all enemies are dead, increase waveNumber and currentNormalZombie
            if (allEnemiesDead)
            {
                waveNumber++;
                currentNormalZombie += 2 * Diff;
            }

            // Controleer of het huidige golftellingnummer een veelvoud is van bossWaveInterval
            if (waveNumber % bossWaveInterval == 0)
            {
                // Spawn a boss zombie for the current wave
                int randomBossEnemyIndex = Random.Range(0, bossZombiesP.Length);
                int randomSpawnPointIndex = Random.Range(0, spawnPoints.Length);
                SpawnEnemy(bossZombiesP[randomBossEnemyIndex], spawnPoints[randomSpawnPointIndex]);
            }

            yield return new WaitForSeconds(waveCooldown); // Cooldown between waves
            
            //Shop --->
        }


    }
    private void SpawnEnemy(GameObject enemyPrefab, Transform spawnPoint)
    {
        // Instantiate the enemy at the specified spawn point
        Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
    }
    private bool AreAllEnemiesDead()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();

        foreach (Enemy enemy in enemies)
        {
            if (enemy != null && enemy.gameObject.activeSelf)
            {
                return false; // At least one enemy is still alive
            }
        }

        return true; // All enemies are dead
    }
}



