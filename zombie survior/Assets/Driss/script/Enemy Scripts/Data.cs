using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Data 
{
    //Zombie Behavior
    public GameObject pefabsZombie;

    //HeathBar 
    public int HP;
    public int MaxHP;
    public int Defence;
    public int AttackDamage;

    //Attacking mode
    public float moveSpeed;
    public float detectionRange;
    public float attackRange;
    public float attackCooldown;
}
