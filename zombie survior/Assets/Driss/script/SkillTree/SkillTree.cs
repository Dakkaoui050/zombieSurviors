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
    public bool on;
    public GameObject canvas;

    //Relive varable
    public GameObject[] Relive;
    [SerializeField] private bool islive = true;

    private void Awake()
    {

        canvas.SetActive(false);
    }
    public void Update()
    {
        if(p.playerIndex == 0)
        {
            if (Input.GetButtonDown("Action 5") && canvas.activeSelf )
            {          
                    canvas.SetActive(false);       
                
            }
            else if (Input.GetButtonDown("Action 5"))
            {
                canvas.SetActive(true);
           
            }

        }else if (p.playerIndex == 1)
        {
            if (Input.GetButtonDown("Fire4") && canvas.activeSelf)
            {
                canvas.SetActive(false);

            }
            else if (Input.GetButtonDown("Fire4"))
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
                p.MaxHP += 20;
                
                break;
            case 1:
                requiredXp = 2;
                p.MaxHP += 40;
                break;
            case 2:
                requiredXp = 3;
                p.MaxHP += 60;
                break;
            case 3:
                requiredXp = 4;
                p.MaxHP += 80;
                break;
            case 4:
                requiredXp = 5;
                p.MaxHP += 100;
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
                p.defence += .05F;
               
                break;
            case 1:
                requiredXp = 2;
                p.defence += 0.1f;
                break;
            case 2:
                requiredXp = 3;
                p.defence += 0.2f;
                break;
            case 3:
                requiredXp = 4;
                p.defence += 0.3f;
                break;
            case 4:
                requiredXp = 5;
                p.defence += 0.5f;
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
                p.moveSpeed += 5f;
                break;
            case 1:
                requiredXp = 2;
                p.moveSpeed += 5f;
                break;
            case 2:
                requiredXp = 3;
                p.moveSpeed += 5;
                break;
            case 3:
                requiredXp = 4;
                p.moveSpeed += 5;
                break;
            case 4:
                requiredXp = 5;
                p.moveSpeed += 5f;
                break;
            default:
                break;
        } 
        Debug.Log(p.moveSpeed);

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
    public void DashFuction(int DashIncease)
    {
        switch (DashIncease)
        {
            case 0:
                requiredXp = 1;
                p.DashUnlock = true;
                break;
            case 1:
                requiredXp = 2;
                p.dashSpeed = 15;
                break;
            case 2:
                requiredXp = 3;
                p.dashSpeed = 20;
                break;
            case 3:
                requiredXp = 4;
                p.dashSpeed = 25;
                break;
            default:
                break;
        }
        Debug.Log(p.dashSpeed);

        if (Xp.ExpPoints >= requiredXp && Dash.Length >= DashIncease)
        {
            Xp.ExpPoints -= requiredXp;

        }
    }
}
