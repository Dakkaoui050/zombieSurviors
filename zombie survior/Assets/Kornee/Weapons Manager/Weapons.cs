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
    public float AttackTime;
    public float AttackTimerValue;
    [Header("Not for FireArms")]
    public int Damage;
    public float AttackRange;
    public float AttackSpread;
    
    public Sprite image;
    public UIScript UIScript;
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
                GameObject bomb = Instantiate(Bullet, p.firePointG.transform.position, p.firePointG.transform.rotation);

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

            case "machineGun":

                StartCoroutine("machineGun");



                break;
        }
    }

    private void Update()
    {
        if(AttackTimerValue <= 0)
        {
            AttackTimerValue = AttackSpeed;
        }
        else
        {
            AttackTimerValue -= Time.deltaTime;      
        }
    }

    public IEnumerator submachineGun()
    {   

  
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

    public IEnumerator machineGun()
    {


        GameObject bullet4 = Instantiate(Bullet, p.firePoint1.transform.position, p.firePoint1.transform.rotation);
        audioSource.Play();
        yield return new WaitForSeconds(0.1f);
        GameObject bullet5 = Instantiate(Bullet, p.firePoint1.transform.position, p.firePoint1.transform.rotation);
        yield return new WaitForSeconds(0.1f);
        GameObject bullet6 = Instantiate(Bullet, p.firePoint1.transform.position, p.firePoint1.transform.rotation);
        yield return new WaitForSeconds(0.1f);
        GameObject bullet7 = Instantiate(Bullet, p.firePoint1.transform.position, p.firePoint1.transform.rotation);
        yield return new WaitForSeconds(0.1f);
        audioSource.Play();
        GameObject bullet8 = Instantiate(Bullet, p.firePoint1.transform.position, p.firePoint1.transform.rotation);
        yield return new WaitForSeconds(0.1f);
        GameObject bullet9 = Instantiate(Bullet, p.firePoint1.transform.position, p.firePoint1.transform.rotation);
        yield return new WaitForSeconds(0.1f);
        GameObject bullet10 = Instantiate(Bullet, p.firePoint1.transform.position, p.firePoint1.transform.rotation);
        yield return new WaitForSeconds(0.1f);
        GameObject bullet11 = Instantiate(Bullet, p.firePoint1.transform.position, p.firePoint1.transform.rotation);
        yield return new WaitForSeconds(0.1f);
        GameObject bullet12 = Instantiate(Bullet, p.firePoint1.transform.position, p.firePoint1.transform.rotation);
        yield return new WaitForSeconds(0.1f);
        GameObject bullet13 = Instantiate(Bullet, p.firePoint1.transform.position, p.firePoint1.transform.rotation);
    }

    private void Awake()
    {
        
    }

    public void Begin(float Attackspeed)
    {
        p = GetComponentInParent<player>();
        InvokeRepeating("Attack", 0f, Attackspeed);
        UIScript = p.GetComponentInChildren<UIScript>();
        WeaponsManager weapons = p.GetComponentInChildren<WeaponsManager>();
        
        if (GetComponentInParent<player>().playerIndex == 0)
        {
            for (int i = 0; i <= weapons.weaponsP1.Length;)
            {
                if (weapons.weaponsP1[i] == null)
                {
                    weapons.weaponsP1[i] = this;
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
        else if (GetComponentInParent<player>().playerIndex == 1)
        {
            for (int i = 0; i <= weapons.weaponsP2.Length;)
            {
                if (weapons.weaponsP2[i] == null)
                {
                    weapons.weaponsP2[i] = this;
                    break;
                }
                else if (i != 3)
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
}
