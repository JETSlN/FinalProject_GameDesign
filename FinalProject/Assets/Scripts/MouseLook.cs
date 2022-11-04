using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensitivity = 100f;
    public FixedJoystick fixedJoystick;

    public Transform player;
    float xRotation = 0f;


    // Start is called before the first frame update
    void Start()
    {
        // Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float joystickX = fixedJoystick.Horizontal * sensitivity * Time.deltaTime;
        float joystickY = fixedJoystick.Vertical * sensitivity * Time.deltaTime;

        xRotation -= joystickY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        player.Rotate(Vector3.up * joystickX);
    }
}
