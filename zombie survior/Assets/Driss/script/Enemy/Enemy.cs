using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public abstract class Enemy : MonoBehaviour
{
   
    private SpriteRenderer SR;
    public player p;
    public int reward = 1;
    [SerializeField] private Slider slider;
    XP_points xp;
    public WeaponsManager wm;

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

    //drops
    public GameObject[] pick = new GameObject[3];
    public int rate;

   

    private void Awake()
    {
        p = GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
        Anim = GetComponent<Animator>();
        wm = GameObject.FindGameObjectWithTag("Weapons Manager").GetComponent<WeaponsManager>();
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        wayPointTarget = Target; 
        SR = GetComponent<SpriteRenderer>();
        WayPoint = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        p.Zombies.Add(gameObject);
    }

    private void Start()
    {
        HP = MaxHP;
       
        introduction();

        slider.maxValue = MaxHP;
        slider.value = HP;
    }

    private void Update()
    {
        if(HP <= 0)
        {
            Destroy(gameObject);
            p.killcount++;
        }
        Move();
        Flip();
        slider.value = HP;
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
        if (collision.gameObject.tag == "Bullet")
        {
          var temp = collision.gameObject.GetComponent<Bullets>();
            HP = -temp.Damage;
            Destroy(temp.gameObject);

        }
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "firepoint")
        {
            print("oke boomer");
            foreach (Weapons items in wm.weapons)
            {
                switch(items.tag)
                {
                    case "Bat":
                        HP -= items.Damage;
                        print(items.Damage);
                            break;
                    case "Knife":
                        HP -= items.Damage;
                        print(items.Damage);
                        break;
                    case "Sword":
                        HP -= items.Damage; 
                        print(items.Damage);
                        break;
                    default:
                        break;
                }
            }
        }
    }


    private void introduction()
    {
        Debug.Log("Sort Zombie : " + EnemyName + ", HP : " + HP + ", Movement speed : " + MoveSpeed);
    }

    private void OnDestroy()
    {
        xp = GameObject.FindGameObjectWithTag("UIScript").GetComponent<XP_points>();
        xp.Experience();
        int chance = Random.Range(0, 101);
        if( chance > rate)
        {
            reward = Random.Range(1,4);
            Instantiate(pick[Random.Range(0, 3)], gameObject.transform);
            p.Money = p.Money + reward;
            
        }
    }
}


