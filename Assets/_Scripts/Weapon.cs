using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// An abstract class for all types of weapons
public abstract class Weapon : MonoBehaviour
{
    public string weaponName;
    public int damage;

    public abstract void Attack();
}


// A class for melee weapons
public class MeleeWeapon : Weapon
{
    public enum MeleeType { Pointed, Edged, Blunt }
    public MeleeType meleeType;
    public float attackRange;

    public override void Attack()
    {
        Debug.Log("U¿yta broñ bia³a: " + weaponName);
    }
}

// A class for ranged weapons
public class RangedWeapon : Weapon
{
    public enum FireMode { Single, Burst, Automatic }
    public FireMode fireMode;
    public int ammoCount;

    public override void Attack()
    {
        Debug.Log("U¿yta broñ palna: " + weaponName);
    }
}
