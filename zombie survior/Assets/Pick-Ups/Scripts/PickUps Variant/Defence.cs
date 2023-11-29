using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Defense : PickUps
{
    public void Awake()
    {
        Tag = gameObject.tag;
        me = gameObject;
        valuePlus = Random.Range(1,3);
        player_script = GameObject.Find("Player").GetComponent<player>();
        player_script.PickUps.Add(this.gameObject);
    }
}
