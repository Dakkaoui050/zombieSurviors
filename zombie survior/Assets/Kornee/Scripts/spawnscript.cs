using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnscript : MonoBehaviour
{
    public GameObject NormaleZombie;
    public GameObject[] spawners;
    public float time = 0;
    public int spawning;
    

    void Start()
    {
        
    }

    private void Update()
    {
        time += Time.deltaTime;

        Debug.Log(time);
        
        

        if(time >= 1)
        {
            Instantiate(NormaleZombie, spawners[spawning].transform);
            time = 0;
            spawning += 1;
        }
        if (spawning == 4)
        {
            spawning = 0;
        }
    }



}
