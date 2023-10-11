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


    private void Awake()
    {
        //anim.enabled = true;
    }
    

    private void Update()
    {
        if (CanMove)
        {
            transform.Translate(Vector2.right * Speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.right * 0f);
        }
    }
}
