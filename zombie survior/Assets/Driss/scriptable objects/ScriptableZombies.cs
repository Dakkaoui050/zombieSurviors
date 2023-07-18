using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "New zombie", menuName = "enemy" )]
public class ScriptableZombies : ScriptableObject
{
    public string Name;
    public int health;
    public int defence;
    public int damage;
    public float speed;

    public Sprite image;

    public RuntimeAnimatorController animatorController;
}
