using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    public int Damage;
    public float Range;
    public CircleCollider2D Collider;
    public Sprite Image;
    public float Speed;

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
}
