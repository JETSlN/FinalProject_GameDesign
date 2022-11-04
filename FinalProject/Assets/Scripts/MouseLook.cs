using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Code origin from Brackeys First person FPS Controller
// Modified to use mobile joysticks instead of mouse
public class MouseLook : MonoBehaviour
{
    public float sensitivity;

    public Transform player;
    float xRotation = 0f;


    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved) {
                float touchX = touch.deltaPosition.x * sensitivity;
                float touchY = touch.deltaPosition.y * sensitivity;

                xRotation -= touchY;
                xRotation = Mathf.Clamp(xRotation, -90f, 90f);

                transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
                player.Rotate(Vector3.up * touchX);
            }
        }
    }
}
