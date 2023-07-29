using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_StunZombie : Enemy
{
    private bool isPlayerInRange = false;
    //wanneer de andere animation speel take damage


    public void Start()
    {
        //Walking
        Anim.Play("stun zombie");

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Anim.SetBool("isAttacking", true);
            Anim.Play("attack stun zombie");
            MoveSpeed *= 0.5f;
            isPlayerInRange = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Anim.SetBool("isAttacking", false);
            Anim.Play("stun zombie");
            MoveSpeed = 4; 
            isPlayerInRange = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Call the Coroutine to temporarily reduce the player's moveSpeed
            StartCoroutine(StunPlayerForSeconds(2f)); 
            StartCoroutine(ZombieDown(5f));
        }
    }

    // Coroutine to temporarily reduce the player's moveSpeed
    private IEnumerator StunPlayerForSeconds(float duration)
    {
        // Save the original player moveSpeed to restore it later
        float originalMoveSpeed = player.Instance.moveSpeed;

        // Set the player moveSpeed to the reduced value
        player.Instance.moveSpeed = 0.2f;

        // Wait for the specified duration
        yield return new WaitForSeconds(duration);

        // Restore the original player moveSpeed
        player.Instance.moveSpeed = originalMoveSpeed; 
       
    }
    private IEnumerator ZombieDown( float ZombieDuration)
    { 
        float originalZombieMoveSpeed = MoveSpeed;
        
        MoveSpeed = 0f;

        // Wait for the specified duration
        yield return new WaitForSeconds(ZombieDuration);

        // If the player is still in range, restore the enemy MoveSpeed
        if (isPlayerInRange)
        {
            MoveSpeed = originalZombieMoveSpeed;
        }
    }


}
