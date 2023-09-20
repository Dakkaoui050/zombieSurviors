using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapons
{
    private void Awake()
    {
        Type = "Melee"; //dit is het type (FireArm, Melee of Granade)
        Damage = 15;       // alleen voor de melee type
        AttackSpread = 0; // alleen voor shotgun en granades
        AttackSpeed = 5;  // interfall tussen de attacks
        firePoint = GameObject.FindWithTag("firepoint").GetComponent<Transform>();  // afvuur punt voor de fire arms
        Begin(AttackSpeed); // start de attack pattern


    }
}
