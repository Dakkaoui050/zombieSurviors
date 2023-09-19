using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SaveName : MonoBehaviour
{
    public TextMeshProUGUI player1;
    public TextMeshProUGUI player2;
    public void Player1Name()
    {
        string temp = player1.text;
        PlayerPrefs.SetString("P1", temp);
        print(temp);
    }
}
