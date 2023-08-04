using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    
    private SpriteRenderer SR;
    public player p; 
    [SerializeField] private Slider slider;
    
    //Movement
    [SerializeField] private string EnemyName;
    [SerializeField] protected private float MoveSpeed;
    
    //HealthBar
    public float HP;
    [SerializeField] private float MaxHP;
   [SerializeField] public float Damage;
   
    //Target 
    protected private Transform Target;
    [SerializeField] protected private float Distance;
    [SerializeField] public Transform WayPoint;
    protected private Transform wayPointTarget;

    //Animation
    public Animator Anim;

    private void Awake()
    {
        p = GetComponent<player>();
        Anim = GetComponent<Animator>();
        wayPointTarget = WayPoint;
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        wayPointTarget = Target; 
        SR = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        HP = MaxHP;
       
        introduction();

        slider.value = HP;
        slider.maxValue = MaxHP;
    }

    private void Update()
    {
        Move();
        Flip();
    }

    private void Move()
    {
        float playerDistance = Vector2.Distance(transform.position, Target.position);

        if (playerDistance < Distance)
        {
            transform.position = Vector2.MoveTowards(transform.position, Target.position, MoveSpeed * Time.deltaTime);
            wayPointTarget = Target;
        }
        else
        {
            if (Vector2.Distance(transform.position, WayPoint.position) < 0.01f)
            {
                wayPointTarget = WayPoint;
            }
            transform.position = Vector2.MoveTowards(transform.position, wayPointTarget.position, MoveSpeed * Time.deltaTime);
        }
    }

    public void Flip()
    {
        if (transform.position.x > Target.position.x)
        {
            SR.flipX = true;
        }
        else
        {
            SR.flipX = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Assuming player script is attached to the player GameObject
        player playerScript = collision.gameObject.GetComponent<player>();
        if (playerScript != null)
        {
            playerScript.TakeDamage(Damage);
        }
    }

    private void introduction()
    {
        Debug.Log("Sort Zombie : " + EnemyName + ", HP : " + HP + ", Movement speed : " + MoveSpeed);
    }
}

