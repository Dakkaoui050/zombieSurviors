using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthbarBehavior : MonoBehaviour
{
    public Slider Slider;
    public Color low;
    public Color high;
 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
        
    }
    public void Sethealth(float HP,float maxHP)
    {
        Slider.gameObject.SetActive(HP < maxHP);
        Slider.value = HP;
        Slider.maxValue = maxHP;
        Slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(low, high, Slider.normalizedValue);
    }
}
