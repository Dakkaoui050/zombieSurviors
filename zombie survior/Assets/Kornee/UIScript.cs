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
           money.text = p.Money.ToString();
    }
    private void FixedUpdate()
    {
        money.text = p.Money.ToString();
        Nuke.text = p.Nuke_Count.ToString();
        Level.text = $"Level: {xp.CurrentLevel.ToString()}";
        Wave.text = $"Wave: {spawn.waveNumber.ToString()}";
        Killcount.text = p.killcount.ToString();
        
        if(p.playerIndex == 0)
        {
            int i = 0;
            foreach (var items in weaponsManager.weaponsP1)
            {
                slots[i].sprite = weaponsManager.weaponsP1[i].image;
                slots[i].color = new Color(255, 255, 255, 255);
                timer[i].gameObject.SetActive(true);
                timer[i].maxValue = weaponsManager.weaponsP1[i].AttackSpeed;
                timer[i].value = weaponsManager.weaponsP1[i].AttackTimerValue;
                if (i >= 3)
                {
                    i = 0;
                }
                else
                {
                    i++;
                }
            }

        }
        else if(p.playerIndex == 1)
        {
            int i = 0;
            foreach (var items in weaponsManager.weaponsP2)
            {

                slots[i].sprite = weaponsManager.weaponsP2[i].image;
                slots[i].color = new Color(255, 255, 255, 255);
                timer[i].gameObject.SetActive(true);
                timer[i].maxValue = weaponsManager.weaponsP2[i].AttackSpeed;
                timer[i].value = weaponsManager.weaponsP2[i].AttackTimerValue;
                if (i >= 3)
                {
                    i = 0;
                }
                else
                {
                    i++;
                }
            }
        }

    }
}
