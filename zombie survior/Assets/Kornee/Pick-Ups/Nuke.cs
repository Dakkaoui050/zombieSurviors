using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Nuke : PickUps
{
    private void Awake()
    {
        string tempTag = this.tag;
        Tag = tempTag;
        me = GameObject.FindWithTag(tempTag);
        addToList();
    }

   
}
