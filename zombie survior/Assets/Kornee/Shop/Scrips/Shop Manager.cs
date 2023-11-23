using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ShopManager : MonoBehaviour
{
    
    [SerializeField] private player Player;
    
    [SerializeField] private GameObject[] Press;
    [SerializeField] private GameObject Shop;
    public bool UseShop;
    public Collider2D collision1;
    
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
        if (collision1 != null)
        {

            if (collision1.gameObject.tag == "Player")
            {
                Player = collision1.gameObject.GetComponent<player>();
                if (Player.playerIndex == 0)
                {
                    if (Input.GetButtonDown("Action 1") && !UseShop)
                    {
                        Shop.GetComponent<Canvas>().enabled = true;
                        Shop.GetComponent<ShopInteractions>().play = 0;
                        Press[0].SetActive(true);
                        UseShop = true;
                        Time.timeScale = 0;
                    }

                }
                else if (Player.playerIndex == 1)
                {
                    if (Input.GetButtonDown("Fire1") && !UseShop)
                    {
                        Shop.GetComponent<Canvas>().enabled = true;
                        Shop.GetComponent<ShopInteractions>().play = 1;
                        Press[0].SetActive(true);
                        UseShop = true;
                        Time.timeScale = 0;
                    }

                }
            }
        }

        if (Player.playerIndex == 0)
        {
            if (Input.GetButton("Action 6") && UseShop)
            {
                closeShop();
            }

        }
        else if (Player.playerIndex == 1)
        {
            if (Input.GetButton("Fire5") && UseShop)
            {
                closeShop();
            }
        }
        
    }
    private void FixedUpdate()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player = other.gameObject.GetComponent<player>();
            foreach (GameObject item in Press)
            {
                item.SetActive(true);
                collision1 = other;
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
                collision1 = null;
            }
        }
    }

   

    public void closeShop()
    {
        Shop.GetComponent<Canvas>().enabled = false;
        foreach (GameObject item in Press)
        {
            item.SetActive(false);
        }
        UseShop = false;
        Time.timeScale = 1;
    }
}
