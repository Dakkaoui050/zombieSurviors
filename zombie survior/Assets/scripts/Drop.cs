using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Drop : MonoBehaviour
{
    public Transform spawnpoint;
    public GameObject[] pick = new GameObject[3];
    public player p;

    private void Awake()
    {
        p = GameObject.FindWithTag("Player").GetComponent<player>();
    }
    public void Droping()
    {
        int i = Random.Range(0,101);
        if(i > 90)
        {
            Instantiate(pick[2], new Vector3(spawnpoint.position.x, spawnpoint.position.y, spawnpoint.position.z), new Quaternion(0, 0, 0, 0));
            
        }
        else
        {
            Instantiate(pick[Random.Range(0,2)], new Vector3(spawnpoint.position.x, spawnpoint.position.y, spawnpoint.position.z), new Quaternion(0,0,0,0));
        }
    }
}
