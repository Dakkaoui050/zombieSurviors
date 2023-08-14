using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class highscore : MonoBehaviour

{

    spawnscript spawnscript;
    player_Kale_Man player;
    
    public TMP_Text highscorenumber;
    public TMP_InputField HighName;
    public GameObject endscreen;

    private void Update()
    {
        if(player.HP <= 0)  // al is de player dood gaat het eindscherm aan en set hij de highscore
        {
            Debug.Log("doooood");
            sethighscore();
            endscreen.SetActive(true);
        }
    }

    private void Awake()
    {
        spawnscript = GameObject.FindGameObjectWithTag("spawnmanager").GetComponent<spawnscript>(); // pakt de spawnscript voor de wave nummer
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<player_Kale_Man>(); // pakt de player zijn health
        int wavenumber = spawnscript.waveNumber;
        
        
    }
    public void SetName()
    {
        PlayerPrefs.SetString("highscorename", HighName.text);
        Debug.Log(HighName.text);
    }
    public void sethighscore()
    {
        if (spawnscript.waveNumber > PlayerPrefs.GetInt("highscore")) // als jou wave nummer hoger is dan de op moment highscore past hij de highscore aan naar jouw wave nummer
        {
        PlayerPrefs.SetString("highscorename", HighName.text);
        PlayerPrefs.SetInt("highscore", spawnscript.waveNumber); // zet jou wave nummerals de higscore
        highscorenumber.text = PlayerPrefs.GetInt("highscore").ToString(); 
        }
        else
        {
            //niks
        }
    }

    
    
}
