using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MolotovAmmo : bom
{
    public bool DPS;

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
    }

}
