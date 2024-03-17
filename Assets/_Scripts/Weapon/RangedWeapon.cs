using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A class for ranged weapons
public class RangedWeapon : Weapon
{
    public enum FireMode { Single, Burst, Automatic } 
    [SerializeField] FireMode _fireMode;  // NOT IMPLEMENTED!
    [SerializeField] int _ammoCount;

    public FireMode Mode { get { return _fireMode; } }
    public int AmmoCount { get { return _ammoCount; } }


    public override void Attack()
    {
        Debug.Log("U¿yta broñ palna: " + WeaponName);
        // code logic of using weapon...
    }
}
