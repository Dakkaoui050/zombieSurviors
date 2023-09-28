using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Drop : MonoBehaviour
{
    public Transform spawnpoint;
    public GameObject[] pick = new GameObject[3];
    public void Droping()
    {
        Instantiate(pick[Random.Range(0,3)], new Vector3(spawnpoint.position.x, spawnpoint.position.y, spawnpoint.position.z), new Quaternion(0,0,0,0));
    }
}
