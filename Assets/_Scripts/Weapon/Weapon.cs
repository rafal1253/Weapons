using UnityEngine;

// An abstract class for all types of weapons
public abstract class Weapon : MonoBehaviour
{
    public string weaponName;
    public int damage;

    public abstract void Attack();
}