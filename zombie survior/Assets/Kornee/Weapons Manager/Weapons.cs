using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    public GameObject Bullet;
    public string Type;
    public Transform firePoint;
    public player p;
    [Header("Not for FireArms")]
    public int Damage;
    public float AttackRange;
    public float AttackSpread;
    public float AttackSpeed;

    //anime
    Animator anim;
    public GameObject melee;
    public GameObject Bommtje;

    public void Attack()
    {
        switch (Type)
        {
            case "FireArm":
                GameObject bullet = Instantiate(Bullet, firePoint.position, firePoint.rotation);
                break;

            case "Melee":
                GameObject slaan = Instantiate(melee);
               
                break;

            case "Granade":
                GameObject bom = Instantiate(Bommtje, firePoint.position, firePoint.rotation);
            
                break;

            case "Shotgun":
                GameObject bullet1 = Instantiate(Bullet, p.firePoint1.transform.position, p.firePoint1.transform.rotation);
                GameObject bullet2 = Instantiate(Bullet, p.firePoint2.transform.position, p.firePoint2.transform.rotation);
                GameObject bullet3 = Instantiate(Bullet, p.firePoint3.transform.position, p.firePoint3.transform.rotation);

                break;
        }
    }
    private void Awake()
    {
        
    }

    public void Begin(float Attackspeed)
    {
        p = GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
        InvokeRepeating("Attack", 0f, Attackspeed);
        WeaponsManager weapons = GameObject.FindWithTag("Weapons Manager").GetComponent<WeaponsManager>();
        for (int i = 0; i <= weapons.weapons.Length;)
        {
            if (weapons.weapons[i] == null)
            {
                weapons.weapons[i] = this;
                break;
            }
            else if (i !=3)
            {
                i++;

            }
            else
            {
                break;
            }
        }
    }
}
