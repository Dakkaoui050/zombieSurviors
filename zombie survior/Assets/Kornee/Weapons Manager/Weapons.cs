using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    public GameObject Bullet;
    public string Type;
    public Transform firePoint;
    public player p;
    public float AttackSpeed;
    [Header("Not for FireArms")]
    public int Damage;
    public float AttackRange;
    public float AttackSpread;
    
    public Sprite image;
    public UIScript script;
    public AudioSource audioSource;
    
   
    public void Attack()
    {
        switch (Type)
        {
            case "FireArm":
                audioSource.Play();
                GameObject bullet = Instantiate(Bullet, p.firePoint1.transform.position, p.firePoint1.transform.rotation);
                break;

            case "Melee":

                break;

            case "Granade":
                audioSource.Play();
                GameObject bomb = Instantiate(Bullet, p.firePoint1.transform.position, p.firePoint1.transform.rotation);

                break;

            case "Shotgun":
                audioSource.Play();
                GameObject bullet1 = Instantiate(Bullet, p.firePoint1.transform.position, p.firePoint1.transform.rotation);
                GameObject bullet2 = Instantiate(Bullet, p.firePoint2.transform.position, p.firePoint2.transform.rotation);
                GameObject bullet3 = Instantiate(Bullet, p.firePoint3.transform.position, p.firePoint3.transform.rotation);

                break;

            case "submachineGun":
               
                StartCoroutine("submachineGun");
                
                
                
                break;
        }
    }
    
    

    public IEnumerator submachineGun()
    {   

        Debug.Log("teseterrtje");
  
                    audioSource.Play();
                    GameObject bullet4 = Instantiate(Bullet, p.firePoint1.transform.position, p.firePoint1.transform.rotation);
                    yield return new WaitForSeconds(0.2f);
                    GameObject bullet5 = Instantiate(Bullet, p.firePoint1.transform.position, p.firePoint1.transform.rotation);
                    yield return new WaitForSeconds(0.2f);
                    GameObject bullet6 = Instantiate(Bullet, p.firePoint1.transform.position, p.firePoint1.transform.rotation);
                    yield return new WaitForSeconds(0.2f);
                    GameObject bullet7 = Instantiate(Bullet, p.firePoint1.transform.position, p.firePoint1.transform.rotation);
                    yield return new WaitForSeconds(0.2f);
                    GameObject bullet8 = Instantiate(Bullet, p.firePoint1.transform.position, p.firePoint1.transform.rotation);
                   
    





    }

    private void Awake()
    {
        
    }

    public void Begin(float Attackspeed)
    {
        p = GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
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
