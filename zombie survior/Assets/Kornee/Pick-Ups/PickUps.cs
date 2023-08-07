using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Threading;

public class PickUps : MonoBehaviour
{
    [Header("Commen settings")]
    public Sprite sprite;
    [Header("Pickup Specific")]
    public int valuePlus;
    public bool grabed;
    public string tag;
    public CircleCollider2D circleCollider;
    public GameObject me;

    public player player_script;
    public void OnTriggerEnter2D(Collider2D collision)
    {
       player_script = collision.GetComponent<player_Kale_Man>();
        if (collision.tag == "Player")
        {
            switch(tag)
            {
                case "Health":
                    player_script.HP += valuePlus;
                    if (player_script.HP > player_script.MaxHP)
                    {
                        player_script.HP = player_script.MaxHP;
                        destroy();
                    }
                    else
                    {
                        destroy();
                    }
                    
                    break;
                case "Defense":
                    player_script.defence += valuePlus;
                    destroy();
                    break;
                case "Nuke":
                    if (player_script.Nuke == false && player_script.Nuke_Count < 3)
                    {
                        player_script.Nuke = true;
                        player_script.Nuke_Count++;
                        destroy();
                    }
                    else if (player_script.Nuke_Count < 3)
                    {
                        player_script.Nuke_Count++;
                        destroy();
                    }
                    else
                    {
                        destroy();
                    }
                    break; 
                case "Money":
                    player_script.Money += valuePlus;
                    destroy();
                    break;
            }
            
           
        }
    }
       
    public void destroy()
    {
        GameObject.Destroy(me);

    }
}
