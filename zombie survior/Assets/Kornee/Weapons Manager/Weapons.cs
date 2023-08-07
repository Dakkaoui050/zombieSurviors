using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    public GameObject Bullet;
    public int Damage;
    public float AttackRange;
    public float AttackSpread;
    public string Type;
    public void Attack()
    {

    }

    public void Begin(float AttackSpeed)
    {
        InvokeRepeating("Attack", 0f, AttackSpeed);
    }
}
