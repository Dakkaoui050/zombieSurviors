using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapons
{
    private void Awake()
    {
        Type = "FireArm";
        Damage = 12;
    }
}
