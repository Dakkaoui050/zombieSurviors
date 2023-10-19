using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UIElements;
using UnityEngine.UI;
using TMPro;
using System;

public class ShopInteractions : MonoBehaviour
{
    [Header("wapens object")]
    Button[] buyButton;
    public GameObject pistol;
    public GameObject shotgun;
    public GameObject sword;
    public GameObject submachineGun;
    public GameObject machineGun;
    public GameObject Crossbow;
    public GameObject Molotov;
    public GameObject grenade;
    public GameObject bat;
    public GameObject knife;
    public Transform player;
    public WeaponsManager[] weaponsm;

    public GameObject[] Players;
    public int play;

    [Header("wapenImgages")]
    public Image pistolImg;
    public Image shotgunImg;
    public Image swordImg;
    public Image submachineGunImg;
    public Image machineGunImg;
    public Image CrossbowImg;
    public Image MolotovImg;
    public Image GrenadeImg;
    public Image batImg;
    public Image knifeImg;

    public player p;
    public TMP_Text moneyText;


    public Canvas shopcanvasP1; 
    public GameObject weaponchangingP1;
    public GameObject weaponchangingP2;

    public Image chosenweaponToGet;
    public Image chosenweaponToGet2;
    public GameObject ChosenWeaponToGetGameObject;
    public GameObject ChosenWeaponToGetGameObject2;
    public Sprite[] weaponImage;
    public ShopManager shopManager;
    public UIScript[] ui;

    public Image[] arrayspace;

    void Start()
    {
    }
    private void Awake()
    {

        //shopManager = GameObject.FindWithTag("Shop").GetComponent<ShopManager>();
       

    }
    public void replaceWeapon(int number)
    {
        if (play == 0)
        { 
            switch(number)
            {
                case 1:
               
                    var temp = weaponsm[0].weaponsP1[0];
                    Array.Clear(weaponsm[0].weaponsP1, Array.IndexOf(weaponsm[0].weaponsP1, temp),1);
                    Destroy(temp.gameObject);
                    Instantiate(ChosenWeaponToGetGameObject, Players[0].transform);
                    weaponchangingP1.SetActive(false);
                    Time.timeScale = 1;
                    shopManager.closeShop();
                
                
                

                    break;
                case 2:
                    var temp1 = weaponsm[0].weaponsP1[1];
                    Array.Clear(weaponsm[0].weaponsP1, Array.IndexOf(weaponsm[0].weaponsP1, temp1), 1);
                    Destroy(temp1.gameObject);
                    Instantiate(ChosenWeaponToGetGameObject, Players[0].transform);
                    weaponchangingP1.SetActive(false);
                    Time.timeScale = 1;
                    shopManager.closeShop();

                    break;
                case 3:
                    var temp2 = weaponsm[0].weaponsP1[2];
                    Array.Clear(weaponsm[0].weaponsP1, Array.IndexOf(weaponsm[0].weaponsP1, temp2), 1);
                    Destroy(temp2.gameObject);
                    Instantiate(ChosenWeaponToGetGameObject, Players[0].transform);
                    weaponchangingP1.SetActive(false);
                    Time.timeScale = 1;
                    shopManager.closeShop();

                    break;
                case 4:
                    var temp3 = weaponsm[0].weaponsP1[3];
                    Array.Clear(weaponsm[0].weaponsP1, Array.IndexOf(weaponsm[0].weaponsP1, temp3), 1);
                    Destroy(temp3.gameObject);
                    Instantiate(ChosenWeaponToGetGameObject, Players[0].transform);
                    weaponchangingP1.SetActive(false);
                    Time.timeScale = 1;
                    shopManager.closeShop();

                    break;
            }
        }
        if(play == 1)
        {
            switch (number)
            {
                case 5:

                    var temp = weaponsm[1].weaponsP2[0];
                    Array.Clear(weaponsm[1].weaponsP2, Array.IndexOf(weaponsm[1].weaponsP2, temp), 1);
                    Destroy(temp.gameObject);
                    Instantiate(ChosenWeaponToGetGameObject, Players[1].transform);
                    weaponchangingP2.SetActive(false);
                    Time.timeScale = 1;
                    shopManager.closeShop();




                    break;
                case 6:
                    var temp1 = weaponsm[1].weaponsP2[1];
                    Array.Clear(weaponsm[1].weaponsP2, Array.IndexOf(weaponsm[1].weaponsP2, temp1), 1);
                    Destroy(temp1.gameObject);
                    Instantiate(ChosenWeaponToGetGameObject, Players[1].transform);
                    weaponchangingP2.SetActive(false);
                    Time.timeScale = 1;
                    shopManager.closeShop();

                    break;
                case 7:
                    var temp2 = weaponsm[1].weaponsP2[2];
                    Array.Clear(weaponsm[1].weaponsP2, Array.IndexOf(weaponsm[1].weaponsP2, temp2), 1);
                    Destroy(temp2.gameObject);
                    Instantiate(ChosenWeaponToGetGameObject, Players[1].transform);
                    weaponchangingP2.SetActive(false);
                    Time.timeScale = 1;
                    shopManager.closeShop();

                    break;
                case 8:
                    var temp3 = weaponsm[1].weaponsP2[3];
                    Array.Clear(weaponsm[1].weaponsP2, Array.IndexOf(weaponsm[1].weaponsP2, temp3), 1);
                    Destroy(temp3.gameObject);
                    Instantiate(ChosenWeaponToGetGameObject, Players[1].transform);
                    weaponchangingP2.SetActive(false);
                    Time.timeScale = 1;
                    shopManager.closeShop();

                    break;
            }
        }
    }
    public void ButtonBuy(string type)
    {
       if(play == 0)
       {
            switch (type)
            {
                case  "pistol":
                    if (IsArrayFull(weaponsm[0].weaponsP1))
                    {
                        // Execute this if the array is full
                        Debug.Log("Array is full. Executing action for full array.");
                        weaponchange();
                        chosenweaponToGet.sprite = weaponImage[0];
                        ChosenWeaponToGetGameObject = pistol;
                        arrayspace[0].sprite = weaponsm[0].weaponsP1[0].GetComponent<Image>().sprite;
                        arrayspace[1].sprite = weaponsm[0].weaponsP1[1].GetComponent<Image>().sprite;
                        arrayspace[2].sprite = weaponsm[0].weaponsP1[2].GetComponent<Image>().sprite;
                        arrayspace[3].sprite = weaponsm[0].weaponsP1[3].GetComponent<Image>().sprite;
                        // Place your code here for when the array is full
                    }
                
                    else
                    {
                        if(p.Money >= 100)
                        {
                        // Execute this if the array is not full
                        Instantiate(pistol, Players[play].transform);
                            // Place your code here for when the array is not full
                            moneyUpdate(100);



                        }
                        else
                        {
                            //je hebt niet genoeg geld
                            Debug.Log("niet genoeg geld");
                        }
                        
                    }

                    break;

                case "shotgun":
                    if (IsArrayFull(weaponsm[0].weaponsP1))
                    {
                        // Execute this if the array is full
                        Debug.Log("Array is full. Executing action for full array.");
                        weaponchange();
                        chosenweaponToGet.sprite = weaponImage[1];
                        ChosenWeaponToGetGameObject = shotgun;
                        arrayspace[0].sprite = weaponsm[0].weaponsP1[0].GetComponent<Image>().sprite;
                        arrayspace[1].sprite = weaponsm[0].weaponsP1[1].GetComponent<Image>().sprite;
                        arrayspace[2].sprite = weaponsm[0].weaponsP1[2].GetComponent<Image>().sprite;
                        arrayspace[3].sprite = weaponsm[0].weaponsP1[3].GetComponent<Image>().sprite;
                        // Place your code here for when the array is full
                    }
                    else
                    {
                        if(p.Money >= 200)
                        {
                        // Execute this if the array is not full
                        Instantiate(shotgun, Players[play].transform);
                        moneyUpdate(200);
                        // Place your code here for when the array is not full

                        }
                    }


                    break;

                case "sword":

                    if (IsArrayFull(weaponsm[0].weaponsP1))
                    {
                        // Execute this if the array is full
                        Debug.Log("Array is full. Executing action for full array.");
                        weaponchange();
                        chosenweaponToGet.sprite = weaponImage[2];
                        ChosenWeaponToGetGameObject = sword;
                        arrayspace[0].sprite = weaponsm[0].weaponsP1[0].GetComponent<Image>().sprite;
                        arrayspace[1].sprite = weaponsm[0].weaponsP1[1].GetComponent<Image>().sprite;
                        arrayspace[2].sprite = weaponsm[0].weaponsP1[2].GetComponent<Image>().sprite;
                        arrayspace[3].sprite = weaponsm[0].weaponsP1[3].GetComponent<Image>().sprite;
                        // Place your code here for when the array is full
                    }
                    else
                    {
                        if(p.Money >= 250)
                        {
                        // Execute this if the array is not full
                        Instantiate(sword, Players[play].transform);
                            moneyUpdate(250);
                        // Place your code here for when the array is not full
                         }
                    }

                    break;

                case "submachine":

                    if (IsArrayFull(weaponsm[0].weaponsP1))
                    {
                        // Execute this if the array is full
                        Debug.Log("Array is full. Executing action for full array.");
                        weaponchange();
                        chosenweaponToGet.sprite = weaponImage[3];
                        ChosenWeaponToGetGameObject = submachineGun;
                        arrayspace[0].sprite = weaponsm[0].weaponsP1[0].GetComponent<Image>().sprite;
                        arrayspace[1].sprite = weaponsm[0].weaponsP1[1].GetComponent<Image>().sprite;
                        arrayspace[2].sprite = weaponsm[0].weaponsP1[2].GetComponent<Image>().sprite;
                        arrayspace[3].sprite = weaponsm[0].weaponsP1[3].GetComponent<Image>().sprite;
                        // Place your code here for when the array is full
                    }
                    else
                    {
                        if (p.Money >= 600)
                        {
                            // Execute this if the array is not full
                            Instantiate(submachineGun, Players[play].transform);
                            moneyUpdate(600);
                            // Place your code here for when the array is not full
                        }
                    }

                    break;

                case "machine gun":

                    if (IsArrayFull(weaponsm[0].weaponsP1))
                    {
                        // Execute this if the array is full
                        Debug.Log("Array is full. Executing action for full array.");
                        weaponchange();

                        chosenweaponToGet.sprite = weaponImage[4];
                        ChosenWeaponToGetGameObject = machineGun;
                        arrayspace[0].sprite = weaponsm[0].weaponsP1[0].GetComponent<Image>().sprite;
                        arrayspace[1].sprite = weaponsm[0].weaponsP1[1].GetComponent<Image>().sprite;
                        arrayspace[2].sprite = weaponsm[0].weaponsP1[2].GetComponent<Image>().sprite;
                        arrayspace[3].sprite = weaponsm[0].weaponsP1[3].GetComponent<Image>().sprite;
                        // Place your code here for when the array is full
                    }
                    else
                    {
                        if (p.Money >= 1000)
                        {
                            // Execute this if the array is not full
                            Instantiate(machineGun, Players[play].transform);
                            moneyUpdate(1000);
                            // Place your code here for when the array is not full
                        }
                    }

                    break;

                case "crossbow":

                    if (IsArrayFull(weaponsm[0].weaponsP1))
                    {
                        // Execute this if the array is full
                        Debug.Log("Array is full. Executing action for full array.");
                        weaponchange();

                        chosenweaponToGet.sprite = weaponImage[5];
                        ChosenWeaponToGetGameObject = Crossbow;
                        arrayspace[0].sprite = weaponsm[0].weaponsP1[0].GetComponent<Image>().sprite;
                        arrayspace[1].sprite = weaponsm[0].weaponsP1[1].GetComponent<Image>().sprite;
                        arrayspace[2].sprite = weaponsm[0].weaponsP1[2].GetComponent<Image>().sprite;
                        arrayspace[3].sprite = weaponsm[0].weaponsP1[3].GetComponent<Image>().sprite;
                        // Place your code here for when the array is full
                    }
                    else
                    {
                        if (p.Money >= 400)
                        {
                            // Execute this if the array is not full
                            Instantiate(Crossbow, Players[play].transform);
                            moneyUpdate(400);
                            // Place your code here for when the array is not full
                        }
                    }

                    break;

                case "molotov":

                    if (IsArrayFull(weaponsm[0].weaponsP1))
                    {
                        // Execute this if the array is full
                        Debug.Log("Array is full. Executing action for full array.");
                        weaponchange();

                        chosenweaponToGet.sprite = weaponImage[6];
                        ChosenWeaponToGetGameObject = Molotov;
                        arrayspace[0].sprite = weaponsm[0].weaponsP1[0].GetComponent<Image>().sprite;
                        arrayspace[1].sprite = weaponsm[0].weaponsP1[1].GetComponent<Image>().sprite;
                        arrayspace[2].sprite = weaponsm[0].weaponsP1[2].GetComponent<Image>().sprite;
                        arrayspace[3].sprite = weaponsm[0].weaponsP1[3].GetComponent<Image>().sprite;
                        // Place your code here for when the array is full
                    }
                    else
                    {
                        if (p.Money >= 700)
                        {
                            // Execute this if the array is not full
                            Instantiate(Molotov, Players[play].transform);
                            moneyUpdate(700);
                            // Place your code here for when the array is not full
                        }
                    }

                    break;

                case "grenade":
                    if (IsArrayFull(weaponsm[0].weaponsP1))
                    {
                        // Execute this if the array is full
                        Debug.Log("Array is full. Executing action for full array.");
                        weaponchange();

                        chosenweaponToGet.sprite = weaponImage[7];
                        ChosenWeaponToGetGameObject = grenade;
                        arrayspace[0].sprite = weaponsm[0].weaponsP1[0].GetComponent<Image>().sprite;
                        arrayspace[1].sprite = weaponsm[0].weaponsP1[1].GetComponent<Image>().sprite;
                        arrayspace[2].sprite = weaponsm[0].weaponsP1[2].GetComponent<Image>().sprite;
                        arrayspace[3].sprite = weaponsm[0].weaponsP1[3].GetComponent<Image>().sprite;
                        // Place your code here for when the array is full
                    }
                    else
                    {
                        if (p.Money >= 800)
                        {
                            // Execute this if the array is not full
                            Instantiate(grenade, Players[play].transform);
                            moneyUpdate(800);
                            // Place your code here for when the array is not full
                        }
                    }

                    break;

                case "bat":

                    if (IsArrayFull(weaponsm[0].weaponsP1))
                    {
                        // Execute this if the array is full
                        Debug.Log("Array is full. Executing action for full array.");
                        weaponchange();

                        chosenweaponToGet.sprite = weaponImage[8];
                        ChosenWeaponToGetGameObject = bat;
                        arrayspace[0].sprite = weaponsm[0].weaponsP1[0].GetComponent<Image>().sprite;
                        arrayspace[1].sprite = weaponsm[0].weaponsP1[1].GetComponent<Image>().sprite;
                        arrayspace[2].sprite = weaponsm[0].weaponsP1[2].GetComponent<Image>().sprite;
                        arrayspace[3].sprite = weaponsm[0].weaponsP1[3].GetComponent<Image>().sprite;
                        // Place your code here for when the array is full
                    }
                    else
                    {
                        if (p.Money >= 150)
                        {
                            // Execute this if the array is not full
                            Instantiate(bat, Players[play].transform);
                            moneyUpdate(150);
                            // Place your code here for when the array is not full
                        }
                    }

                    break;

                case "knife":

                    if (IsArrayFull(weaponsm[0].weaponsP1))
                    {
                        // Execute this if the array is full
                        Debug.Log("Array is full. Executing action for full array.");
                        weaponchange();

                        chosenweaponToGet.sprite = weaponImage[9];
                        ChosenWeaponToGetGameObject = knife;
                        arrayspace[0].sprite = weaponsm[0].weaponsP1[0].GetComponent<Image>().sprite;
                        arrayspace[1].sprite = weaponsm[0].weaponsP1[1].GetComponent<Image>().sprite;
                        arrayspace[2].sprite = weaponsm[0].weaponsP1[2].GetComponent<Image>().sprite;
                        arrayspace[3].sprite = weaponsm[0].weaponsP1[3].GetComponent<Image>().sprite;
                        // Place your code here for when the array is full
                    }
                    else
                    {
                        if (p.Money >= 50)
                        {
                            // Execute this if the array is not full
                            Instantiate(knife, Players[play].transform);
                            moneyUpdate(50);
                            // Place your code here for when the array is not full
                        }
                    }


                    break;


            }

       }
       if (play == 1)
        {
            switch (type)
            {
                case "pistol":
                    if (IsArrayFull(weaponsm[1].weaponsP2))
                    {
                        // Execute this if the array is full
                        Debug.Log("Array is full. Executing action for full array.");
                        weaponchange();
                        chosenweaponToGet2.sprite = weaponImage[0];
                        ChosenWeaponToGetGameObject = pistol;
                        arrayspace[4].sprite = weaponsm[1].weaponsP2[0].GetComponent<Image>().sprite;
                        arrayspace[5].sprite = weaponsm[1].weaponsP2[1].GetComponent<Image>().sprite;
                        arrayspace[6].sprite = weaponsm[1].weaponsP2[2].GetComponent<Image>().sprite;
                        arrayspace[7].sprite = weaponsm[1].weaponsP2[3].GetComponent<Image>().sprite;
                        // Place your code here for when the array is full
                    }

                    else
                    {
                        if (p.Money >= 100)
                        {
                            // Execute this if the array is not full
                            Instantiate(pistol, Players[play].transform);
                            // Place your code here for when the array is not full
                            moneyUpdate(100);



                        }
                        else
                        {
                            //je hebt niet genoeg geld
                            Debug.Log("niet genoeg geld");
                        }

                    }

                    break;

                case "shotgun":
                    if (IsArrayFull(weaponsm[1].weaponsP2))
                    {
                        // Execute this if the array is full
                        Debug.Log("Array is full. Executing action for full array.");
                        weaponchange();
                        chosenweaponToGet2.sprite = weaponImage[1];
                        ChosenWeaponToGetGameObject = shotgun;
                        arrayspace[4].sprite = weaponsm[1].weaponsP2[0].GetComponent<Image>().sprite;
                        arrayspace[5].sprite = weaponsm[1].weaponsP2[1].GetComponent<Image>().sprite;
                        arrayspace[6].sprite = weaponsm[1].weaponsP2[2].GetComponent<Image>().sprite;
                        arrayspace[7].sprite = weaponsm[1].weaponsP2[3].GetComponent<Image>().sprite;
                        // Place your code here for when the array is full
                    }
                    else
                    {
                        if (p.Money >= 200)
                        {
                            // Execute this if the array is not full
                            Instantiate(shotgun, Players[play].transform);
                            moneyUpdate(200);
                            // Place your code here for when the array is not full

                        }
                    }


                    break;

                case "sword":

                    if (IsArrayFull(weaponsm[1].weaponsP2))
                    {
                        // Execute this if the array is full
                        Debug.Log("Array is full. Executing action for full array.");
                        weaponchange();
                        chosenweaponToGet2.sprite = weaponImage[2];
                        ChosenWeaponToGetGameObject = sword;
                        arrayspace[4].sprite = weaponsm[1].weaponsP2[0].GetComponent<Image>().sprite;
                        arrayspace[5].sprite = weaponsm[1].weaponsP2[1].GetComponent<Image>().sprite;
                        arrayspace[6].sprite = weaponsm[1].weaponsP2[2].GetComponent<Image>().sprite;
                        arrayspace[7].sprite = weaponsm[1].weaponsP2[3].GetComponent<Image>().sprite;
                        // Place your code here for when the array is full
                    }
                    else
                    {
                        if (p.Money >= 250)
                        {
                            // Execute this if the array is not full
                            Instantiate(sword, Players[play].transform);
                            moneyUpdate(250);
                            // Place your code here for when the array is not full
                        }
                    }

                    break;

                case "submachine":

                    if (IsArrayFull(weaponsm[1].weaponsP2))
                    {
                        // Execute this if the array is full
                        Debug.Log("Array is full. Executing action for full array.");
                        weaponchange();
                        chosenweaponToGet2.sprite = weaponImage[3];
                        ChosenWeaponToGetGameObject = submachineGun;
                        arrayspace[4].sprite = weaponsm[1].weaponsP2[0].GetComponent<Image>().sprite;
                        arrayspace[5].sprite = weaponsm[1].weaponsP2[1].GetComponent<Image>().sprite;
                        arrayspace[6].sprite = weaponsm[1].weaponsP2[2].GetComponent<Image>().sprite;
                        arrayspace[7].sprite = weaponsm[1].weaponsP2[3].GetComponent<Image>().sprite;
                        // Place your code here for when the array is full
                    }
                    else
                    {
                        if (p.Money >= 600)
                        {
                            // Execute this if the array is not full
                            Instantiate(submachineGun, Players[play].transform);
                            moneyUpdate(600);
                            // Place your code here for when the array is not full
                        }
                    }

                    break;

                case "machine gun":

                    if (IsArrayFull(weaponsm[1].weaponsP2))
                    {
                        // Execute this if the array is full
                        Debug.Log("Array is full. Executing action for full array.");
                        weaponchange();

                        chosenweaponToGet2.sprite = weaponImage[4];
                        ChosenWeaponToGetGameObject = machineGun;
                        arrayspace[4].sprite = weaponsm[1].weaponsP2[0].GetComponent<Image>().sprite;
                        arrayspace[5].sprite = weaponsm[1].weaponsP2[1].GetComponent<Image>().sprite;
                        arrayspace[6].sprite = weaponsm[1].weaponsP2[2].GetComponent<Image>().sprite;
                        arrayspace[7].sprite = weaponsm[1].weaponsP2[3].GetComponent<Image>().sprite;
                        // Place your code here for when the array is full
                    }
                    else
                    {
                        if (p.Money >= 1000)
                        {
                            // Execute this if the array is not full
                            Instantiate(machineGun, Players[play].transform);
                            moneyUpdate(1000);
                            // Place your code here for when the array is not full
                        }
                    }

                    break;

                case "crossbow":

                    if (IsArrayFull(weaponsm[1].weaponsP2))
                    {
                        // Execute this if the array is full
                        Debug.Log("Array is full. Executing action for full array.");
                        weaponchange();

                        chosenweaponToGet2.sprite = weaponImage[5];
                        ChosenWeaponToGetGameObject = Crossbow;
                        arrayspace[4].sprite = weaponsm[1].weaponsP2[0].GetComponent<Image>().sprite;
                        arrayspace[5].sprite = weaponsm[1].weaponsP2[1].GetComponent<Image>().sprite;
                        arrayspace[6].sprite = weaponsm[1].weaponsP2[2].GetComponent<Image>().sprite;
                        arrayspace[7].sprite = weaponsm[1].weaponsP2[3].GetComponent<Image>().sprite;
                        // Place your code here for when the array is full
                    }
                    else
                    {
                        if (p.Money >= 400)
                        {
                            // Execute this if the array is not full
                            Instantiate(Crossbow, Players[play].transform);
                            moneyUpdate(400);
                            // Place your code here for when the array is not full
                        }
                    }

                    break;

                case "molotov":

                    if (IsArrayFull(weaponsm[1].weaponsP2))
                    {
                        // Execute this if the array is full
                        Debug.Log("Array is full. Executing action for full array.");
                        weaponchange();

                        chosenweaponToGet2.sprite = weaponImage[6];
                        ChosenWeaponToGetGameObject = Molotov;
                        arrayspace[4].sprite = weaponsm[1].weaponsP2[0].GetComponent<Image>().sprite;
                        arrayspace[5].sprite = weaponsm[1].weaponsP2[1].GetComponent<Image>().sprite;
                        arrayspace[6].sprite = weaponsm[1].weaponsP2[2].GetComponent<Image>().sprite;
                        arrayspace[7].sprite = weaponsm[1].weaponsP2[3].GetComponent<Image>().sprite;
                        // Place your code here for when the array is full
                    }
                    else
                    {
                        if (p.Money >= 700)
                        {
                            // Execute this if the array is not full
                            Instantiate(Molotov, Players[play].transform);
                            moneyUpdate(700);
                            // Place your code here for when the array is not full
                        }
                    }

                    break;

                case "grenade":
                    if (IsArrayFull(weaponsm[1].weaponsP2))
                    {
                        // Execute this if the array is full
                        Debug.Log("Array is full. Executing action for full array.");
                        weaponchange();

                        chosenweaponToGet2.sprite = weaponImage[7];
                        ChosenWeaponToGetGameObject = grenade;
                        arrayspace[4].sprite = weaponsm[1].weaponsP2[0].GetComponent<Image>().sprite;
                        arrayspace[5].sprite = weaponsm[1].weaponsP2[1].GetComponent<Image>().sprite;
                        arrayspace[6].sprite = weaponsm[1].weaponsP2[2].GetComponent<Image>().sprite;
                        arrayspace[7].sprite = weaponsm[1].weaponsP2[3].GetComponent<Image>().sprite;
                        // Place your code here for when the array is full
                    }
                    else
                    {
                        if (p.Money >= 800)
                        {
                            // Execute this if the array is not full
                            Instantiate(grenade, Players[play].transform);
                            moneyUpdate(800);
                            // Place your code here for when the array is not full
                        }
                    }

                    break;

                case "bat":

                    if (IsArrayFull(weaponsm[1].weaponsP2))
                    {
                        // Execute this if the array is full
                        Debug.Log("Array is full. Executing action for full array.");
                        weaponchange();

                        chosenweaponToGet2.sprite = weaponImage[8];
                        ChosenWeaponToGetGameObject = bat;
                        arrayspace[4].sprite = weaponsm[1].weaponsP2[0].GetComponent<Image>().sprite;
                        arrayspace[5].sprite = weaponsm[1].weaponsP2[1].GetComponent<Image>().sprite;
                        arrayspace[6].sprite = weaponsm[1].weaponsP2[2].GetComponent<Image>().sprite;
                        arrayspace[7].sprite = weaponsm[1].weaponsP2[3].GetComponent<Image>().sprite;
                        // Place your code here for when the array is full
                    }
                    else
                    {
                        if (p.Money >= 150)
                        {
                            // Execute this if the array is not full
                            Instantiate(bat, Players[play].transform);
                            moneyUpdate(150);
                            // Place your code here for when the array is not full
                        }
                    }

                    break;

                case "knife":

                    if (IsArrayFull(weaponsm[1].weaponsP2))
                    {
                        // Execute this if the array is full
                        Debug.Log("Array is full. Executing action for full array.");
                        weaponchange();

                        chosenweaponToGet2.sprite = weaponImage[9];
                        ChosenWeaponToGetGameObject = knife;
                        arrayspace[4].sprite = weaponsm[1].weaponsP2[0].GetComponent<Image>().sprite;
                        arrayspace[5].sprite = weaponsm[1].weaponsP2[1].GetComponent<Image>().sprite;
                        arrayspace[6].sprite = weaponsm[1].weaponsP2[2].GetComponent<Image>().sprite;
                        arrayspace[7].sprite = weaponsm[1].weaponsP2[3].GetComponent<Image>().sprite;
                        // Place your code here for when the array is full
                    }
                    else
                    {
                        if (p.Money >= 50)
                        {
                            // Execute this if the array is not full
                            Instantiate(knife, Players[play].transform);
                            moneyUpdate(50);
                            // Place your code here for when the array is not full
                        }
                    }


                    break;


            }

        }


    }
    private bool IsArrayFull(Weapons[] array)
    {

            foreach (Weapons obj in array)
            {
                if (obj == null)
                {
                    return false; // If any element is null, array is not full
        
                }
            }
                return true; 
       // All elements are non-null, array is full
    }

    public void weaponchange()
    {
        if (play == 0)
        {
            this.GetComponent<Canvas>().enabled = false;
            weaponchangingP1.SetActive(true);
        }
        if (play == 1)
        {
            this.GetComponent<Canvas>().enabled = false;
            weaponchangingP2.SetActive(true);
        }
    }

    private void moneyUpdate(int cost)
    {
        if(p.playerIndex == 0)
        {
            Players[0].GetComponent<player>().Money -= cost;
            ui[0].UpdateMoney();
        }
        else if (p.playerIndex == 1)
        {
            Players[1].GetComponent<player>().Money -= cost;
            ui[1].UpdateMoney();
        }
    }
}