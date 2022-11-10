using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Code origin from Brackeys First person FPS Controller
// Modified to use mobile joysticks instead of mouse

public class PlayerMovement : MonoBehaviour
{
    public FixedJoystick fixedJoystick;
    public CharacterController controller;
    public Rigidbody rb;

    [SerializeField]
    float speed = 12f;
    public float gravity = -9.81f;
    [SerializeField]
    float jumpHeight = 3f;

    public Transform groundCheck;
    public LayerMask groundMask;
    [SerializeField]
    float groundDistance = 0.4f;

    Vector3 velocity;
    bool isGrounded;

    [SerializeField]
    float stamina = 100f;
    [SerializeField]
    float waitTime;
    [SerializeField]
    float staminaTimer = 0f;


    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = fixedJoystick.Horizontal;
        float z = fixedJoystick.Vertical;

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }


    void FixedUpdate()
    {
        if (staminaTimer > 0) {
            staminaTimer -= Time.deltaTime;
        }
        if (staminaTimer <= 0 && stamina < 100 && speed == 12f) {
            stamina += 10f * Time.deltaTime;
        }
    }

    public void Jump() {
        if (isGrounded) {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    public void RunHeld() {
        if (fixedJoystick.Vertical > 0.1f && isGrounded && stamina > 0)
        {
            speed = 25f;
            stamina -= 0.5f * Time.deltaTime;
            staminaTimer = waitTime;
        }
    }

    public void RunReleased() {
        speed = 12f;
    }
}
