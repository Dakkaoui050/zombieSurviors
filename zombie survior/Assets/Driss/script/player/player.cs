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
   [SerializeField] private float dashTimer = 10f;
    public bool DashUnlock = false;
    public int poss;
    public float fadeDuration = 2.0f; // Duration of the fade in seconds
    public List<GameObject> Zombies = new List<GameObject>();
    public List<GameObject> PickUps = new List<GameObject>();
    // Start is called before the first frame update

    public CanvasGroup flash;

    public GameObject Highscore;

    public bool dead;
    public void Awake()
    { // Check if an instance already exists
        Money += 1000;
        if (playerIndex == 0)
        {
            player2 = false;
        }
        else if(playerIndex >= 1) 
        {
            player2 = true;
        }
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

        //foreach (var playerInstance in Players)
        //{
        //    playerInstance.HandleInput();
        //}
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
            if (!player2)
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
            else if (player2)
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
                }
                if (Input.GetAxis("Player 2 v") <= -0.1f)
                {
                    firePoint1.transform.localPosition = new Vector2(0f, -.5f);
                    firePoint1.transform.localRotation = Quaternion.Euler(0f, 0f, -90f);
                    firePoint2.transform.localPosition = new Vector2(0f, -.5f);
                    firePoint2.transform.localRotation = Quaternion.Euler(0f, 0f, -105f);
                    firePoint3.transform.localPosition = new Vector2(0f, -.5f);
                    firePoint3.transform.localRotation = Quaternion.Euler(0f, 0f, -75f);
                }
                if (Input.GetAxis("Player 2 v") >= .1f)
                {
                    firePoint1.transform.localPosition = new Vector2(0f, .5f);
                    firePoint1.transform.localRotation = Quaternion.Euler(0f, 0f, 90f);
                    firePoint2.transform.localPosition = new Vector2(0f, .5f);
                    firePoint2.transform.localRotation = Quaternion.Euler(0f, 0f, 105f);
                    firePoint3.transform.localPosition = new Vector2(0f, .5f);
                    firePoint3.transform.localRotation = Quaternion.Euler(0f, 0f, 75f);
                }
            }
        }
        if (DashUnlock == true)
        {
            if (Input.GetButton("Action 2"))
            {
                if(dashTimer <= 0)
                {
                    dashDuration = 0.2f;
                    Dash();
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
        if (!player2)
        {
            
              MoveH = Input.GetAxis("Horizontal") * moveSpeed;
              MoveV = Input.GetAxis("Vertical") * moveSpeed;
              RB.velocity = new Vector2(MoveH, MoveV);
        }
        if (player2)
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
            }



        }

    private void Update()
    {
        if (Input.GetButtonDown("Action 3"))
        {
            if (Nuke)
            {
                Nuke_Count--;
                Nuke_Drop();
            }
        }
    }
}


