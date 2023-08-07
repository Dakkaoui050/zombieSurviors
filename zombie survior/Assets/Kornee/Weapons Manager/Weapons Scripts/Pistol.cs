using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapons
{
    
    private void Awake()
    {
        Type = "FireArm";
        Damage = 0;
        AttackRange = 10f;
        AttackSpread = 0;
        firePoint = GameObject.FindWithTag("firepoint").GetComponent<Transform>();
        Begin(AttackSpeed);

    }
}
