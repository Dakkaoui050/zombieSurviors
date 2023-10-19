using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionClamper : MonoBehaviour
{
    public int mapWidth;
    public int mapHeight;
    public int negMapWidth;
    public int negMapHeight;
    public bool isWrapping;
    public player p;
    void LateUpdate()
    {
        Vector3 pos = transform.position;
        Vector3 enps;
        Vector3 pups;

        if(!p.player2)
        {

            if (isWrapping)
            {
                // Als we de positieve x-grens van de map bereiken, wrap de positie terug naar negatieve mapWidth 
                if (pos.x > mapWidth)
                {
                    pos.x = negMapWidth;
                    foreach(GameObject enemy in p.Zombies)
                    {
                        enps = enemy.transform.position;
                        enps.x += negMapWidth + negMapWidth;
                        enemy.transform.position = enps;
                    
                    }
                    foreach(GameObject pick in p.PickUps)
                    {
                        pups = pick.transform.position;
                        pups.x += negMapWidth + negMapWidth;
                        pick.transform.position = pups;

                    }
                }
                // Als we de negatieve x-grens van de map bereiken, wrap de positie terug naar positieve mapWidth 
                else if (pos.x < negMapWidth)
                {
                    pos.x = mapWidth;
                    foreach (GameObject enemy in p.Zombies)
                    {
                        enps = enemy.transform.position;
                        enps.x += mapWidth + mapWidth;
                        enemy.transform.position = enps;

                    }
                    foreach (GameObject pick in p.PickUps)
                    {
                        pups = pick.transform.position;
                        pups.x += mapWidth + mapWidth;
                        pick.transform.position = pups;

                    }
                }

                // Hetzelfde doen we voor y
                if (pos.y > mapHeight)
                {
                    pos.y = negMapHeight;
                    foreach (GameObject enemy in p.Zombies)
                    {
                        enps = enemy.transform.position;
                        enps.y += negMapHeight +negMapHeight;
                        enemy.transform.position = enps;

                    }
                    foreach (GameObject pick in p.PickUps)
                    {
                        pups = pick.transform.position;
                        pups.y += negMapHeight + negMapHeight;
                        pick.transform.position = pups;

                    }
                }
                else if (pos.y < negMapHeight)
                {
                    pos.y = mapHeight;
                    foreach(GameObject enemy in p.Zombies)
                    {
                        enps = enemy.transform.position;
                        enps.y += mapHeight + mapHeight;
                        enemy.transform.position = enps;

                    }
                    foreach (GameObject pick in p.PickUps)
                    {
                        pups = pick.transform.position;
                        pups.y += mapHeight + mapHeight;
                        pick.transform.position = pups;

                    }
                }
            }
            else
            {
                // clamp de positie binnen de grenzen van de map, rekening houdend met negatieve mapHeight en mapWidth
                pos.x = Mathf.Clamp(pos.x, negMapWidth, 0);
                pos.y = Mathf.Clamp(pos.y, negMapHeight, 0);
            }

            // Stel de transformatiepositie in.
            transform.position = pos;
        }
    }
}
