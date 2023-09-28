using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossBow : Weapons
{
    private void Awake()
    {
        Type = "FireArm"; //dit is het type (FireArm, Melee of Granade)
        Damage = 0;       // alleen voor de melee type
        AttackSpread = 0; // alleen voor shotgun en granades
       // interfall tussen de attacks
        firePoint = GameObject.FindWithTag("firepoint").GetComponent<Transform>();  // afvuur punt voor de fire arms
        Begin(AttackSpeed); // start de attack pattern


    }
}
