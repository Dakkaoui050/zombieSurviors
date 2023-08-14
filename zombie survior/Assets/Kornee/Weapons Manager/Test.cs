using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject prefab;
    public WeaponsManager weapons;

    private void Awake()
    {
        weapons = GameObject.FindWithTag("Weapons Manager").GetComponent<WeaponsManager>();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            if (IsArrayFull(weapons.weapons))
            {
                // Execute this if the array is full
                Debug.Log("Array is full. Executing action for full array.");
                // Place your code here for when the array is full
            }
            else
            {
                // Execute this if the array is not full
                Instantiate(prefab);
                // Place your code here for when the array is not full
            }
        }
    }

    private bool IsArrayFull(Weapons[] array)
    {
        foreach (Weapons obj in array)
        {
            if (obj == null)
            {
                return false; // If any element is null, array is not full
            }
        }
        return true; // All elements are non-null, array is full
    }
}
