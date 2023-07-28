using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    player p;
    [SerializeField] private string EnemyName;
    [SerializeField] protected private float MoveSpeed;
    public float HP;
    [SerializeField] private float MaxHP;

    protected private Transform Target;
    [SerializeField] protected private float Distance;
    private SpriteRenderer SR;
    [SerializeField] private Slider slider;

    [SerializeField] public float Damage;

    [SerializeField] public Transform WayPoint;
    protected private Transform wayPointTarget;

    private void Awake()
    {
        wayPointTarget = WayPoint;
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        wayPointTarget = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Start()
    {
        HP = MaxHP;
        SR = GetComponent<SpriteRenderer>();
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
        if (Vector2.Distance(transform.position, Target.position) < Distance)
        {
            transform.position = Vector2.MoveTowards(transform.position, Target.position, MoveSpeed * Time.deltaTime);
        }

        if (Vector2.Distance(transform.position, Target.position) > Distance)
        {
            if (Vector2.Distance(transform.position, WayPoint.position) < 0.01)
            {
                wayPointTarget = WayPoint;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, wayPointTarget.position, MoveSpeed * Time.deltaTime);
    }

    private void Flip()
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


