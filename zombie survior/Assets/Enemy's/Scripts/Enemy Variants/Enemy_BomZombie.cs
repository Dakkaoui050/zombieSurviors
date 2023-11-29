using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_BomZombie : Enemy
{
    //wanneer de andere animation speel take damage
    public void Start()
    {
        //Bom Zombie is Walking
        Anim.Play("bom zombie");
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        { 

            StartCoroutine("DestoryZombie");

        }
        
    }
    public IEnumerator DestoryZombie()
    {  
        Anim.Play("zombie onploft");
        yield return new WaitForSeconds(0.5f);
        Damage = 70;
        Destroy(gameObject);
       
    }

}
