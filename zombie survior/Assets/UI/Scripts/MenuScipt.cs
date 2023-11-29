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
    [SerializeField] private GameObject NameInput2player;
    [SerializeField] private GameObject Highscores;
    //[SerializeField] private GameObject Nameinput2players;


    void Start()
    {
        PlayerPrefs.DeleteAll();
        StartScreen.SetActive(true);
        OptionScreen.SetActive(false);
        NameInput2player.SetActive(false);
        NameInput1player.SetActive(false);
        Highscores.SetActive(false);

    }
    public void Options()
    {
        StartScreen.SetActive(false);
        OptionScreen.SetActive(true);
        NameInput2player.SetActive(false);
        NameInput1player.SetActive(false);
        Highscores.SetActive(false);

    }
    public void ToMainMenu()
    {
        StartScreen.SetActive(true);
        OptionScreen.SetActive(false);
        NameInput2player.SetActive(false);
        NameInput1player.SetActive(false);
        Highscores.SetActive(false);

    }
    public void Exit()
    {
        Application.Quit();
    }

    public void Name1()
    {
        StartScreen.SetActive(false);
        OptionScreen.SetActive(false);
        NameInput2player.SetActive(false);
        NameInput1player.SetActive(true);
        Highscores.SetActive(false);

    }
    public void Name2()
    {
        StartScreen.SetActive(false);
        OptionScreen.SetActive(false);
        NameInput2player.SetActive(true);
        NameInput1player.SetActive(false);
        Highscores.SetActive(false);
    }
    public void Higscores()
    {
        StartScreen.SetActive(false);
        OptionScreen.SetActive(false);
        NameInput2player.SetActive(false);
        NameInput1player.SetActive(false);
        Highscores.SetActive(true);

    }

}
