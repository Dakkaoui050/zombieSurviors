using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class playerData 
{
    //Zombie Behavior
    public GameObject Playerpefabs;

    //HeathBar 
    public int HP;
    public int MaxHP;
    public int Defence;
    public int AttackDamage;

    //Attacking mode
    public float moveSpeed;
    public float attackRange;
    public float attackCooldown;
}
