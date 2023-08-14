using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScipt : MonoBehaviour
{

    [SerializeField] private GameObject StartScreen;
    [SerializeField] private GameObject OptionScreen;
    [SerializeField] private GameObject NameInput1player;
    [SerializeField] private GameObject Nameinput2players;


    void Start()
    {
        StartScreen.SetActive(true);
        OptionScreen.SetActive(false); 
        Nameinput2players.SetActive(false);
        NameInput1player.SetActive(false);
    }
    public void Options()
    {
        StartScreen.SetActive(false);
        OptionScreen.SetActive(true);
        Nameinput2players.SetActive(false);
        NameInput1player.SetActive(false);
    }
    public void ToMainMenu()
    {
        StartScreen.SetActive(true);
        OptionScreen.SetActive(false); 
        Nameinput2players.SetActive(false);
        NameInput1player.SetActive(false);
    }
    public void Exit()
    {
        Application.Quit();
        Debug.Log("Exit complete");
    }
    public void OnePlayerOrTwoPlayers(string scenename)
    {
        SceneManager.LoadScene(scenename);
        Debug.Log("Go to the next scene");
    }
    public void Name1()
    {
        StartScreen.SetActive(false);
        OptionScreen.SetActive(false); 
        Nameinput2players.SetActive(false);
        NameInput1player.SetActive(true);
    }
    public void Name2()
    {
        StartScreen.SetActive(false);
        OptionScreen.SetActive(false);
        Nameinput2players.SetActive(true);
        NameInput1player.SetActive(false);
    }

}
