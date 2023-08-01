using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTree : MonoBehaviour
{
    private XP_points Xp;
    public GameObject[] heathIncease;
    public GameObject[] Dash;
    public GameObject[] defenceIncease;
    public GameObject[] MovementSpeed;
    public GameObject relive;

    private void Awake()
    {
        Xp = GetComponent<XP_points>();
    }

}
