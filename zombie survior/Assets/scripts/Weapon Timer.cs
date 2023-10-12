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

                GameObject temp = weapons.weapons[0].gameObject;
                Destroy(temp);
                weapons.weapons[0] = ChosenWeaponToGetGameObject.GetComponent<Weapons>();
                weaponchanging.SetActive(false);
                Time.timeScale = 1;
                shopManager.UseShop = false;




                break;
            case 2:
                GameObject temp1 = weapons.weapons[1].gameObject;
                Destroy(temp1);
                weapons.weapons[1] = ChosenWeaponToGetGameObject.GetComponent<Weapons>();
                
                weaponchanging.SetActive(false);
                Time.timeScale = 1;
                shopManager.UseShop = false;

                break;
            case 3:
                GameObject temp2 = weapons.weapons[2].gameObject;
                Destroy(temp2);
                weapons.weapons[2] = ChosenWeaponToGetGameObject.GetComponent<Weapons>();
               
                weaponchanging.SetActive(false);
                Time.timeScale = 1;
                shopManager.UseShop = false;

                break;
            case 4:
                GameObject temp3 = weapons.weapons[3].gameObject;
                Destroy(temp3);
                weapons.weapons[3] = ChosenWeaponToGetGameObject.GetComponent<Weapons>();
                
                weaponchanging.SetActive(false);
                Time.timeScale = 1;
                shopManager.UseShop = false;

                break;
        }
    }
}
