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
    int touchIndex;

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0) {
            Touch touchCheck = Input.GetTouch(0);
            if (touchCheck.position.x > 800) {
                touchIndex = 0;
            } else {
                touchIndex = Input.touchCount - 1;
            }
            Touch touch = Input.GetTouch(touchIndex);
            if (touch.phase == TouchPhase.Moved && touch.position.x > 800) {
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
