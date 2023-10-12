using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_DefenceZombie : Enemy
{
    public int Defence;

    public void Start()
    {
        Defence = Random.Range(1, 20);
        print(Defence);
        HP = HP - (Damage / Defence);

    }


}
