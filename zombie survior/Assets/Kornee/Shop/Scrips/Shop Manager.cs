using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ShopManager : MonoBehaviour
{
    [SerializeField] private player Player;
    
    [SerializeField] private GameObject Press;
    [SerializeField] private GameObject Shop;
    public bool UseShop;
    
    // Start is called before the first frame update
    public void Awake()
    {
        Player = GameObject.FindWithTag("Player").GetComponent<player>();
        Press = GameObject.FindWithTag("Press");
        Press.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetButtonDown("Action 6") && UseShop)
        {
            closeShop();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Press.SetActive(true);
            if (Input.GetButtonDown("Action 1") && !UseShop)
            {
                print("test");
                Shop.SetActive(true);
                Press.SetActive(false);
                UseShop = true;
                Time.timeScale = 0;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Press.SetActive(false);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if(Input.GetButtonDown("Action 1")&&  !UseShop)
            {
                print("test");
                Shop.SetActive(true);
                Press.SetActive(false);
                UseShop = true;
                Time.timeScale = 0;
            }
           
        }
    }
   

    private void closeShop()
    {
        Shop.SetActive(false);
        Press.SetActive(true);
        UseShop = false;
        Time.timeScale = 1;
    }
}
