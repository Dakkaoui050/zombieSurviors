using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillTree : MonoBehaviour
{
    public player p;
    public XP_points Xp;
    public GameObject[] heathIncease;
    public GameObject[] Dash;
    public GameObject[] defenceIncease;
    public GameObject[] MovementSpeed;
    public GameObject relive;
    private float requiredXp = 0;
    public GameObject canvas;

    private void Awake()
    {
        
        Xp = GetComponent<XP_points>();
      
        canvas.SetActive(false);
        p = GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
    }
    public void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (canvas.activeSelf)
            {
                canvas.SetActive(false);
            }
            else
            {
                canvas.SetActive(true);
            }
        }

       
       
    }
    public void HealthIncreaseButton(int level)
    {

        switch (level)
        {
            case 0:
                requiredXp = 1;
                p.MaxHP = 120f;
                Debug.Log(p.MaxHP);
                break;
            case 1:
                requiredXp = 2;
                p.MaxHP = 140f;
                break;
            case 2:
                requiredXp = 3;
                p.MaxHP = 160f;
                break;
            case 3:
                requiredXp = 4;
                p.MaxHP = 180f;
                break;
            case 4:
                requiredXp = 5;
                p.MaxHP = 200f;
                break;
            default:
                break;
        }

        if (Xp.ExpPoints >= requiredXp && heathIncease.Length >= level)
        {
            Xp.ExpPoints -= requiredXp;

        }



    }
}
