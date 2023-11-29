using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Health : PickUps
{
    public void Awake()
    {
        Tag = gameObject.tag;
        me = gameObject;
        valuePlus = Random.Range(15,36);
        player_script = GameObject.Find("Player").GetComponent<player>();
        player_script.PickUps.Add(this.gameObject);
    }
}
