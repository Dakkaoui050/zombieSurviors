using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ShopManager : MonoBehaviour
{
    [SerializeField] private player Player;
    [SerializeField] private int LocalMoney;
    [SerializeField] private GameObject Press;
    [SerializeField] private Canvas Shop;
    [SerializeField] private bool UseShop;
    
    // Start is called before the first frame update
    public void Awake()
    {
        Player = GameObject.FindWithTag("Player").GetComponent<player>();
        Press = GameObject.FindWithTag("Press");
        Shop = GameObject.FindWithTag("Shop").GetComponent<Canvas>();
        Press.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        LocalMoney = Player.Money;
        if (Input.GetKey(KeyCode.Escape) && UseShop)
        {
            closeShop();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Press.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Press.SetActive(false);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if(Input.GetKey(KeyCode.E)&&  !UseShop)
            {
                Time.timeScale = 0;
                Shop.enabled = true;
                Press.SetActive(false);
                UseShop = true;
            }
           
        }
    }
   

    private void closeShop()
    {
        Shop.enabled = false;
        Press.SetActive(true);
        Time.timeScale = 1;
        UseShop = false;
    }
}
