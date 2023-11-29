using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GranadeAnim : bom
{
    public List<Enemy> enemies = new List<Enemy>();
    public bool die;
    public bool Done;

    private void FixedUpdate()
    {
        if(die)
        {
            foreach (Enemy enemy in enemies)
            {
                enemy.HP -= Damage;
            }
        }
        if(Done)
        {
            Destroy(gameObject);

        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
       enemies.Add(other.gameObject.GetComponent<Enemy>());
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        enemies.Remove(collision.gameObject.GetComponent<Enemy>());
    }
}
