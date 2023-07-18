using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehavior : Behaviour
{
    public ScriptableZombies scriptable;  // Reference to a ScriptableZombies object
    public GameObject[] zombies;  // Array of zombie GameObjects
    public GameObject player;  // Reference to the player GameObject
    public GameObject circleCenter;  // Reference to the circle center GameObject
    public Animator enemyAnimator;  // Reference to the enemy animator component
    public float speed;  // Speed value for the enemy movement

    void Start()
    {
        speed = scriptable.speed;  // Assign the speed value from the ScriptableZombies object
        enemyAnimator.runtimeAnimatorController = scriptable.animatorController;  // Assign the animator controller from the ScriptableZombies object
    }

    void Update()
    {
        // Calculate the distance between the enemy's position and the circle center's position
        float distance = Vector2.Distance(transform.position, circleCenter.transform.position);

        // If the enemy is outside the circle
        if (distance > circleCenter.GetComponent<CircleCollider2D>().radius)
        {
            // Calculate the direction towards the player
            Vector2 direction = (player.transform.position - transform.position).normalized;

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
}
