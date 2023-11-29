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
    public string Tag;
    public CircleCollider2D circleCollider;
    public GameObject me;
    public nukedrop nuke;

    public player player_script;
    public void OnTriggerEnter2D(Collider2D collision)
    {
       pickUp(collision);
    }
    public void pickUp(Collider2D collision )
    {
        if (collision.tag == "Player")
        {
            player_script = collision.gameObject.GetComponent<player>();
            switch (Tag)
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
                case "Defence":
                    player_script.defence += valuePlus;
                    destroy();
                    break;
                case "Nuke":
                    if (nuke.Nuke == false && nuke.Nuke_count  < 3)
                    {
                        nuke.Nuke = true;
                        nuke.Nuke_count++;
                        destroy();
                    }
                    else if (nuke.Nuke_count < 3)
                    {
                        nuke.Nuke_count++;
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
        player_script.PickUps.Remove(this.gameObject);
        Destroy(gameObject);

    }


}
