using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.ParticleSystemJobs;


public abstract class Enemy : MonoBehaviour
{
    public ParticleSystem ps;
    private SpriteRenderer SR;
    public player p;
    public int reward = 1;
    [SerializeField] private Slider slider;
    XP_points xp;
    public WeaponsManager wm;
    public bool keepdamage;
    public bool dropping;
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
    Transform temp;
    protected private Transform wayPointTarget;
    public Drop drop;
    public AudioSource audiosource;
    public ParticleSystem blood;

    //Animation
    public Animator Anim;

    //drops
    public int rate;
    public int tom;


    private bool timerActive = false;
    private float timerDuration = 5.0f; // Duration of the timer in seconds
    private float timerStartTime;

    private void Start()
    {
    }
    private void Awake()
    {
        int random = Random.Range(0, 2);
        Debug.Log("de random nummer = " + random);
        if (random == 1)
        {
            Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }
        else if (random == 0)
        {
            Target = GameObject.FindGameObjectWithTag("Player2").GetComponent<Transform>();
        }
        

        p = GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
        Anim = GetComponent<Animator>();
        wm = GameObject.FindGameObjectWithTag("Weapons Manager").GetComponent<WeaponsManager>();
       // Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        wayPointTarget = Target; 
        SR = GetComponent<SpriteRenderer>();
        WayPoint = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        p.Zombies.Add(gameObject);
        xp = GameObject.FindGameObjectWithTag("UIScript").GetComponent<XP_points>();
        drop = GameObject.FindGameObjectWithTag("Gamemaster").GetComponent <Drop>();
        HP = MaxHP;
       
        introduction();

        slider.value = HP;
        slider.maxValue = MaxHP;
    }

    
    private void StopTimer()
    {
        timerActive = false;
    }

    public void Play()
    {
        ps.Play();
    }

    public void Update()
    {

        if(HP <= 0)
        {
            dropping = true;      
            int chance = Random.Range(0, 101);
            if (chance > rate)
            {
                drop.spawnpoint = gameObject.transform;
                drop.Droping();
                Destroy(gameObject);
            }
            
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
            StartTimer();
        }
        if (collision.gameObject.tag == "Bullet")
        {
            audiosource.Play();
            blood.Play();
            var bullet = collision.gameObject.GetComponent<Bullets>();
            HP -= bullet.Damage;
            Destroy(bullet.gameObject);

        }
        
    }

    private IEnumerator CountdownTimer()
    {
        while (timerActive && Time.time - timerStartTime < timerDuration)
        {
           
            yield return null;
        }

        // Timer has finished
        timerActive = false;

        // Perform actions or logic you want when the timer finishes
        Debug.Log("Timer finished!");
        p.TakeDamage(Damage);
    }
    private void StartTimer()
    {
        timerActive = true;
        timerStartTime = Time.time;
        StartCoroutine(CountdownTimer());
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        keepdamage = false;
        StopTimer();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "firepoint")
        {
            print("oke boomer");
            foreach (Weapons items in wm.weaponsP1)
            {
                switch(items.tag)
                {
                    case "Bat":
                        audiosource.Play();
                        blood.Play();
                        HP -= items.Damage;
                        print(items.Damage);
                            break;
                    case "Knife":
                        audiosource.Play();
                        blood.Play();
                        HP -= items.Damage;
                        print(items.Damage);
                        break;
                    case "Sword":
                        audiosource.Play();
                        blood.Play();
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
    public void OnDestroy()
    {
        xp.Experience();
        reward = Random.Range(4,26);
        p.Money = p.Money + reward;
        p.killcount++;
    }
}


