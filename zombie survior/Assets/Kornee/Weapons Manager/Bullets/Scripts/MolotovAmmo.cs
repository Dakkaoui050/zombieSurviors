using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class MolotovAmmo : bom
{
    public bool DPS;
  
    public bool Done;

    public List<Enemy> enemies = new List<Enemy>();

    private void OnTriggerEnter2D(Collider2D other)
    {
        enemies.Add(other.gameObject.GetComponent<Enemy>());
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        enemies.Remove(collision.gameObject.GetComponent<Enemy>());
    }
    private void FixedUpdate()
    {
        if(DPS)
        {
            foreach (Enemy enemy in enemies)
            {
                enemy.HP -= Damage;
            }
        }
        if (Done)
        {
            Destroy(gameObject);

        }
    }

}
