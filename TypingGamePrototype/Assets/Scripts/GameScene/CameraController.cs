using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;

    public float mouseSensitivity = 2f;
    private float xRotation = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float inputY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        xRotation -= inputY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localEulerAngles = Vector3.right * xRotation;

        player.Rotate(Vector3.up * inputX);
    }
}
