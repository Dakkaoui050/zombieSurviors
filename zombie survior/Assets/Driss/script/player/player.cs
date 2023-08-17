using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    [SerializeField]private SpriteRenderer spriteRenderer;

    public static player Instance;

    public GameObject FirePoint;
    //movement
    private Rigidbody2D RB;
    private float MoveH, MoveV;
    public float moveSpeed;
    public bool lookRight = false;

    //healthBar
    [SerializeField] private Slider slider;
    public float HP;
    public float MaxHP;
    public float defence;
    public float Damage;
    public bool Nuke;
    public int Nuke_Count;
    public int Money;
   
    //dash verables
    private bool isDashing = false;
    public float dashDuration = 0.2f;
    public float dashSpeed = 10f;
    private float dashTimer;
    public bool DashUnlock = false;
    // Start is called before the first frame update
    void Awake()
    { // Check if an instance already exists
        if (Instance == null)
        {
            // If not, set this as the instance
            Instance = this;
        }
        else
        {
            // If an instance already exists, destroy this duplicate
            Destroy(gameObject);
        }
        RB = GetComponent<Rigidbody2D>();
        HP = MaxHP;
        FirePoint = GameObject.FindWithTag("firepoint");

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {

    }

    void FixedUpdate()
    {
        if (!isDashing)
        {
            MoveH = Input.GetAxis("Horizontal") * moveSpeed;
            MoveV = Input.GetAxis("Vertical") * moveSpeed;
            RB.velocity = new Vector2(MoveH, MoveV);

            if (Input.GetAxis("Horizontal") <= -0.1f)
            {
                spriteRenderer.flipX = true;
                FirePoint.transform.localPosition = new Vector2(-1f,0f);
                FirePoint.transform.localRotation = Quaternion.Euler(0f, 0f, 180f);
            }
            if (Input.GetAxis("Horizontal") >= .1f)
            {
                spriteRenderer.flipX = false;
                FirePoint.transform.localPosition = new Vector2(1f,0f);
                FirePoint.transform.localRotation = Quaternion.Euler(0f, 0f, 0);
            }
            if (Input.GetAxis("Vertical") <= -0.1f)
            {
                FirePoint.transform.localPosition = new Vector2(0f,-1f);
                FirePoint.transform.localRotation = Quaternion.Euler(0f, 0f, -90f);
            }
            if (Input.GetAxis("Vertical") >= .1f)
            {
                FirePoint.transform.localPosition = new Vector2(0f,1f);
                FirePoint.transform.localRotation = Quaternion.Euler(0f, 0f, 90f);
            }
        }
        if (DashUnlock == true)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                // Call the Dash() function when the Fire1 button is pressed
                Dash();
            }

        }


        if (isDashing)
        {
            // Dash movement
            RB.velocity = new Vector2(MoveH * dashSpeed, MoveV * dashSpeed);

            dashTimer -= Time.deltaTime;
            if (dashTimer <= 0f)
            {
                // Reset velocity and end the dash after the specified duration
                RB.velocity = new Vector2(MoveH, MoveV);
                isDashing = false;
            }
        }
    }

   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Assuming Enemy script is attached to the enemy GameObject
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            TakeDamage(enemy.Damage);
        }
    }

    public void TakeDamage(float damage)
    {
        // Apply damage reduction based on defence (if needed)
        float damageTaken = damage - defence;
        HP -= damageTaken;
        HP = Mathf.Clamp(HP, 0, MaxHP);

        slider.value = HP;
        slider.maxValue = MaxHP;

        if (HP <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Handle player's death here
        Destroy(gameObject);
    }
    void Dash()
    {
        // Perform dash only if the player is not currently dashing
        if (!isDashing)
        {
            isDashing = true;
            dashTimer = dashDuration;
        }
    }
}

