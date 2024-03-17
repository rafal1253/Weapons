using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A class for melee weapons
public class MeleeWeapon : Weapon
{
    public enum MeleeType { Pointed, Edged, Blunt }
    [SerializeField] MeleeType _meleeType;
    [SerializeField] float _attackRange;

    public MeleeType Type { get { return _meleeType; } }
    public float AttackRange { get { return _attackRange; } }

    public override void Attack()
    {
        Debug.Log("U¿yta broñ bia³a: " + WeaponName);
        // code logic of using weapon...       
    }
}

