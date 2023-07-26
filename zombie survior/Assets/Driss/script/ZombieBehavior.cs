using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ZombieBehavior : MonoBehaviour
{

    public float moveSpeed = 2f;
    public float detectionRange = 5f;
    public float attackRange = 1f;
    public float attackCooldown = 2f;
    public int attackDamage = 10;

    private Transform player;
    private Animator animator;
    private bool isAttacking = false;
    private float attackTimer = 0f;

    // Reference to the circle center GameObject
    public Animator zombieAnimator;  // Reference to the enemy animator component
   
    // Healthbar 
    public float Hitpoints;
    public float MaxHitPoints = 20;
    public healthbarBehavior HP;

    private Movement move;
    private Rigidbody2D rb;
    public CircleCollider2D circleCollider;
    public Transform playerCircleCollider; // Reference to the player's circle collider

    void Start()
    {
        
        circleCollider = GetComponent<CircleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        move = GetComponent<Movement>();
        animator = GetComponent<Animator>();

        Hitpoints = MaxHitPoints;
        HP.Sethealth(Hitpoints, MaxHitPoints);

        // Check if a GameObject tagged as "Player" exists in the scene
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;

            // Find the CircleCollider2D component on the player (assuming it has one)
            CircleCollider2D playerCircle = playerObject.GetComponent<CircleCollider2D>();
            if (playerCircle != null)
            {
                playerCircleCollider = playerCircle.transform;
            }
            else
            {
                Debug.LogError("No CircleCollider2D found on the GameObject tagged as 'Player'!");
            }
        }
        else
        {
            Debug.LogError("No GameObject tagged as 'Player' found in the scene!");
        }
    }

    void Update()
    {
        if (player != null && !isAttacking)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);

            if (distanceToPlayer <= detectionRange)
            {
                // Face the player
                Vector3 directionToPlayer = (player.position - transform.position).normalized;
                transform.right = directionToPlayer;

                // Move towards the player
                if (distanceToPlayer > attackRange)
                {
                    transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
                    animator.SetBool("isMoving", true);
                }
                else
                {
                    // Player within attack range
                    animator.SetBool("isMoving", false);
                    Attack();
                }
            }
            else
            {
                animator.SetBool("isMoving", false);
            }
        }

        // Cooldown timer for attacking
        if (isAttacking)
        {
            attackTimer += Time.deltaTime;
            if (attackTimer >= attackCooldown)
            {
                isAttacking = false;
                attackTimer = 0f;
            }
        }

        // Calculate the distance between the enemy's position and the player's circle center's position
        float distance = Vector2.Distance(transform.position, playerCircleCollider.position);

        // If the enemy is outside the player's circle
        if (distance > playerCircleCollider.GetComponent<CircleCollider2D>().radius)
        {
           
            // moving towards the player's circle center
            animator.SetBool("isMoving", true);
            animator.SetBool("isAttacking", false);

        }
        else // If the enemy is inside the player's circle
        {
      
            //resetting the "EnterCircle" animation trigger in the enemy animator
            animator.SetBool("isMoving", false);
            animator.SetBool("isAttacking", true);
        }
    }

    void Attack()
    {
        // Perform attack logic here
        // For example, decrease player health, play attack animation, etc.
        animator.SetTrigger("Attack");
        player.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
        isAttacking = true;
    }

    public void TakeHit(float Damage)
    {
        HP.Sethealth(Hitpoints, MaxHitPoints);
        Hitpoints -= Damage;

        if (Hitpoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}

