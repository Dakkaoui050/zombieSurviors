using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SaveName : MonoBehaviour
{
    public TextMeshProUGUI player1;
    public TextMeshProUGUI player2;
    public Slider Slider;
    public void Player1Name(int ammount)
    {
        if (ammount == 1)
        {
            string temp = player1.text;
            print(temp);
            PlayerPrefs.SetString("P1", temp);
            SceneManager.LoadScene("Game");

        }
        else if (ammount == 2)
        {
            string temp = player2.text;
            print(temp);
            PlayerPrefs.SetString("P2", temp);
            SceneManager.LoadScene("Game 1");
        }

    }
    
    public void players()
    {
        PlayerPrefs.SetInt("Players", 1);
    }

    public void ShowKeyboard()
    {
        System.Diagnostics.Process.Start("osk.exe");
        print("Open");
    }
    public void Diff()
    {
        int i = (int)Slider.value;
        PlayerPrefs.SetInt("Diff", i);
    }
}
