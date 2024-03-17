using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float _speed = 15f;
    [SerializeField] Camera _camera;
    float _xRotation = 0f;

    [Header("Equipment")]
    [SerializeField] List<Weapon> _equippedWeapons;
    [SerializeField] Transform _weaponsHolder;
    private Weapon _activeWeapon;


    private Rigidbody _rb;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        LoadStartingEquipment();
    }

    private void Update()
    {
        UseWeapon();
        NextWeapon();
    }

    void FixedUpdate()
    {
        Move();
        RotateX();
        RotateY();
    }

    #region MotionControlHandling
    private void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal") * Time.deltaTime;
        float moveVertical = Input.GetAxis("Vertical") * Time.deltaTime;

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        movement = transform.TransformDirection(movement);
        movement *= _speed;

        _rb.AddForce(movement,ForceMode.VelocityChange);
    }
    private void RotateX()
    {
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime;
        transform.Rotate(Vector3.up * mouseX * Settings.Instance.MouseSensitivity);
    }
    private void RotateY()
    {
        float mouseY = Input.GetAxis("Mouse Y") * Settings.Instance.MouseSensitivity * Time.deltaTime;

        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        _camera.transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
    }
    #endregion

    #region WeaponHandling
    private void LoadStartingEquipment()
    {
        if (_equippedWeapons.Count > 0)
        {
            foreach (var item in _equippedWeapons)
            {
                Instantiate(item, _weaponsHolder);
            }
            ChangeWeaponTo(0);
        }
        else
            Debug.Log("BRAK BRONI W EKWIPUNKU " +
                "- Dodaj bronie z folderu '_Prefabs -> Weapons' do listy '_equippedWeapons' skryptu 'Player.cs' dla obiektu 'FirstPersonPlayer' w hierarchi sceny.");  
    }

    private void NextWeapon()
    {
        if (Input.GetButtonDown("Fire2") && _activeWeapon != null)
        {
            int currentWeaponIndex = _equippedWeapons.IndexOf(_activeWeapon);
            int newWeaponIndex = currentWeaponIndex + 1 == _equippedWeapons.Count ? 0 : currentWeaponIndex + 1;


            ChangeWeaponTo(newWeaponIndex);
        }
            
    }

    private void UseWeapon()
    {
        if (Input.GetButtonDown("Fire1") && _activeWeapon != null)
            _activeWeapon.Attack();
    }

    private void ChangeWeaponTo(int index)
    {
        _activeWeapon = _equippedWeapons[index];

        int i = 0;
        foreach (Transform weapon in _weaponsHolder)
        {
            weapon.gameObject.SetActive(i == _equippedWeapons.IndexOf(_activeWeapon));
            i++;
        }

        EventManager.InvokeOnUpdateWeapon(_activeWeapon);
    }
 
    #endregion
}
