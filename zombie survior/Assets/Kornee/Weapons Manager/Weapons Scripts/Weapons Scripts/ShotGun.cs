using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : Weapons
{
    private void Awake()
    {
        Type = "Shotgun"; //dit is het type (FireArm, Melee of Granade)
        Damage = 0;       // alleen voor de melee type
        AttackSpread = 5; // alleen voor shotgun en granades
        firePoint = GameObject.FindWithTag("firepoint").GetComponent<Transform>();  // afvuur punt voor de fire arms
        Begin(AttackSpeed); // start de attack pattern
    }
}
