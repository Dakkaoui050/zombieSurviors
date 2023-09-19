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

    public GameObject shopcanvas;
    public GameObject weaponchanging;

    public Image chosenweaponToGet;
    public Sprite[] weaponImage;

    public Image arraySpace1;
    public Image arraySpace2;
    public Image arraySpace3;
    public Image arraySpace4;

    void Start()
    {
        
    }
    private void Awake()
    {
        weapons = GameObject.FindWithTag("Weapons Manager").GetComponent<WeaponsManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ButtonBuy(string type)
    {
        
        switch(type)
        {
            case  "pistol":
                if (IsArrayFull(weapons.weapons))
                {
                    // Execute this if the array is full
                    Debug.Log("Array is full. Executing action for full array.");
                    weaponchange();
                    chosenweaponToGet.sprite = weaponImage[0];
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
        shopcanvas.SetActive(false);
        weaponchanging.SetActive(true);
        
          
    }
}
