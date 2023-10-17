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

            PlayerPrefs.SetString("P1", player1.text);
            SceneManager.LoadScene("Game");

        }
        else if (ammount == 2)
        {
            PlayerPrefs.SetString("P2", player2.text);
            SceneManager.LoadScene("Co-op mode");
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
