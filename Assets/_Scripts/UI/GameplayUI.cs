using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayUI : MonoBehaviour
{
    [Header("WEAPON POPUP")]
    [SerializeField] Text _weaponNameText;
    [SerializeField] Image _weaponIconImage;


    private void OnEnable()
    {
        EventManager.OnUpdateWeapon += OnUpdateWeapon;
    }


    private void OnDisable()
    {
        EventManager.OnUpdateWeapon -= OnUpdateWeapon;
    }

    void OnUpdateWeapon(Weapon weapon)
    {
        _weaponNameText.text = weapon.WeaponName;
        //_weaponIconImage.
    }
}
