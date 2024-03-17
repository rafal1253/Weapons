using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float _speed = 15f;
    [SerializeField] Camera _camera;
    float _xRotation = 0f;


    private Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Move();
        RotateX();
        RotateY();
    }


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
}
