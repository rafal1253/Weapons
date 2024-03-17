using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A class for melee weapons
public class MeleeWeapon : Weapon
{
    public enum MeleeType { Pointed, Edged, Blunt }
    public MeleeType meleeType;
    public float attackRange;

    public override void Attack()
    {
        Debug.Log("U¿yta broñ bia³a: " + weaponName);
        // code logic of using weapon...
    }
}

