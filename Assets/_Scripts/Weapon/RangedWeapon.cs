using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A class for ranged weapons
public class RangedWeapon : Weapon
{
    public enum FireMode { Single, Burst, Automatic }
    public FireMode fireMode;
    public int ammoCount;

    public override void Attack()
    {
        Debug.Log("U¿yta broñ palna: " + weaponName);
        // code logic of using weapon...
    }
}
