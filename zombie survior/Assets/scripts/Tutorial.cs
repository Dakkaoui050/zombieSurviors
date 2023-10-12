using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject totur;
    public GameObject Game;


    public void FixedUpdate()
    {
        if(Input.anyKey)
        {
            totur.SetActive(false);
            Game.SetActive(true);
        }
    }
}
