using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerInterior : MonoBehaviour
{
    public float mouseSensitivity = 100f;

    private float xRotation = 0f;
    private float yRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -5f,15f);

        yRotation += mouseX;
        yRotation = Mathf.Clamp(yRotation, -30f,30f);

        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }
}
