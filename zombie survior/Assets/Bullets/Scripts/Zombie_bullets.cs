using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_bullets : MonoBehaviour
{
    public int Damage;  // de damage van de fire arm bullet
    public float Range; // hoelang hij leeft
    public CircleCollider2D Collider;   // de collider om damage te doen
    public Sprite Image; // doet nog niks
    public float Speed; // hoe snel hij gaat

    private void Start()
    {
        // Destroy the bullet after the specified lifetime
        Destroy(gameObject, Range);
    }

    private void Update()
    {
        // Move the bullet forward
        transform.Translate(Vector2.right * Speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<player>().HP -= Damage;
            Destroy(gameObject);
        }
    }
    
}
