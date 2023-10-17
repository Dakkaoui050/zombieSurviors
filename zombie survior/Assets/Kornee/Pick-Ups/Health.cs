using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Health : PickUps
{
    public void Awake()
    {
        string tempTag = this.tag;
        Tag = tempTag;
        me = GameObject.FindWithTag(tempTag);
        valuePlus = Random.Range(15,36);
        addToList();
    }
}
