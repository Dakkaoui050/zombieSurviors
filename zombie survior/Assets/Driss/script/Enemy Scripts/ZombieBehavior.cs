using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ZombieBehavior : MonoBehaviour
{
    ScriptableZombies SZ;
    PlayerBehavior PB;
    //Attack mode
    private float moveSpeed;
    private float detectionRange;
    private float attackRange;
    private float attackCooldown;

    public Slider ZombiehealthSlider;

    private Transform player;
    private Animator animator;
    private bool isAttacking = false;
    private float attackTimer = 0f;

    public GameObject prefab;
  
    //private Rigidbody2D rb;
    public CircleCollider2D circleCollider;
    public Transform playerCircleCollider; // Reference to the player's circle collider
    
    //HealthBar
    public int HP;
    public int MaxHP;
   
    public int Defence;
    public int AttackDamage;

    void Start()
    {
        PB = GetComponent<PlayerBehavior>();
        //animator = GetComponent<Animator>();

        //data for Zombie
        prefab = SZ.data.pefabsZombie;
        moveSpeed = SZ.data.moveSpeed;
        detectionRange = SZ.data.detectionRange;
        attackRange = SZ.data.attackRange;
        attackCooldown = SZ.data.attackCooldown;

        //data for Health Zombie and player
        HP = SZ.data.HP;
        MaxHP = SZ.data.MaxHP;
        
        Defence = SZ.data.Defence;

        AttackDamage = SZ.data.AttackDamage;


        // Check if a GameObject tagged as "Player" exists in the scene
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;  
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
                    PlayerDamage();
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

        //// If the enemy is outside the player's circle
        //if (distance > playerCircleCollider.GetComponent<CircleCollider2D>().radius)
        //{
           
        //    moving towards the player's circle center
        //    animator.SetBool("isMoving", false);
        //    animator.SetBool("isAttacking", false);

        //}
        //else // If the enemy is inside the player's circle
        //{
      
        //    //resetting the "EnterCircle" animation trigger in the enemy animator
        //    animator.SetBool("isMoving", true);
        //    animator.SetBool("isAttacking", true);
        //}
    }

    public void PlayerDamage()
    {
        AttackDamage -= PB.HP;

        //Defence is een range van 0 tot 1
        PB.Defence = HP - PB.AttackDamage * PB.Defence;


    }

    public void AttackZombie()
    {
        PB.AttackDamage -= HP;

        //Defence is een range van 0 tot 1
        PB.Defence = PB.HP - AttackDamage * PB.Defence;

        UpdateHealthBar();

        if (HP <= 0)
        {
            HandleDeath();
        }
    }
    private void UpdateHealthBar()
    {
        ZombiehealthSlider.value = HP;
    }
    private void HandleDeath()
    {
        //destroy the GameObject or trigger some other behavior.
        Destroy(gameObject);
    }

}

