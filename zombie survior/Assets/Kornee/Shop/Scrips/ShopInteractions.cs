using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UIElements;
using UnityEngine.UI;

public class ShopInteractions : MonoBehaviour
{
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



    public Canvas shopcanvas;
    public GameObject weaponchanging;

    public Image chosenweaponToGet;
    public GameObject ChosenWeaponToGetGameObject;
    public Sprite[] weaponImage;
    public ShopManager shopManager;

    //public Image arraySpace1;
    //public Image arraySpace2;
    //public Image arraySpace3;
    //public Image arraySpace4;

    public Image[] arrayspace;

    void Start()
    {
    }
    private void Awake()
    {
        //pistolImg = GameObject.Find("Pistol").GetComponent<Image>();
        //shotgunImg = GameObject.Find("Shotgun").GetComponent<Image>();
        //swordImg = GameObject.Find("Sword").GetComponent<Image>();
        //submachineGunImg = GameObject.Find("SubmachineGun").GetComponent<Image>();
        //machineGunImg = GameObject.Find("MachineGun").GetComponent<Image>();
        //CrossbowImg = GameObject.Find("CrossBow").GetComponent<Image>();
        //MolotovImg = GameObject.Find("Molotov").GetComponent<Image>();
        //GrenadeImg = GameObject.Find("Grenade").GetComponent<Image>();
        //batImg = GameObject.Find("Bat").GetComponent<Image>();
        //knifeImg = GameObject.Find("Knife").GetComponent<Image>();
        shopManager = GameObject.FindWithTag("Shopt").GetComponent<ShopManager>();
        weapons = GameObject.FindWithTag("Weapons Manager").GetComponent<WeaponsManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void replaceWeapon(int number)
    {
        switch(number)
        {
            case 1:
                GameObject temp = weapons.weapons[0].gameObject;
                Destroy(temp);
                weapons.weapons[0] = ChosenWeaponToGetGameObject.GetComponent<Weapons>();
                Instantiate(ChosenWeaponToGetGameObject);
                weaponchanging.SetActive(false);
                Time.timeScale = 1;
                shopManager.UseShop = false;
                

                break;
            case 2:
                GameObject temp1 = weapons.weapons[1].gameObject;
                Destroy(temp1);
                weapons.weapons[1] = ChosenWeaponToGetGameObject.GetComponent<Weapons>();
                Instantiate(ChosenWeaponToGetGameObject);
                weaponchanging.SetActive(false);
                Time.timeScale = 1;
                shopManager.UseShop = false;

                break;
            case 3:
                GameObject temp2 = weapons.weapons[2].gameObject;
                Destroy(temp2);
                weapons.weapons[2] = ChosenWeaponToGetGameObject.GetComponent<Weapons>();
                Instantiate(ChosenWeaponToGetGameObject);
                weaponchanging.SetActive(false);
                Time.timeScale = 1;
                shopManager.UseShop = false;

                break;
            case 4:
                GameObject temp3 = weapons.weapons[3].gameObject;
                Destroy(temp3);
                weapons.weapons[3] = ChosenWeaponToGetGameObject.GetComponent<Weapons>();
                Instantiate(ChosenWeaponToGetGameObject);
                weaponchanging.SetActive(false);
                Time.timeScale = 1;
                shopManager.UseShop = false;

                break;
        }
    }
    public void ButtonBuy(string type)
    {
        
        switch (type)
        {
            case  "pistol":
                if (IsArrayFull(weapons.weapons))
                {
                    // Execute this if the array is full
                    Debug.Log("Array is full. Executing action for full array.");
                    weaponchange();
                    chosenweaponToGet.sprite = weaponImage[0];
                    ChosenWeaponToGetGameObject = pistol;
                    arrayspace[0].sprite = weapons.weapons[0].GetComponent<Image>().sprite;
                    arrayspace[1].sprite = weapons.weapons[1].GetComponent<Image>().sprite;
                    arrayspace[2].sprite = weapons.weapons[2].GetComponent<Image>().sprite;
                    arrayspace[3].sprite = weapons.weapons[3].GetComponent<Image>().sprite;



                    // Place your code here for when the array is full
                }
                else
                {
                    // Execute this if the array is not full
                    Instantiate(pistol, player);
                    // Place your code here for when the array is not full
                }

                break;

            case "shotgun":
                if (IsArrayFull(weapons.weapons))
                {
                    // Execute this if the array is full
                    Debug.Log("Array is full. Executing action for full array.");
                    weaponchange();
                    chosenweaponToGet.sprite = weaponImage[1];
                    ChosenWeaponToGetGameObject = shotgun;
                    arrayspace[0].sprite = weapons.weapons[0].GetComponent<Image>().sprite;
                    arrayspace[1].sprite = weapons.weapons[1].GetComponent<Image>().sprite;
                    arrayspace[2].sprite = weapons.weapons[2].GetComponent<Image>().sprite;
                    arrayspace[3].sprite = weapons.weapons[3].GetComponent<Image>().sprite;
                    // Place your code here for when the array is full
                }
                else
                {
                    // Execute this if the array is not full
                    Instantiate(shotgun, player);
                    // Place your code here for when the array is not full
                }

                break;

            case "sword":

                if (IsArrayFull(weapons.weapons))
                {
                    // Execute this if the array is full
                    Debug.Log("Array is full. Executing action for full array.");
                    weaponchange();
                    chosenweaponToGet.sprite = weaponImage[2];
                    ChosenWeaponToGetGameObject = sword;
                    arrayspace[0].sprite = weapons.weapons[0].GetComponent<Image>().sprite;
                    arrayspace[1].sprite = weapons.weapons[1].GetComponent<Image>().sprite;
                    arrayspace[2].sprite = weapons.weapons[2].GetComponent<Image>().sprite;
                    arrayspace[3].sprite = weapons.weapons[3].GetComponent<Image>().sprite;
                    // Place your code here for when the array is full
                }
                else
                {
                    // Execute this if the array is not full
                    Instantiate(sword, player);
                    // Place your code here for when the array is not full
                }

                break;

            case "submachine gun":

                if (IsArrayFull(weapons.weapons))
                {
                    // Execute this if the array is full
                    Debug.Log("Array is full. Executing action for full array.");
                    weaponchange();
                    chosenweaponToGet.sprite = weaponImage[3];
                    ChosenWeaponToGetGameObject = submachineGun;
                    arrayspace[0].sprite = weapons.weapons[0].GetComponent<Image>().sprite;
                    arrayspace[1].sprite = weapons.weapons[1].GetComponent<Image>().sprite;
                    arrayspace[2].sprite = weapons.weapons[2].GetComponent<Image>().sprite;
                    arrayspace[3].sprite = weapons.weapons[3].GetComponent<Image>().sprite;
                    // Place your code here for when the array is full
                }
                else
                {
                    // Execute this if the array is not full

                    Instantiate(submachineGun, player);
                    // Place your code here for when the array is not full
                }

                break;

            case "machine gun":

                if (IsArrayFull(weapons.weapons))
                {
                    // Execute this if the array is full
                    Debug.Log("Array is full. Executing action for full array.");
                    weaponchange();

                    chosenweaponToGet.sprite = weaponImage[4];
                    ChosenWeaponToGetGameObject = machineGun;
                    arrayspace[0].sprite = weapons.weapons[0].GetComponent<Image>().sprite;
                    arrayspace[1].sprite = weapons.weapons[1].GetComponent<Image>().sprite;
                    arrayspace[2].sprite = weapons.weapons[2].GetComponent<Image>().sprite;
                    arrayspace[3].sprite = weapons.weapons[3].GetComponent<Image>().sprite;
                    // Place your code here for when the array is full
                }
                else
                {
                    // Execute this if the array is not full
                    Instantiate(machineGun, player);
                    // Place your code here for when the array is not full
                }

                break;

            case "crossbow":

                if (IsArrayFull(weapons.weapons))
                {
                    // Execute this if the array is full
                    Debug.Log("Array is full. Executing action for full array.");
                    weaponchange();

                    chosenweaponToGet.sprite = weaponImage[5];
                    ChosenWeaponToGetGameObject = Crossbow;
                    arrayspace[0].sprite = weapons.weapons[0].GetComponent<Image>().sprite;
                    arrayspace[1].sprite = weapons.weapons[1].GetComponent<Image>().sprite;
                    arrayspace[2].sprite = weapons.weapons[2].GetComponent<Image>().sprite;
                    arrayspace[3].sprite = weapons.weapons[3].GetComponent<Image>().sprite;
                    // Place your code here for when the array is full
                }
                else
                {
                    // Execute this if the array is not full
                    Instantiate(Crossbow, player);
                    // Place your code here for when the array is not full
                }

                break;

            case "molotov":

                if (IsArrayFull(weapons.weapons))
                {
                    // Execute this if the array is full
                    Debug.Log("Array is full. Executing action for full array.");
                    weaponchange();

                    chosenweaponToGet.sprite = weaponImage[6];
                    ChosenWeaponToGetGameObject = Molotov;
                    arrayspace[0].sprite = weapons.weapons[0].GetComponent<Image>().sprite;
                    arrayspace[1].sprite = weapons.weapons[1].GetComponent<Image>().sprite;
                    arrayspace[2].sprite = weapons.weapons[2].GetComponent<Image>().sprite;
                    arrayspace[3].sprite = weapons.weapons[3].GetComponent<Image>().sprite;
                    // Place your code here for when the array is full
                }
                else
                {
                    // Execute this if the array is not full
                    Instantiate(Molotov, player);
                    // Place your code here for when the array is not full
                }

                break;

            case "grenade":
                if (IsArrayFull(weapons.weapons))
                {
                    // Execute this if the array is full
                    Debug.Log("Array is full. Executing action for full array.");
                    weaponchange();

                    chosenweaponToGet.sprite = weaponImage[7];
                    ChosenWeaponToGetGameObject = grenade;
                    arrayspace[0].sprite = weapons.weapons[0].GetComponent<Image>().sprite;
                    arrayspace[1].sprite = weapons.weapons[1].GetComponent<Image>().sprite;
                    arrayspace[2].sprite = weapons.weapons[2].GetComponent<Image>().sprite;
                    arrayspace[3].sprite = weapons.weapons[3].GetComponent<Image>().sprite;
                    // Place your code here for when the array is full
                }
                else
                {
                    // Execute this if the array is not full
                    Instantiate(grenade, player);
                    // Place your code here for when the array is not full
                }

                break;

            case "bat":

                if (IsArrayFull(weapons.weapons))
                {
                    // Execute this if the array is full
                    Debug.Log("Array is full. Executing action for full array.");
                    weaponchange();

                    chosenweaponToGet.sprite = weaponImage[8];
                    ChosenWeaponToGetGameObject = bat;
                    arrayspace[0].sprite = weapons.weapons[0].GetComponent<Image>().sprite;
                    arrayspace[1].sprite = weapons.weapons[1].GetComponent<Image>().sprite;
                    arrayspace[2].sprite = weapons.weapons[2].GetComponent<Image>().sprite;
                    arrayspace[3].sprite = weapons.weapons[3].GetComponent<Image>().sprite;
                    // Place your code here for when the array is full
                }
                else
                {
                    // Execute this if the array is not full
                    Instantiate(bat, player);
                    // Place your code here for when the array is not full
                }

                break;

            case "knife":

                if (IsArrayFull(weapons.weapons))
                {
                    // Execute this if the array is full
                    Debug.Log("Array is full. Executing action for full array.");
                    weaponchange();

                    chosenweaponToGet.sprite = weaponImage[9];
                    ChosenWeaponToGetGameObject = knife;
                    arrayspace[0].sprite = weapons.weapons[0].GetComponent<Image>().sprite;
                    arrayspace[1].sprite = weapons.weapons[1].GetComponent<Image>().sprite;
                    arrayspace[2].sprite = weapons.weapons[2].GetComponent<Image>().sprite;
                    arrayspace[3].sprite = weapons.weapons[3].GetComponent<Image>().sprite;
                    // Place your code here for when the array is full
                }
                else
                {
                    // Execute this if the array is not full
                    Instantiate(knife, player);
                    // Place your code here for when the array is not full
                }


                break;


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
        return true; // All elements are non-null, array is full
    }

    private void weaponchange()
    {
        shopcanvas.enabled = false;
        weaponchanging.SetActive(true);

          
    }

    private void test()
    {
        //fotos van de wapens die in je inv zitten komen op de 4 plekken 
        for (int i = 0; i < weaponImage.Length; i++)
        {

           if(arrayspace[0])
           {
               
           }
        }
    }
}
