using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_GunZombie :Enemy
{
    public GameObject Bullets;
    public GameObject firePoint;
    public float rotationSpeed = 100f; // Rotation speed
      

    public void FpFlip()
    {

    
        // Calculate the direction vector from "a" to "c"
        Vector3 directionToC = (p.gameObject.transform.position - firePoint.transform.position).normalized;

        // Calculate the rotation angle in degrees to look at "c"
        float angleToC = Mathf.Atan2(directionToC.y, directionToC.x) * Mathf.Rad2Deg;

        // Apply the rotation to "a"
        firePoint.transform.rotation = Quaternion.Euler(0f, 0f, angleToC);

        // Rotate "a" around "b"
    
}

    private void FixedUpdate()
    {
        FpFlip();
    }
}
