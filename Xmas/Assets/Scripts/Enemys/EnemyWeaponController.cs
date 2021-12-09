using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponController : MonoBehaviour
{
    // Start is called before the first frame update
    Transform[] weapons;
    Animator animator;

    public int weaponIndex;

    string weaponName;
    void Start()
    {
        animator = GetComponentInParent<Animator>();
        weapons = GetComponentsInChildren<Transform>();
        
        switch(weaponIndex)
        {
            case 2:
                weaponName = "Bottle";
                break;
            case 3:
                weaponName = "shovel0";
                break;
            default:
                weaponName = "Knife";
                break;

        }


        foreach (Transform t in weapons)
        {
            if(t.name != weaponName)
                t.gameObject.SetActive(false);
            
        }
    }

}
