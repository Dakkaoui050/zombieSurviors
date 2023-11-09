using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Nuke : PickUps
{
    private void Awake()
    {

        me = gameObject;
        Tag = gameObject.tag;
        player_script = GameObject.Find("Player").GetComponent<player>();
        player_script.PickUps.Add(this.gameObject);
        nuke = GameObject.FindGameObjectWithTag("Gamemaster").GetComponent<nukedrop>();

    }


}
