using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grens : MonoBehaviour
{
    public GameObject left;
    public GameObject right;
    public GameObject boven;
    public GameObject onder;

    public GameObject player;

    private void OnCollisionEnter(Collision collision)
    {
        if(player == left)
        {
            transform.position = right.transform.position;
        }
    }
}
