using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ShopManager : MonoBehaviour
{
    [SerializeField] private player[] Player;
    
    [SerializeField] private GameObject[] Press;
    [SerializeField] private GameObject Shop;
    public bool UseShop;
    
    // Start is called before the first frame update
    public void Awake()
    {
        foreach (GameObject item in Press)
        {
            item.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetButton("Action 6") && UseShop)
        {
            closeShop();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            foreach (GameObject item in Press)
            {   
                item.SetActive(true);
            } 
            if (Input.GetButton("Action 1") && !UseShop)
            {
                print("test");
                Shop.SetActive(true);
                foreach (GameObject item in Press)
                {
                    item.SetActive(false);
                }
                UseShop = true;
                Time.timeScale = 0;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            foreach (GameObject item in Press)
            {
                item.SetActive(false);
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if(Input.GetButton("Action 1")&&  !UseShop)
            {
                print("test");
                Shop.SetActive(true);
                foreach (GameObject item in Press)
                {
                    item.SetActive(false);
                }
                UseShop = true;
                Time.timeScale = 0;
            }
           
        }
    }
   

    public void closeShop()
    {
        Shop.SetActive(false);
        foreach (GameObject item in Press)
        {
            item.SetActive(false);
        }
        UseShop = false;
        Time.timeScale = 1;
    }
}
