using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehavior : MonoBehaviour
{   Rigidbody2D body;
    ScriptablePlayer SP;
    ZombieBehavior ZB;
    public Slider healthSlider;
    
    //HeathBar 
    public int HP;
    public int MaxHP;
  
    //Attacking mode
    public float attackRange;
    public float attackCooldown;
    public int AttackDamage;
    public int Defence;

    //movement
     float horizontal;
    float vertical;
    public bool lookRight = true;
    public float moveSpeed;

    void Start()
    {
        //ScriptablePlayer(SP) daar in zit PlayerData(PD)
        //HealthBar
        HP = SP.PD.HP;
        MaxHP = SP.PD.MaxHP;
   
        Defence = SP.PD.Defence;

        //Attack mode
        AttackDamage = SP.PD.AttackDamage;
        attackRange = SP.PD.attackRange;
        //player Behavior
        moveSpeed = SP.PD.moveSpeed;

        HP = MaxHP;
        UpdateHealthBar();
        
        body = this.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (horizontal > 0 && !lookRight)
        {
            flip();
        }
        if (horizontal < 0 && lookRight)
        {
            flip();
        }

    }
    private void FixedUpdate()
    {
        body.velocity = new Vector2(horizontal * moveSpeed, vertical * moveSpeed);
    }
    public void PlayerDamage()
    {
        ZB.AttackDamage -= HP;

        //Defence is een range van 0 tot 1
        Defence = HP - ZB.AttackDamage * Defence; 

        UpdateHealthBar();

        if (HP <= 0)
        {
            HandleDeath();
        }
    }

    public void AttackZombie()
    {
        AttackDamage -= ZB.HP;

        //Defence is een range van 0 tot 1
        ZB.Defence = ZB.HP - AttackDamage * ZB.Defence;


    }
    public void range()
    {
        float distanceToZombie = Vector2.Distance(transform.position, ZB.prefab.transform.position);
        if (distanceToZombie != attackRange)
        {
            // Face the player
            Vector3 directionToPlayer = (ZB.prefab.transform.position - transform.position).normalized;
            transform.right = directionToPlayer;   
        }
        if (distanceToZombie == attackRange)
        {
            //als Zombie in range is
            AttackZombie();       
        }
        
    }
    public void Attack()
    {

    }
    private void UpdateHealthBar()
    {
        healthSlider.value = HP;
    }
    private void HandleDeath()
    {
        //destroy the GameObject or trigger some other behavior.
        Destroy(gameObject);
    }
    void flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        lookRight = !lookRight;
    }

}

    

