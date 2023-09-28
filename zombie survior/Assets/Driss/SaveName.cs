using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SaveName : MonoBehaviour
{
    public TextMeshProUGUI player1;
    public Slider Slider;
    public void Player1Name()
    {
        string temp = player1.text;
        PlayerPrefs.SetString("P1", temp);
        print(temp);
        SceneManager.LoadScene("Game");
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
