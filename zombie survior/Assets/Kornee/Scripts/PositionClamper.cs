using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionClamper : MonoBehaviour
{
    public int mapWidth;
    public int mapHeight;
    private int negMapWidth;
    private int negMapHeight;
    public bool isWrapping;

    void LateUpdate()
    {
        Vector3 pos = transform.position;

        if (isWrapping)
        {
            // Als we de positieve x-grens van de map bereiken, wrap de positie terug naar negatieve mapWidth 
            if (pos.x > mapWidth)
            {
                pos.x = negMapWidth;
            }
            // Als we de negatieve x-grens van de map bereiken, wrap de positie terug naar positieve mapWidth 
            else if (pos.x < negMapWidth)
            {
                pos.x = mapWidth;
            }

            // Hetzelfde doen we voor y
            if (pos.y > mapHeight)
            {
                pos.y = negMapHeight;
            }
            else if (pos.y < negMapHeight)
            {
                pos.y = mapHeight;
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
