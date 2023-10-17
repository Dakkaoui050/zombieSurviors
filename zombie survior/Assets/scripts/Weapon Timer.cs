using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTimer : ShopInteractions
{

    public GameObject weapon1;
    public GameObject weapon2;
    public GameObject weapon3;
    public GameObject weapon4;
    public int number;
   

    
    void Update()
    {
        switch (number)
        {
            case 1:

                GameObject temp = weapons.weaponsP1[0].gameObject;
                Destroy(temp);
                weapons.weaponsP1[0] = ChosenWeaponToGetGameObject.GetComponent<Weapons>();
                weaponchangingP1.SetActive(false);
                Time.timeScale = 1;
                shopManager.UseShop = false;




                break;
            case 2:
                GameObject temp1 = weapons.weaponsP1[1].gameObject;
                Destroy(temp1);
                weapons.weaponsP1[1] = ChosenWeaponToGetGameObject.GetComponent<Weapons>();
                
                weaponchangingP1.SetActive(false);
                Time.timeScale = 1;
                shopManager.UseShop = false;

                break;
            case 3:
                GameObject temp2 = weapons.weaponsP1[2].gameObject;
                Destroy(temp2);
                weapons.weaponsP1[2] = ChosenWeaponToGetGameObject.GetComponent<Weapons>();
               
                weaponchangingP1.SetActive(false);
                Time.timeScale = 1;
                shopManager.UseShop = false;

                break;
            case 4:
                GameObject temp3 = weapons.weaponsP1[3].gameObject;
                Destroy(temp3);
                weapons.weaponsP1[3] = ChosenWeaponToGetGameObject.GetComponent<Weapons>();
                
                weaponchangingP1.SetActive(false);
                Time.timeScale = 1;
                shopManager.UseShop = false;

                break;
        }
    }
}
