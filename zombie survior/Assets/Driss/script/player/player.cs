using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class player : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    //players
    public static List<player> Players = new List<player>();
    public int playerIndex;
    public bool player2;

    public GameObject firePoint1;
    public GameObject firePoint2;
    public GameObject firePoint3;
    public GameObject firePointG;
    public AudioSource source;
    public AudioSource hurtsound;

    //movement
    public Rigidbody2D RB;
    public float MoveH, MoveV;
    public float moveSpeed;
    public bool lookRight = false;
    public int killcount = 0;

    //healthBar
    [SerializeField] private Slider slider;
    public float HP;
    public float MaxHP;
    public float defence = 1;
    public float Damage;

    // pick-ups
    public bool Nuke;
    public int Nuke_Count;
    public int Money;
    public nukedrop nuke;

    //dash verables
    [SerializeField] private bool isDashing = false;
    public float dashDuration = 0.2f;
    public float dashSpeed = 10f;
    [SerializeField] private float dashTimer = 10f;
    public bool DashUnlock = false;
    public int poss;
    public List<GameObject> Zombies = new List<GameObject>();
    public List<GameObject> PickUps = new List<GameObject>();
    // Start is called before the first frame update


    public GameObject Highscore;

    public bool dead;
    knockBack kb;




    public void Awake()
    { // Check if an instance already exists
        kb = gameObject.GetComponent<knockBack>();
        
        
        

        nuke = GameObject.FindWithTag("Gamemaster").GetComponent<nukedrop>();
        RB = GetComponent<Rigidbody2D>();
        HP = MaxHP;
        spriteRenderer = GetComponent<SpriteRenderer>();
        slider.maxValue = MaxHP;
        slider.value = HP;
    }



    public void FixedUpdate()
    {
        // Handle input and movement for each player

        slider.value = HP;

        HandleInput();


        if (defence > 6)
        {
            defence = 6;
        }

        foreach (var t in Zombies)
        {
            if (t == null)

            {
                Zombies.Remove(t);
            }
        }
        foreach (var t in PickUps)
        {
            if (t == null)

            {
                PickUps.Remove(t);
            }
        }
        if (Nuke_Count > 0)
        {
            Nuke = true;
        }
        else
        {
            Nuke = false;
        }
        {

        }
        if (!isDashing)
        {
            dashTimer -= Time.deltaTime;
            if (playerIndex == 0)
            {
                if (Input.GetAxis("Horizontal") <= -0.1f)
                {
                    spriteRenderer.flipX = true;
                    poss = 2;
                    firePoint1.transform.localPosition = new Vector2(-.5f, 0f);
                    firePoint1.transform.localRotation = Quaternion.Euler(0f, 0f, 180f);
                    firePoint2.transform.localPosition = new Vector2(-.5f, 0f);
                    firePoint2.transform.localRotation = Quaternion.Euler(0f, 0f, 165f);
                    firePoint3.transform.localPosition = new Vector2(-.5f, 0f);
                    firePoint3.transform.localRotation = Quaternion.Euler(0f, 0f, 195f);
                    firePointG.transform.localPosition = new Vector2(-.5f, 0f);
                }
                if (Input.GetAxis("Horizontal") >= .1f)
                {
                    poss = 1;
                    spriteRenderer.flipX = false;
                    firePoint1.transform.localPosition = new Vector2(.5f, 0f);
                    firePoint1.transform.localRotation = Quaternion.Euler(0f, 0f, 0);
                    firePoint2.transform.localPosition = new Vector2(.5f, 0f);
                    firePoint2.transform.localRotation = Quaternion.Euler(0f, 0f, -15f);
                    firePoint3.transform.localPosition = new Vector2(.5f, 0f);
                    firePoint3.transform.localRotation = Quaternion.Euler(0f, 0f, 15f);
                    firePointG.transform.localPosition = new Vector2(.5f, 0f);

                }
                if (Input.GetAxis("Vertical") <= -0.1f)
                {
                    poss = 3;
                    firePoint1.transform.localPosition = new Vector2(0f, -.5f);
                    firePoint1.transform.localRotation = Quaternion.Euler(0f, 0f, -90f);
                    firePoint2.transform.localPosition = new Vector2(0f, -.5f);
                    firePoint2.transform.localRotation = Quaternion.Euler(0f, 0f, -105f);
                    firePoint3.transform.localPosition = new Vector2(0f, -.5f);
                    firePoint3.transform.localRotation = Quaternion.Euler(0f, 0f, -75f);
                    firePointG.transform.localPosition = new Vector2(0f, -.5f);

                }
                if (Input.GetAxis("Vertical") >= .1f)
                {
                    poss = 4;

                    firePoint1.transform.localPosition = new Vector2(0f, .5f);
                    firePoint1.transform.localRotation = Quaternion.Euler(0f, 0f, 90f);
                    firePoint2.transform.localPosition = new Vector2(0f, .5f);
                    firePoint2.transform.localRotation = Quaternion.Euler(0f, 0f, 105f);
                    firePoint3.transform.localPosition = new Vector2(0f, .5f);
                    firePoint3.transform.localRotation = Quaternion.Euler(0f, 0f, 75f);
                    firePointG.transform.localPosition = new Vector2(0f, .5f);

                }
            }
            else if (playerIndex == 1)
            {
                if (Input.GetAxis("Player 2 h") <= -0.1f)
                {
                    spriteRenderer.flipX = true;
                    firePoint1.transform.localPosition = new Vector2(-.5f, 0f);
                    firePoint1.transform.localRotation = Quaternion.Euler(0f, 0f, 180f);
                    firePoint2.transform.localPosition = new Vector2(-.5f, 0f);
                    firePoint2.transform.localRotation = Quaternion.Euler(0f, 0f, 165f);
                    firePoint3.transform.localPosition = new Vector2(-.5f, 0f);
                    firePoint3.transform.localRotation = Quaternion.Euler(0f, 0f, 195f);
                    firePointG.transform.localPosition = new Vector2(-.5f, 0f);
                }
                if (Input.GetAxis("Player 2 h") >= .1f)
                {
                    spriteRenderer.flipX = false;
                    firePoint1.transform.localPosition = new Vector2(.5f, 0f);
                    firePoint1.transform.localRotation = Quaternion.Euler(0f, 0f, 0);
                    firePoint2.transform.localPosition = new Vector2(.5f, 0f);
                    firePoint2.transform.localRotation = Quaternion.Euler(0f, 0f, -15f);
                    firePoint3.transform.localPosition = new Vector2(.5f, 0f);
                    firePoint3.transform.localRotation = Quaternion.Euler(0f, 0f, 15f);
                    firePointG.transform.localPosition = new Vector2(.5f, 0f);
                }
                if (Input.GetAxis("Player 2 v") <= -0.1f)
                {
                    firePoint1.transform.localPosition = new Vector2(0f, -.5f);
                    firePoint1.transform.localRotation = Quaternion.Euler(0f, 0f, -90f);
                    firePoint2.transform.localPosition = new Vector2(0f, -.5f);
                    firePoint2.transform.localRotation = Quaternion.Euler(0f, 0f, -105f);
                    firePoint3.transform.localPosition = new Vector2(0f, -.5f);
                    firePoint3.transform.localRotation = Quaternion.Euler(0f, 0f, -75f);
                    firePointG.transform.localPosition = new Vector2(0f, -.5f);
                }
                if (Input.GetAxis("Player 2 v") >= .1f)
                {
                    firePoint1.transform.localPosition = new Vector2(0f, .5f);
                    firePoint1.transform.localRotation = Quaternion.Euler(0f, 0f, 90f);
                    firePoint2.transform.localPosition = new Vector2(0f, .5f);
                    firePoint2.transform.localRotation = Quaternion.Euler(0f, 0f, 105f);
                    firePoint3.transform.localPosition = new Vector2(0f, .5f);
                    firePoint3.transform.localRotation = Quaternion.Euler(0f, 0f, 75f);
                    firePointG.transform.localPosition = new Vector2(0f, .5f);
                }
            }
        }

        if (playerIndex == 0)
        {
            if (DashUnlock == true)
            {
                if (Input.GetButton("Action 2"))
                {
                    if (dashTimer <= 0)
                    {
                        dashDuration = 0.2f;
                        Dash();
                    }
                    else
                    {
                        Dash();
                    }
                }

            }

        }
        else if (playerIndex == 1)
        {
            if (DashUnlock == true)
            {
                if (Input.GetButton("Fire2"))
                {
                    if (dashTimer <= 0)
                    {
                        dashDuration = 0.2f;
                        Dash();
                    }
                    else
                    {
                        Dash();
                    }
                }
            }
        }
            if (isDashing)
            {
                // Dash movement
                RB.velocity = new Vector2(MoveH * dashSpeed, MoveV * dashSpeed);

                dashDuration -= Time.deltaTime;
                if (dashDuration <= 0f)
                {
                    // Reset velocity and end the dash after the specified duration
                    RB.velocity = new Vector2(MoveH, MoveV);
                    dashTimer = 10f;
                    isDashing = false;

                }
            }
    }
    public void HandleInput()
    {
        if (playerIndex == 0)
        {

            MoveH = Input.GetAxis("Horizontal") * moveSpeed;
            MoveV = Input.GetAxis("Vertical") * moveSpeed;
            RB.velocity = new Vector2(MoveH, MoveV);
        }
        if (playerIndex == 1)
        {
            MoveH = Input.GetAxis("Player 2 h") * moveSpeed;
            MoveV = Input.GetAxis("Player 2 v") * moveSpeed;
            RB.velocity = new Vector2(MoveH, MoveV);
        }



    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Zombie")
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                TakeDamage(enemy.Damage);
            }
        }
        // Assuming Enemy script is attached to the enemy GameObject
    }

    public void TakeDamage(float damage)
    {
        // Apply damage reduction based on defence (if needed)
        float damageTaken = damage - defence;
        HP -= damageTaken;
        HP = Mathf.Clamp(HP, 0, MaxHP);

        slider.value = HP;
        slider.maxValue = MaxHP;

        kb.PlayFeedback(GameObject.FindWithTag("Zombie"));
        hurtsound.Play();

        if (HP <= 0)
        {
            Die();
        }
    }



    
            
            private void Die()
            {
            if (HP <= 0)
                // Handle player's death here
                Highscore.SetActive(true);
                dead = true;
                //Destroy(gameObject);
            }
        void Dash()
        {
            // Perform dash only if the player is not currently dashing
            if (!isDashing)
            {
                isDashing = true;
            }
        }

        private void Update()
        {
            if (playerIndex == 0)
            {
                if (Input.GetButtonDown("Action 3"))
                {
                    if (Nuke)
                    {
                        Nuke_Count--;
                        nuke.Nuke_Drop(this);
                    }
                }
            } else if (playerIndex == 1)
            {
                if (Input.GetButtonDown("Fire3"))
                {
                    if (Nuke)
                    {
                        Nuke_Count--;
                        nuke.Nuke_Drop(this);

                }
            }

            }


        }

    } 




