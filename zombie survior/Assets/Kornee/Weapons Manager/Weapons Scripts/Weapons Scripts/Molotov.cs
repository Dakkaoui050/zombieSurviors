using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Molotov : Weapons
{
    public Animator anim;
    private void Awake()
    {

        Type = "Granade"; //dit is het type (FireArm, Melee of Granade)
        // interfall tussen de attacks
        firePoint = GameObject.FindWithTag("firepoint").GetComponent<Transform>();  // afvuur punt voor de fire arms
        Begin(AttackSpeed); // start de attack pattern

        anim.SetBool("MolotovPlay", true);
    }
}
