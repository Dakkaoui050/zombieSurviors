using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Defense : PickUps
{
    public void Awake()
    {
        string tempTag = this.tag;
        me = GameObject.FindWithTag(tempTag);
        valuePlus = Random.Range(10,26);
    }
}
