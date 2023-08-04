using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Threading;

public class PickUps
{
    [Header("Commen settings")]
    Sprite sprite;
    string type;
    [Header("Pickup Specific")]
    int valuePlus;
    bool nuke;
    string[] tag =
        {"Health", "defense", "Money","Nuke"};
    GameObject me;

    public void OnTriggerEnter2D()
    {
        Thread.Sleep(500);
        destroy();
    }
       
    public void destroy()
    {
        GameObject.Destroy(me);

    }
}
