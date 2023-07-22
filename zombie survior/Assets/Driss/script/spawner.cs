using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class spawner : MonoBehaviour
{
    [SerializeField] public float spawnRate = 1f;
    [SerializeField] public GameObject[] ZombiePrefabs;
    [SerializeField] public bool CanSpawn = true;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ZombieSpawner());
    }
    private IEnumerator ZombieSpawner()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);

        while (CanSpawn)
        {
            yield return wait;
            int rand = Random.Range(0, ZombiePrefabs.Length);
            GameObject ZombieToSpawn = ZombiePrefabs[rand];

            Instantiate(ZombieToSpawn, transform.position, Quaternion.identity);
        }
    }
}
