using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XP_points : MonoBehaviour
{
    
    private Enemy enemy;
    public Slider slider;
    public float EXP;
    public float MaxEXP;
    public float CurrentLevel;
    public float ExpPoints;

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
        slider.value = EXP;
        slider.maxValue = MaxEXP;
     
    }
    public void FixedUpdate()
    {
        Experance();
    }
    public void Experance()
    {

        if (enemy != null && enemy.HP <= 0)
        {
            EXP += 1;//voor elke zombie die gekilled word krijg player EXP++
        }
        if (EXP == MaxEXP)
        {
            //als de Exp maxEXP is
            EXP = 0;//exp word gereset
            CurrentLevel += 1; // level omhoog +1
            MaxEXP += 10;// MaxEXP word verhoogd 
            ExpPoints += 1;// met ExpPoints kan iets halen van de Skill tree
        }
    }
}