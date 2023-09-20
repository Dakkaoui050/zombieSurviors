using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nuke : PickUps
{
    private void Awake()
    {
        string tempTag = this.tag;
        Tag = tempTag;
        me = GameObject.FindWithTag(tempTag);

    }
}
