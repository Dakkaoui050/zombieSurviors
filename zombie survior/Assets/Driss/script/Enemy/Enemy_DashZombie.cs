using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_DashZombie : Enemy
{
    
    //wanneer de andere animation speel take damage
    public void Start()
    {
        //Bom Zombie is Walking
        Anim.Play("dash Zombie boss");
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Anim.SetBool("isAttacking", true);
            Anim.Play("attack dash zombie");
            MoveSpeed *= 0.5f;
        }
  
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Anim.SetBool("isAttacking", false);
            Anim.Play("dash Zombie boss");
            MoveSpeed = 4;
        }
    }


}
