using UnityEngine;

// An abstract class for all types of weapons
public abstract class Weapon : MonoBehaviour
{
    [SerializeField] string _weaponName;
    [SerializeField] int _damage;

    public string WeaponName { get { return _weaponName; } }
    public int Damage { get { return _damage; } }

    public abstract void Attack();
}