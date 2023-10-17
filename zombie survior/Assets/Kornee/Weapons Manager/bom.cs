using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class bom : MonoBehaviour
{
    public int Damage;  // de damage van de fire arm bullet
    public float Range; // hoelang hij leeft
    public BoxCollider2D Collider;   // de collider om damage te doen
    public SpriteRenderer Image; // doet nog niks
    public float Speed; // hoe snel hij gaat
    public Animator anim;
    public bool CanMove = true;
    public player player;


    private void Awake()
    {
        //anim.enabled = true;
        player = GameObject.FindWithTag("Player").GetComponent<player>();
    }
    

    private void Update()
    {
        if (CanMove)
        {
            switch (player.poss)
            {
                case 1:
                    transform.Translate(Vector2.right * Speed * Time.deltaTime);
                    break;
                case 2:
                    transform.Translate(Vector2.left * Speed * Time.deltaTime);
                    break;
                case 3:
                    transform.Translate(Vector2.down * Speed * Time.deltaTime);
                    break;
                case 4:
                    transform.Translate(Vector2.up * Speed * Time.deltaTime);
                    break;

            }
        }
        else
        {
            transform.Translate(Vector2.right * 0f);
        }
    }
}
