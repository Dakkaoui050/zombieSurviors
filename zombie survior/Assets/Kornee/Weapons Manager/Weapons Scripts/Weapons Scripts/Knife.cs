using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : Weapons
{
    Animator anim;
    private void Awake()
    {
        Type = "Melee"; //dit is het type (FireArm, Melee of Granade)
        Damage = 20;       // alleen voor de melee type
        AttackSpread = 5; // alleen voor shotgun en granades
        AttackSpeed = 7;  // interfall tussen de attacks
        firePoint = GameObject.FindWithTag("firepoint").GetComponent<Transform>();  // afvuur punt voor de fire arms
        Begin(AttackSpeed); // start de attack pattern
        anim.SetBool("mesPlay", true);

    }
}
