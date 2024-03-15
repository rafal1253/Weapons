using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    [SerializeField] float _mouseSensitivity = 350f;
    public float MouseSensitivity { get { return _mouseSensitivity; } }

    public static Settings Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
}
