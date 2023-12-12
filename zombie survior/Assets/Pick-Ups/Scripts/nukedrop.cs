using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
public class nukedrop : MonoBehaviour
{
   
    public player p;
    public int Nuke_count;
    public bool Nuke;
    [SerializeField] private spawnscript spawnscript;
    public List<GameObject> Waves = new List<GameObject>();




    private void FixedUpdate()
    {
        if (Nuke_count > 0)
        {
            Nuke = true;
        }
        else
        {
            Nuke = false;
        }

        foreach (var w in Waves)
        {
            if(w == null)
            {
                Waves.Remove(w);
            }
        }
    }
    public void action()
    {
        if (Nuke)
        {
            Nuke_count--;
            foreach(GameObject Wave in Waves)
            {
               Wave.GetComponent<WaveManegar>().Nuke_Drop();
            }
        }
    }

}
