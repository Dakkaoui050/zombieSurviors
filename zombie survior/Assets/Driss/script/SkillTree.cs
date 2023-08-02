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
    private float requiredXp = 0;
    public GameObject canvas;

    //Relive varable
    public GameObject[] Relive;
    [SerializeField] private bool islive = true;

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
        Debug.Log(p.MaxHP);

        if (Xp.ExpPoints >= requiredXp && heathIncease.Length >= level)
        {
            Xp.ExpPoints -= requiredXp;

        }
    }
    public void DefenceInceaseButton(int DefenceLevel)
    {
        switch (DefenceLevel)
        {
            case 0:
                requiredXp = 1;
                p.defence = 0.05f;
               
                break;
            case 1:
                requiredXp = 2;
                p.defence = 0.1f;
                break;
            case 2:
                requiredXp = 3;
                p.defence = 0.2f;
                break;
            case 3:
                requiredXp = 4;
                p.defence = 0.3f;
                break;
            case 4:
                requiredXp = 5;
                p.defence = 0.5f;
                break;
            default:
                break;
        }
        Debug.Log(p.defence);

        if (Xp.ExpPoints >= requiredXp && defenceIncease.Length >= DefenceLevel)
        {
            Xp.ExpPoints -= requiredXp;

        }
    }
    public void MovementIncease(int MovementLevel)
    {
        switch (MovementLevel)
        {
            case 0:
                requiredXp = 1;
                p.moveSpeed = 3f;
                break;
            case 1:
                requiredXp = 2;
                p.moveSpeed = 3.5f;
                break;
            case 2:
                requiredXp = 3;
                p.moveSpeed = 4;
                break;
            case 3:
                requiredXp = 4;
                p.moveSpeed = 5;
                break;
            case 4:
                requiredXp = 5;
                p.moveSpeed = 5.5f;
                break;
            default:
                break;
        } 
        Debug.Log(p.MaxHP);

        if (Xp.ExpPoints >= requiredXp && MovementSpeed.Length >= MovementLevel)
        {
            Xp.ExpPoints -= requiredXp;

        }
    }
    public void live(int relive)
    {
        if(islive == true)
        {   
            switch (relive)
            {
                case 0:
                    requiredXp = 10;
                    if(p.HP < 5)
                    {
                        p.HP = p.MaxHP;
                        islive = false;
                    }
                    break;
            
                default:
                    break;
            }

        }
        
        Debug.Log(p.MaxHP + "living 1 more");

        if (Xp.ExpPoints >= requiredXp && Relive.Length >= relive)
        {
            Xp.ExpPoints -= requiredXp;

        }
    }
}
