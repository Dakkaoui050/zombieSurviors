using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScipt : MonoBehaviour
{

    [SerializeField] private GameObject StartScreen;
    [SerializeField] private GameObject OptionScreen;

   
    void Start()
    {
        StartScreen.SetActive(true);
        OptionScreen.SetActive(false);
    }
    public void Options()
    {
        StartScreen.SetActive(false);
        OptionScreen.SetActive(true);
    }
    public void ToMainMenu()
    {
        StartScreen.SetActive(true);
        OptionScreen.SetActive(false);
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

}
