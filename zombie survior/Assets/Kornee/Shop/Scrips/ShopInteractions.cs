using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UIElements;
using UnityEngine.UI;
using TMPro;

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
    public WeaponsManager weapons;

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
    public GameObject ChosenWeaponToGetGameObject;
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
        weapons = GameObject.FindWithTag("Weapons Manager").GetComponent<WeaponsManager>();
        p = GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
       

    }
    public void replaceWeapon(int number)
    {
        if (play == 0)
        { 
            switch(number)
            {
                case 1:
               
                    GameObject temp = weapons.weaponsP1[0].gameObject;
                    Destroy(temp);
                    weapons.weaponsP1[0] = ChosenWeaponToGetGameObject.GetComponent<Weapons>();
                    Instantiate(ChosenWeaponToGetGameObject);
                    weaponchangingP1.SetActive(false);
                    Time.timeScale = 1;
                    shopManager.UseShop = false;
                
                
                

                    break;
                case 2:
                    GameObject temp1 = weapons.weaponsP1[1].gameObject;
                    Destroy(temp1);
                    weapons.weaponsP1[1] = ChosenWeaponToGetGameObject.GetComponent<Weapons>();
                    Instantiate(ChosenWeaponToGetGameObject);
                    weaponchangingP1.SetActive(false);
                    Time.timeScale = 1;
                    shopManager.UseShop = false;

                    break;
                case 3:
                    GameObject temp2 = weapons.weaponsP1[2].gameObject;
                    Destroy(temp2);
                    weapons.weaponsP1[2] = ChosenWeaponToGetGameObject.GetComponent<Weapons>();
                    Instantiate(ChosenWeaponToGetGameObject);
                    weaponchangingP1.SetActive(false);
                    Time.timeScale = 1;
                    shopManager.UseShop = false;

                    break;
                case 4:
                    GameObject temp3 = weapons.weaponsP1[3].gameObject;
                    Destroy(temp3);
                    weapons.weaponsP1[3] = ChosenWeaponToGetGameObject.GetComponent<Weapons>();
                    Instantiate(ChosenWeaponToGetGameObject);
                    weaponchangingP1.SetActive(false);
                    Time.timeScale = 1;
                    shopManager.UseShop = false;

                    break;
            }
        }
        if(play == 1)
        {
            switch (number)
            {
                case 5:

                    GameObject temp = weapons.weaponsP2[0].gameObject;
                    Destroy(temp);
                    weapons.weaponsP2[0] = ChosenWeaponToGetGameObject.GetComponent<Weapons>();
                    Instantiate(ChosenWeaponToGetGameObject);
                    weaponchangingP2.SetActive(false);
                    Time.timeScale = 1;
                    shopManager.UseShop = false;




                    break;
                case 6:
                    GameObject temp1 = weapons.weaponsP2[1].gameObject;
                    Destroy(temp1);
                    weapons.weaponsP2[1] = ChosenWeaponToGetGameObject.GetComponent<Weapons>();
                    Instantiate(ChosenWeaponToGetGameObject);
                    weaponchangingP2.SetActive(false);
                    Time.timeScale = 1;
                    shopManager.UseShop = false;

                    break;
                case 7:
                    GameObject temp2 = weapons.weaponsP2[2].gameObject;
                    Destroy(temp2);
                    weapons.weaponsP2[2] = ChosenWeaponToGetGameObject.GetComponent<Weapons>();
                    Instantiate(ChosenWeaponToGetGameObject);
                    weaponchangingP2.SetActive(false);
                    Time.timeScale = 1;
                    shopManager.UseShop = false;

                    break;
                case 8:
                    GameObject temp3 = weapons.weaponsP2[3].gameObject;
                    Destroy(temp3);
                    weapons.weaponsP2[3] = ChosenWeaponToGetGameObject.GetComponent<Weapons>();
                    Instantiate(ChosenWeaponToGetGameObject);
                    weaponchangingP2.SetActive(false);
                    Time.timeScale = 1;
                    shopManager.UseShop = false;

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
                    if (IsArrayFull(weapons.weaponsP1))
                    {
                        // Execute this if the array is full
                        Debug.Log("Array is full. Executing action for full array.");
                        weaponchange();
                        chosenweaponToGet.sprite = weaponImage[0];
                        ChosenWeaponToGetGameObject = pistol;
                        arrayspace[0].sprite = weapons.weaponsP1[0].GetComponent<Image>().sprite;
                        arrayspace[1].sprite = weapons.weaponsP1[1].GetComponent<Image>().sprite;
                        arrayspace[2].sprite = weapons.weaponsP1[2].GetComponent<Image>().sprite;
                        arrayspace[3].sprite = weapons.weaponsP1[3].GetComponent<Image>().sprite;
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
                    if (IsArrayFull(weapons.weaponsP1))
                    {
                        // Execute this if the array is full
                        Debug.Log("Array is full. Executing action for full array.");
                        weaponchange();
                        chosenweaponToGet.sprite = weaponImage[1];
                        ChosenWeaponToGetGameObject = shotgun;
                        arrayspace[0].sprite = weapons.weaponsP1[0].GetComponent<Image>().sprite;
                        arrayspace[1].sprite = weapons.weaponsP1[1].GetComponent<Image>().sprite;
                        arrayspace[2].sprite = weapons.weaponsP1[2].GetComponent<Image>().sprite;
                        arrayspace[3].sprite = weapons.weaponsP1[3].GetComponent<Image>().sprite;
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

                    if (IsArrayFull(weapons.weaponsP1))
                    {
                        // Execute this if the array is full
                        Debug.Log("Array is full. Executing action for full array.");
                        weaponchange();
                        chosenweaponToGet.sprite = weaponImage[2];
                        ChosenWeaponToGetGameObject = sword;
                        arrayspace[0].sprite = weapons.weaponsP1[0].GetComponent<Image>().sprite;
                        arrayspace[1].sprite = weapons.weaponsP1[1].GetComponent<Image>().sprite;
                        arrayspace[2].sprite = weapons.weaponsP1[2].GetComponent<Image>().sprite;
                        arrayspace[3].sprite = weapons.weaponsP1[3].GetComponent<Image>().sprite;
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

                    if (IsArrayFull(weapons.weaponsP1))
                    {
                        // Execute this if the array is full
                        Debug.Log("Array is full. Executing action for full array.");
                        weaponchange();
                        chosenweaponToGet.sprite = weaponImage[3];
                        ChosenWeaponToGetGameObject = submachineGun;
                        arrayspace[0].sprite = weapons.weaponsP1[0].GetComponent<Image>().sprite;
                        arrayspace[1].sprite = weapons.weaponsP1[1].GetComponent<Image>().sprite;
                        arrayspace[2].sprite = weapons.weaponsP1[2].GetComponent<Image>().sprite;
                        arrayspace[3].sprite = weapons.weaponsP1[3].GetComponent<Image>().sprite;
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

                    if (IsArrayFull(weapons.weaponsP1))
                    {
                        // Execute this if the array is full
                        Debug.Log("Array is full. Executing action for full array.");
                        weaponchange();

                        chosenweaponToGet.sprite = weaponImage[4];
                        ChosenWeaponToGetGameObject = machineGun;
                        arrayspace[0].sprite = weapons.weaponsP1[0].GetComponent<Image>().sprite;
                        arrayspace[1].sprite = weapons.weaponsP1[1].GetComponent<Image>().sprite;
                        arrayspace[2].sprite = weapons.weaponsP1[2].GetComponent<Image>().sprite;
                        arrayspace[3].sprite = weapons.weaponsP1[3].GetComponent<Image>().sprite;
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

                    if (IsArrayFull(weapons.weaponsP1))
                    {
                        // Execute this if the array is full
                        Debug.Log("Array is full. Executing action for full array.");
                        weaponchange();

                        chosenweaponToGet.sprite = weaponImage[5];
                        ChosenWeaponToGetGameObject = Crossbow;
                        arrayspace[0].sprite = weapons.weaponsP1[0].GetComponent<Image>().sprite;
                        arrayspace[1].sprite = weapons.weaponsP1[1].GetComponent<Image>().sprite;
                        arrayspace[2].sprite = weapons.weaponsP1[2].GetComponent<Image>().sprite;
                        arrayspace[3].sprite = weapons.weaponsP1[3].GetComponent<Image>().sprite;
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

                    if (IsArrayFull(weapons.weaponsP1))
                    {
                        // Execute this if the array is full
                        Debug.Log("Array is full. Executing action for full array.");
                        weaponchange();

                        chosenweaponToGet.sprite = weaponImage[6];
                        ChosenWeaponToGetGameObject = Molotov;
                        arrayspace[0].sprite = weapons.weaponsP1[0].GetComponent<Image>().sprite;
                        arrayspace[1].sprite = weapons.weaponsP1[1].GetComponent<Image>().sprite;
                        arrayspace[2].sprite = weapons.weaponsP1[2].GetComponent<Image>().sprite;
                        arrayspace[3].sprite = weapons.weaponsP1[3].GetComponent<Image>().sprite;
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
                    if (IsArrayFull(weapons.weaponsP1))
                    {
                        // Execute this if the array is full
                        Debug.Log("Array is full. Executing action for full array.");
                        weaponchange();

                        chosenweaponToGet.sprite = weaponImage[7];
                        ChosenWeaponToGetGameObject = grenade;
                        arrayspace[0].sprite = weapons.weaponsP1[0].GetComponent<Image>().sprite;
                        arrayspace[1].sprite = weapons.weaponsP1[1].GetComponent<Image>().sprite;
                        arrayspace[2].sprite = weapons.weaponsP1[2].GetComponent<Image>().sprite;
                        arrayspace[3].sprite = weapons.weaponsP1[3].GetComponent<Image>().sprite;
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

                    if (IsArrayFull(weapons.weaponsP1))
                    {
                        // Execute this if the array is full
                        Debug.Log("Array is full. Executing action for full array.");
                        weaponchange();

                        chosenweaponToGet.sprite = weaponImage[8];
                        ChosenWeaponToGetGameObject = bat;
                        arrayspace[0].sprite = weapons.weaponsP1[0].GetComponent<Image>().sprite;
                        arrayspace[1].sprite = weapons.weaponsP1[1].GetComponent<Image>().sprite;
                        arrayspace[2].sprite = weapons.weaponsP1[2].GetComponent<Image>().sprite;
                        arrayspace[3].sprite = weapons.weaponsP1[3].GetComponent<Image>().sprite;
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

                    if (IsArrayFull(weapons.weaponsP1))
                    {
                        // Execute this if the array is full
                        Debug.Log("Array is full. Executing action for full array.");
                        weaponchange();

                        chosenweaponToGet.sprite = weaponImage[9];
                        ChosenWeaponToGetGameObject = knife;
                        arrayspace[0].sprite = weapons.weaponsP1[0].GetComponent<Image>().sprite;
                        arrayspace[1].sprite = weapons.weaponsP1[1].GetComponent<Image>().sprite;
                        arrayspace[2].sprite = weapons.weaponsP1[2].GetComponent<Image>().sprite;
                        arrayspace[3].sprite = weapons.weaponsP1[3].GetComponent<Image>().sprite;
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
                    if (IsArrayFull(weapons.weaponsP2))
                    {
                        // Execute this if the array is full
                        Debug.Log("Array is full. Executing action for full array.");
                        weaponchange();
                        chosenweaponToGet.sprite = weaponImage[0];
                        ChosenWeaponToGetGameObject = pistol;
                        arrayspace[0].sprite = weapons.weaponsP2[0].GetComponent<Image>().sprite;
                        arrayspace[1].sprite = weapons.weaponsP2[1].GetComponent<Image>().sprite;
                        arrayspace[2].sprite = weapons.weaponsP2[2].GetComponent<Image>().sprite;
                        arrayspace[3].sprite = weapons.weaponsP2[3].GetComponent<Image>().sprite;
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
                    if (IsArrayFull(weapons.weaponsP2))
                    {
                        // Execute this if the array is full
                        Debug.Log("Array is full. Executing action for full array.");
                        weaponchange();
                        chosenweaponToGet.sprite = weaponImage[1];
                        ChosenWeaponToGetGameObject = shotgun;
                        arrayspace[0].sprite = weapons.weaponsP2[0].GetComponent<Image>().sprite;
                        arrayspace[1].sprite = weapons.weaponsP2[1].GetComponent<Image>().sprite;
                        arrayspace[2].sprite = weapons.weaponsP2[2].GetComponent<Image>().sprite;
                        arrayspace[3].sprite = weapons.weaponsP2[3].GetComponent<Image>().sprite;
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

                    if (IsArrayFull(weapons.weaponsP2))
                    {
                        // Execute this if the array is full
                        Debug.Log("Array is full. Executing action for full array.");
                        weaponchange();
                        chosenweaponToGet.sprite = weaponImage[2];
                        ChosenWeaponToGetGameObject = sword;
                        arrayspace[0].sprite = weapons.weaponsP2[0].GetComponent<Image>().sprite;
                        arrayspace[1].sprite = weapons.weaponsP2[1].GetComponent<Image>().sprite;
                        arrayspace[2].sprite = weapons.weaponsP2[2].GetComponent<Image>().sprite;
                        arrayspace[3].sprite = weapons.weaponsP2[3].GetComponent<Image>().sprite;
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

                    if (IsArrayFull(weapons.weaponsP2))
                    {
                        // Execute this if the array is full
                        Debug.Log("Array is full. Executing action for full array.");
                        weaponchange();
                        chosenweaponToGet.sprite = weaponImage[3];
                        ChosenWeaponToGetGameObject = submachineGun;
                        arrayspace[0].sprite = weapons.weaponsP2[0].GetComponent<Image>().sprite;
                        arrayspace[1].sprite = weapons.weaponsP2[1].GetComponent<Image>().sprite;
                        arrayspace[2].sprite = weapons.weaponsP2[2].GetComponent<Image>().sprite;
                        arrayspace[3].sprite = weapons.weaponsP2[3].GetComponent<Image>().sprite;
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

                    if (IsArrayFull(weapons.weaponsP2))
                    {
                        // Execute this if the array is full
                        Debug.Log("Array is full. Executing action for full array.");
                        weaponchange();

                        chosenweaponToGet.sprite = weaponImage[4];
                        ChosenWeaponToGetGameObject = machineGun;
                        arrayspace[0].sprite = weapons.weaponsP2[0].GetComponent<Image>().sprite;
                        arrayspace[1].sprite = weapons.weaponsP2[1].GetComponent<Image>().sprite;
                        arrayspace[2].sprite = weapons.weaponsP2[2].GetComponent<Image>().sprite;
                        arrayspace[3].sprite = weapons.weaponsP2[3].GetComponent<Image>().sprite;
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

                    if (IsArrayFull(weapons.weaponsP2))
                    {
                        // Execute this if the array is full
                        Debug.Log("Array is full. Executing action for full array.");
                        weaponchange();

                        chosenweaponToGet.sprite = weaponImage[5];
                        ChosenWeaponToGetGameObject = Crossbow;
                        arrayspace[0].sprite = weapons.weaponsP2[0].GetComponent<Image>().sprite;
                        arrayspace[1].sprite = weapons.weaponsP2[1].GetComponent<Image>().sprite;
                        arrayspace[2].sprite = weapons.weaponsP2[2].GetComponent<Image>().sprite;
                        arrayspace[3].sprite = weapons.weaponsP2[3].GetComponent<Image>().sprite;
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

                    if (IsArrayFull(weapons.weaponsP2))
                    {
                        // Execute this if the array is full
                        Debug.Log("Array is full. Executing action for full array.");
                        weaponchange();

                        chosenweaponToGet.sprite = weaponImage[6];
                        ChosenWeaponToGetGameObject = Molotov;
                        arrayspace[0].sprite = weapons.weaponsP2[0].GetComponent<Image>().sprite;
                        arrayspace[1].sprite = weapons.weaponsP2[1].GetComponent<Image>().sprite;
                        arrayspace[2].sprite = weapons.weaponsP2[2].GetComponent<Image>().sprite;
                        arrayspace[3].sprite = weapons.weaponsP2[3].GetComponent<Image>().sprite;
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
                    if (IsArrayFull(weapons.weaponsP2))
                    {
                        // Execute this if the array is full
                        Debug.Log("Array is full. Executing action for full array.");
                        weaponchange();

                        chosenweaponToGet.sprite = weaponImage[7];
                        ChosenWeaponToGetGameObject = grenade;
                        arrayspace[0].sprite = weapons.weaponsP2[0].GetComponent<Image>().sprite;
                        arrayspace[1].sprite = weapons.weaponsP2[1].GetComponent<Image>().sprite;
                        arrayspace[2].sprite = weapons.weaponsP2[2].GetComponent<Image>().sprite;
                        arrayspace[3].sprite = weapons.weaponsP2[3].GetComponent<Image>().sprite;
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

                    if (IsArrayFull(weapons.weaponsP2))
                    {
                        // Execute this if the array is full
                        Debug.Log("Array is full. Executing action for full array.");
                        weaponchange();

                        chosenweaponToGet.sprite = weaponImage[8];
                        ChosenWeaponToGetGameObject = bat;
                        arrayspace[0].sprite = weapons.weaponsP2[0].GetComponent<Image>().sprite;
                        arrayspace[1].sprite = weapons.weaponsP2[1].GetComponent<Image>().sprite;
                        arrayspace[2].sprite = weapons.weaponsP2[2].GetComponent<Image>().sprite;
                        arrayspace[3].sprite = weapons.weaponsP2[3].GetComponent<Image>().sprite;
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

                    if (IsArrayFull(weapons.weaponsP2))
                    {
                        // Execute this if the array is full
                        Debug.Log("Array is full. Executing action for full array.");
                        weaponchange();

                        chosenweaponToGet.sprite = weaponImage[9];
                        ChosenWeaponToGetGameObject = knife;
                        arrayspace[0].sprite = weapons.weaponsP2[0].GetComponent<Image>().sprite;
                        arrayspace[1].sprite = weapons.weaponsP2[1].GetComponent<Image>().sprite;
                        arrayspace[2].sprite = weapons.weaponsP2[2].GetComponent<Image>().sprite;
                        arrayspace[3].sprite = weapons.weaponsP2[3].GetComponent<Image>().sprite;
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
        //if(p.playerIndex == 0)
        //{
           shopManager.closeShop();
           weaponchangingP1.SetActive(true);
        //}
        //if (p.playerIndex == 1)
        //{
        //    shopManager.closeShop();
        //    weaponchangingP2.SetActive(true);
        //}
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