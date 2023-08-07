using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    public GameObject Bullet;
    public string Type;
    public Transform firePoint;
    [Header("Not for FireArms")]
    public int Damage;
    public float AttackRange;
    public float AttackSpread;
    public float AttackSpeed;
    public void Attack()
    {
        switch (Type)
        {
            case "FireArm":
                GameObject bullet = Instantiate(Bullet, firePoint.position, firePoint.rotation);
                break;
        }
    }

    public void Begin(float Attackspeed)
    {
        InvokeRepeating("Attack", 0f, Attackspeed);
    }
}
