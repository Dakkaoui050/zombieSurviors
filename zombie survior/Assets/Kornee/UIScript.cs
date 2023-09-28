using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

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


    public void back()
    {
        SceneManager.LoadScene("Start Screen");
    }
    private void Awake()
    {
        p = GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
        spawn = GameObject.FindGameObjectWithTag("Spawn").GetComponent<spawnscript>();
        xp = gameObject.GetComponent<XP_points>();
        weaponsManager = GameObject.FindGameObjectWithTag("Weapons Manager").GetComponent<WeaponsManager>();
    }

    private void FixedUpdate()
    {
        money.text = p.Money.ToString();
        Nuke.text = p.Nuke_Count.ToString();
        Level.text = $"Level: {xp.CurrentLevel.ToString()}";
        Wave.text = $"Wave: {spawn.waveNumber.ToString()}";
        Killcount.text = p.killcount.ToString();
        int i = 0;
        foreach(var items in weaponsManager.weapons)
        {
            slots[i].sprite = weaponsManager.weapons[i].image;
            slots[i].color = new Color(255, 255, 255, 255);
            if(i >= 3)
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
