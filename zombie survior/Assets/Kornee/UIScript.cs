using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class UIScript : MonoBehaviour
{
    [Header("Scripts")]
    public player p;
    public spawnscript spawn;
    public XP_points xp;
    public WeaponsManager weaponsManager;
    [Header("Varibles")]
    public TextMeshProUGUI money;
    public TextMeshProUGUI Nuke;
    public TextMeshProUGUI Level;
    public TextMeshProUGUI Wave;
    public TextMeshProUGUI Killcount;
    public nukedrop nuke;


    //inventory
    public Image[] slots;
    public Slider[] timer; 

    public void back()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Start Screen");
    }
    private void Awake()
    {
        
    }

    public void UpdateMoney()
    {
        if (p.playerIndex == 0)
        {
           money.text = p.Money.ToString();
        }
    }

    public void slider()
    {
        if (p.playerIndex == 0)
        {
            foreach (var items in weaponsManager.weaponsP1)
            {
                if(items != null)
                {
                    int i = Array.IndexOf(weaponsManager.weaponsP1, items);
                    timer[i].maxValue = weaponsManager.weaponsP1[i].AttackSpeed;
                    timer[i].value = weaponsManager.weaponsP1[i].AttackTimerValue;
                }
            }
        }
        else if (p.playerIndex == 1)
        {
            foreach (var items in weaponsManager.weaponsP2)
            {
                if (items != null)
                {
                    int i = Array.IndexOf(weaponsManager.weaponsP2, items);
                    timer[i].maxValue = weaponsManager.weaponsP2[i].AttackSpeed;
                    timer[i].value = weaponsManager.weaponsP2[i].AttackTimerValue;
                }
            }
        }
    }
    private void Update()
    {
        if (p.playerIndex == 0)
        {
            foreach (var items in weaponsManager.weaponsP1)
            {
                if (items != null)
                {
                    int i = Array.IndexOf(weaponsManager.weaponsP1, items);
                    timer[i].maxValue = weaponsManager.weaponsP1[i].AttackSpeed;
                    timer[i].value = weaponsManager.weaponsP1[i].AttackTimerValue;
                }
            }
        }
        else if (p.playerIndex == 1)
        {
            foreach (var items in weaponsManager.weaponsP2)
            {
                if (items != null)
                {
                    int i = Array.IndexOf(weaponsManager.weaponsP2, items);
                    timer[i].maxValue = weaponsManager.weaponsP2[i].AttackSpeed;
                    timer[i].value = weaponsManager.weaponsP2[i].AttackTimerValue;
                }
            }
        }
    }
    private void FixedUpdate()
    {
       

       
        
        if(p.playerIndex == 0)
        {
            money.text = p.Money.ToString();
            Nuke.text = nuke.Nuke_count.ToString();
            Level.text = $"Level: {xp.CurrentLevel.ToString()}";
            Wave.text = $"Wave: {spawn.waveNumber.ToString()}";
            Killcount.text = p.killcount.ToString();
            foreach (var items in weaponsManager.weaponsP1)
            {
                if(items != null)
                {
                    for (int i = 0; i < weaponsManager.weaponsP1.Length; i++)
                    {
                        slots[i].sprite = weaponsManager.weaponsP1[i].image;
                        slots[i].color = new Color(255, 255, 255, 255);
                        timer[i].gameObject.SetActive(true);
                    }
                }
            }

        }
        else if(p.playerIndex == 1)
        {
            foreach (var items in weaponsManager.weaponsP2)
            {
                if(items != null)
                {
                    for (int i = 0; i < weaponsManager.weaponsP2.Length; i++)
                    {
                        slots[i].sprite = weaponsManager.weaponsP2[i].image;
                        slots[i].color = new Color(255, 255, 255, 255);
                        timer[i].gameObject.SetActive(true);
                    }
                }
            }
        }

    }
}
