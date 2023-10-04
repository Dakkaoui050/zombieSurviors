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

    public GameObject firePoint1;
    public GameObject firePoint2;
    public GameObject firePoint3;
    public AudioSource source;

    //movement
    private Rigidbody2D RB;
    private float MoveH, MoveV;
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

    //dash verables
    private bool isDashing = false;
    public float dashDuration = 0.2f;
    public float dashSpeed = 10f;
    private float dashTimer;
    public bool DashUnlock = false;
    public float fadeDuration = 2.0f; // Duration of the fade in seconds
    public List<GameObject> Zombies = new List<GameObject>();
    // Start is called before the first frame update

    public CanvasGroup flash;

    public GameObject Highscore;

    public bool dead;
    public void Awake()
    { // Check if an instance already exists
        Money += 100;

        //if (Instance == null)
        //{
        //    // If not, set this as the instance
        //    Instance = this;
        //}
        //else
        //{
        //    // If an instance already exists, destroy this duplicate
        //    Destroy(gameObject);
        //}

        RB = GetComponent<Rigidbody2D>();
        HP = MaxHP;
        spriteRenderer = GetComponent<SpriteRenderer>();
        slider.maxValue = MaxHP;
        slider.value = HP;
    }

    private void Start()
    {

    }
    private void Nuke_Drop()
    {
        source.Play();
        foreach (GameObject enemy in Zombies)
        {
            enemy.GetComponent<Enemy>().Play();
            Invoke(nameof(NukeDrop), 2);

        }
    }

    public void FixedUpdate()
    {
        // Handle input and movement for each player
       
        slider.value = HP; 
        
        foreach (var playerInstance in Players)
        {
            playerInstance.HandleInput();
        }

        if (defence > 6)
        {
            defence = 6;
        }
        if (Input.GetButton("Action 3"))
        {
            if (Nuke)
            {
                Nuke_Drop();
            }
        }
        foreach (var t in Zombies)
        {
            if (t == null)

            {
                Zombies.Remove(t);
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
            MoveH = Input.GetAxis("Horizontal" + playerIndex) * moveSpeed;
            MoveV = Input.GetAxis("Vertical" + playerIndex) * moveSpeed;
            RB.velocity = new Vector2(MoveH, MoveV);

            if (Input.GetAxis("Horizontal") <= -0.1f)
            {
                spriteRenderer.flipX = true;
                firePoint1.transform.localPosition = new Vector2(-.5f, 0f);
                firePoint1.transform.localRotation = Quaternion.Euler(0f, 0f, 180f);
                firePoint2.transform.localPosition = new Vector2(-.5f, 0f);
                firePoint2.transform.localRotation = Quaternion.Euler(0f, 0f, 165f);
                firePoint3.transform.localPosition = new Vector2(-.5f, 0f);
                firePoint3.transform.localRotation = Quaternion.Euler(0f, 0f, 195f);
            }
            if (Input.GetAxis("Horizontal") >= .1f)
            {
                spriteRenderer.flipX = false;
                firePoint1.transform.localPosition = new Vector2(.5f, 0f);
                firePoint1.transform.localRotation = Quaternion.Euler(0f, 0f, 0);
                firePoint2.transform.localPosition = new Vector2(.5f, 0f);
                firePoint2.transform.localRotation = Quaternion.Euler(0f, 0f, -15f);
                firePoint3.transform.localPosition = new Vector2(.5f, 0f);
                firePoint3.transform.localRotation = Quaternion.Euler(0f, 0f, 15f);
            }
            if (Input.GetAxis("Vertical") <= -0.1f)
            {
                firePoint1.transform.localPosition = new Vector2(0f, -.5f);
                firePoint1.transform.localRotation = Quaternion.Euler(0f, 0f, -90f);
                firePoint2.transform.localPosition = new Vector2(0f, -.5f);
                firePoint2.transform.localRotation = Quaternion.Euler(0f, 0f, -105f);
                firePoint3.transform.localPosition = new Vector2(0f, -.5f);
                firePoint3.transform.localRotation = Quaternion.Euler(0f, 0f, -75f);
            }
            if (Input.GetAxis("Vertical") >= .1f)
            {
                firePoint1.transform.localPosition = new Vector2(0f, .5f);
                firePoint1.transform.localRotation = Quaternion.Euler(0f, 0f, 90f);
                firePoint2.transform.localPosition = new Vector2(0f, .5f);
                firePoint2.transform.localRotation = Quaternion.Euler(0f, 0f, 105f);
                firePoint3.transform.localPosition = new Vector2(0f, .5f);
                firePoint3.transform.localRotation = Quaternion.Euler(0f, 0f, 75f);
            }
        }
        if (DashUnlock == true)
        {
            if (Input.GetButton("Action 2"))
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
    protected virtual void HandleInput()
    {
        // Handle input for the current player instance (base class)
        MoveH = Input.GetAxis("Horizontal" + playerIndex) * moveSpeed;
        MoveV = Input.GetAxis("Vertical" + playerIndex) * moveSpeed;

        
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

        if (HP <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
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
            dashTimer = dashDuration;
        }
    }
    private IEnumerator FadePanel()
    {
        float elapsedTime = 0;
        float startAlpha = 0.75f; // Starting alpha value
        float targetAlpha = 0.0f; // Ending alpha value

        while (elapsedTime < fadeDuration)
        {
            // Calculate the new alpha value based on the elapsed time
            float newAlpha = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / fadeDuration);

            // Set the alpha value of the CanvasGroup
            flash.alpha = newAlpha;

            // Increment the elapsed time
            elapsedTime += Time.deltaTime;

            yield return null; // Wait for the next frame
        }

        flash.alpha = targetAlpha;
    }
        public void NukeDrop()
        {
                StartCoroutine(FadePanel());
            if (Nuke && Nuke_Count > 0)
            {
                foreach (GameObject @object in Zombies)
                {
                    Destroy(@object);
                }
                Zombies.Clear();
                Nuke_Count--;
            }



        }
}


