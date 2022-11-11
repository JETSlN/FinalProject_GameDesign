using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Code origin from Brackeys First person FPS Controller
// Modified to use mobile joysticks instead of mouse
public class CameraLook : MonoBehaviour
{
    public float sensitivity;
    public float xBorder;

    public Transform player;
    float xRotation = 0f;
    int touchIndex;

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0) {
            Touch touchCheck = Input.GetTouch(0);
            if (touchCheck.position.x > xBorder) {
                touchIndex = 0;
            } else {
                touchIndex = Input.touchCount - 1;
            }
            Touch touch = Input.GetTouch(touchIndex);
            if (touch.phase == TouchPhase.Moved && touch.position.x > xBorder) {
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
