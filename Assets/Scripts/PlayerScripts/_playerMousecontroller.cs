using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _playerMousecontroller : MonoBehaviour
{
    public float _MouseSensitivity = 100f;

    [SerializeField]private Transform _playerBody;

    private float xRoatation = 0;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * _MouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _MouseSensitivity * Time.deltaTime;

        xRoatation -= mouseY;
        xRoatation = Mathf.Clamp(xRoatation, - 90f, 90f);

        transform.localRotation = Quaternion.Euler(xRoatation, 0f, 0f);
        _playerBody.Rotate(Vector3.up * mouseX);
    }
}
