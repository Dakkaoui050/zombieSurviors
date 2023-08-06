using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public static player Instance;
    //movement
    private Rigidbody2D RB;
    private float MoveH, MoveV;
    public float moveSpeed;
    public bool lookRight = true;

    //healthBar
    [SerializeField] private Slider slider;
    public float HP;
    public float MaxHP;
    public float defence;
    public float Damage;
    public bool Nuke;
    public int Nuke_Count;
    public int Money;

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
    }

    private void Start()
    {

    }

    void Update()
    {
        MoveH = Input.GetAxis("Horizontal") * moveSpeed;
        MoveV = Input.GetAxis("Vertical") * moveSpeed;

        RB.velocity = new Vector2(MoveH, MoveV);
        if (MoveH > 0 && !lookRight)
        {
            flip();
        }
        if (MoveH < 0 && lookRight)
        {
            flip();
        }
    }

    void flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        lookRight = !lookRight;
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
}

