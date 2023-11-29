using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy_GunZombie : Enemy
{
    public GameObject Bullets;
    public GameObject firePoint;
    public float rotationSpeed = 50f; // Rotation speed


    public void FpFlip()
    {
        Vector3 directionToC = (p.gameObject.transform.position - firePoint.transform.position).normalized;


        float angleToC = Mathf.Atan2(directionToC.y, directionToC.x) * Mathf.Rad2Deg;


        firePoint.transform.rotation = Quaternion.Euler(0f, 0f, angleToC);



    }
    private void Start()
    {
        InvokeRepeating("shoot", 0f, 3f);
    }
    public void FixedUpdate()
    {

        FpFlip();

    }
    public void shoot()
    {

        StartCoroutine("submachineGun");
    }
    public IEnumerator submachineGun()
    {

        Debug.Log("teseterrtje");
        GameObject bullet = Instantiate(Bullets,  firePoint.transform.position, firePoint.transform.rotation);
        yield return new WaitForSeconds(0.1f);
        GameObject bullet1 = Instantiate(Bullets, firePoint.transform.position, firePoint.transform.rotation);
        yield return new WaitForSeconds(.1f);
        GameObject bullet2 = Instantiate(Bullets, firePoint.transform.position, firePoint.transform.rotation);
        yield return new WaitForSeconds(.1f);
        GameObject bullet3 = Instantiate(Bullets, firePoint.transform.position, firePoint.transform.rotation);
        yield return new WaitForSeconds(.1f);
        GameObject bullet4 = Instantiate(Bullets, firePoint.transform.position, firePoint.transform.rotation);
        yield return null;

    }
}
