using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : Weapons
{
    private void Awake()
    {
        Type = "Granade"; //dit is het type (FireArm, Melee of Granade)
        Damage = 0;       // alleen voor de melee type
        AttackSpread = 10; // alleen voor shotgun en granades
        AttackSpeed = 3;  // interfall tussen de attacks
        firePoint = GameObject.FindWithTag("firepoint").GetComponent<Transform>();  // afvuur punt voor de fire arms
        Begin(AttackSpeed); // start de attack pattern


    }
}
