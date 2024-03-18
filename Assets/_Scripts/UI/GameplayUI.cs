using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class GameplayUI : MonoBehaviour
{
    [SerializeField] private List<AssetReference> _weaponIcons;
    private AsyncOperationHandle _currentWeaponIconOperationHandle;

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
        AsyncOperationHandle<Sprite> SpriteHandle = Addressables.LoadAsset<Sprite>(weapon.name + ".png");
        SpriteHandle.Completed += Sprite_Completed;
    }

    private void Sprite_Completed(AsyncOperationHandle<Sprite> handle)
    {
        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            Sprite result = handle.Result;
            _weaponIconImage.sprite = result;
        }
    }
}
