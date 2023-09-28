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
       
        //  Experience();
    }
    public void Experience()
    { 
        slider.value = EXP;
        slider.maxValue = MaxEXP;

      //  if (enemy.HP <= 0)
       // {
            EXP += Random.Range(6,21);//voor elke zombie die gekilled word krijg player EXP++
       // }
        if (EXP >= MaxEXP)
        {
            //als de Exp maxEXP is
            EXP = 0;//exp word gereset
            CurrentLevel += 1; // level omhoog +1
            MaxEXP += 10;// MaxEXP word verhoogd 
            ExpPoints += 1;// met ExpPoints kan iets halen van de Skill tree
        }
    }
}
