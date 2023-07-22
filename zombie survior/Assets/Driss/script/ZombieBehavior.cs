using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehavior : MonoBehaviour
{
    Movement move;

    public Transform target;
    Rigidbody2D rb;
    

    public GameObject zombies;  // Array of zombie GameObjects
    
    public GameObject circleCenter;  // Reference to the circle center GameObject
    public Animator enemyAnimator;  // Reference to the enemy animator component
    public float speed;  // Speed value for the enemy movement

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        move = GetComponent<Movement>();
    }

    void Update()
    {
        if (target)
        {
            RotateToTarget();
        }

        // Calculate the distance between the enemy's position and the circle center's position
        float distance = Vector2.Distance(transform.position, circleCenter.transform.position);

        // If the enemy is outside the circle
        if (distance > circleCenter.GetComponent<CircleCollider2D>().radius)
        {
            // Calculate the direction towards the player
            Vector2 direction = (target.transform.position - transform.position).normalized;

            // Calculate the new position based on the direction, speed, and delta time
            Vector2 newPosition = (Vector2)transform.position + direction * speed * Time.deltaTime;

            // Update the enemy's position
            transform.position = newPosition;

            // Trigger the "EnterCircle" animation state in the enemy animator
            enemyAnimator.SetTrigger("EnterCircle");
        }
        else  // If the enemy is inside the circle
        {
            // Reset the "EnterCircle" animation trigger in the enemy animator
            enemyAnimator.ResetTrigger("EnterCircle");
        }
    }
    

    public void RotateToTarget()
    {
       
        if (target)
        {
            if (move.horizontal > 0)
            {
                //if the player is look the left then the zombies on the leftside look to the right
                gameObject.transform.localScale = new Vector3(1, 1, 1);
            }
            else if (move.horizontal < 0)
            {
                //if the player is look the right then the zombies on the rightside look to the left
                gameObject.transform.localScale = new Vector3(-1, 1, 1);
            }
        }
       
    }
}
