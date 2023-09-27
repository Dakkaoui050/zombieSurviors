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
    public Sprite image;
    public UIScript script;
    public void Attack()
    {
        switch (Type)
        {
            case "FireArm":
                GameObject bullet = Instantiate(Bullet, firePoint.position, firePoint.rotation);
                break;

            case "Melee":

                break;

            case "Granade":
                break;
        }
    }

    public void Begin(float Attackspeed)
    {
        InvokeRepeating("Attack", 0f, Attackspeed);
        var temp = GameObject.FindGameObjectWithTag("Player");
        script = temp.GetComponentInChildren<UIScript>();
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
