using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Code origin from Brackeys First person FPS Controller
// Modified to use mobile joysticks instead of mouse

public class PlayerMovement : MonoBehaviour
{
    public FixedJoystick fixedJoystick;
    public CharacterController controller;
    //public Rigidbody rb;

    float speed;
    public float gravity = -20f;
    [SerializeField]
    float jumpHeight = 3f;

    public Transform groundCheck;
    public LayerMask groundMask;
    [SerializeField]
    float groundDistance = 0.4f;

    Vector3 velocity;
    bool isGrounded;

    [SerializeField]
    float stamina = 50f;
    [SerializeField]
    float waitTime;
    [SerializeField]
    float staminaTimer = 0f;
    [SerializeField]
    float runSpeed;
    [SerializeField]
    float walkSpeed;
    public StaminaBar bar;
    bool runButtonPressed;

    public Transform leftWallCheck;
    public Transform rightWallCheck;
    public LayerMask wallMask;
    bool isRightWall;
    bool isLeftWall;
    [SerializeField]
    float wallDistance = 0.4f;
    [SerializeField]
    float wallJumpForce;
    public Transform camera;

    // Update is called once per frame
    void Update()
    {
        /*
        CheckForWall();
        WallRunInput();
        camera.transform.localRotation = Quaternion.Euler(camera.localRotation.x, 10, wallCameraTilt);
        orientation.transform.localRotation = Quaternion.Euler(0, 10, 0);
        */

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        isRightWall = Physics.CheckSphere(rightWallCheck.position, wallDistance, wallMask);
        isLeftWall = Physics.CheckSphere(leftWallCheck.position, wallDistance, wallMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (!isRightWall && !isLeftWall) {
            gravity = -20f;
        }

        // Check run boolean with if else statement
        if (runButtonPressed && fixedJoystick.Vertical > 0.5 && stamina > 0) {
            speed = runSpeed;
            stamina -= 10f * Time.deltaTime;
            staminaTimer = waitTime;
            if (isLeftWall && !isGrounded) {
                stamina -= 10f * Time.deltaTime;
                gravity = 0f;
                velocity.y = Mathf.Clamp(gravity, 0, 0);
                if (camera.transform.localEulerAngles.z == 0) {
                    camera.transform.Rotate(0,0,-1);
                }
                if (camera.transform.localEulerAngles.z > 330) {
                    camera.transform.Rotate(0,0,-1);
                }
            }
            if (isRightWall && !isGrounded) {
                stamina -= 10f * Time.deltaTime;
                gravity = 0f; 
                velocity.y = Mathf.Clamp(gravity, 0, 0);
                if (camera.transform.localEulerAngles.z < 30) {
                    camera.transform.Rotate(0,0,1);
                }
            }
        } else {
            gravity = -20f;
            speed = walkSpeed;
            if (camera.transform.localEulerAngles.z < 180 && camera.transform.localEulerAngles.z != 0) {
                camera.transform.Rotate(0, 0, -1);
            }
            if (camera.transform.localEulerAngles.z > 180 && camera.transform.localEulerAngles.z != 0) {
                camera.transform.Rotate(0, 0, 1);
            }
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
        bar.UpdateStaminaBar(50, stamina);
        if (staminaTimer > 0) {
            staminaTimer -= Time.deltaTime;
        }
        if (staminaTimer <= 0 && stamina < 50 && speed == walkSpeed) {
            stamina += 5f * Time.deltaTime;
        }
    }

    public void Jump() {
        if (isGrounded) {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        /*
        if (isLeftWall && speed > walkSpeed && !isGrounded && stamina > 10) {
            stamina -= 10f;
            staminaTimer = waitTime;
            velocity.x = Mathf.Sqrt(wallJumpForce);
        }
        if (isRightWall && speed > walkSpeed && !isGrounded && stamina > 10) {
            stamina -= 10f;
            staminaTimer = waitTime;
            velocity.x = Mathf.Sqrt(-wallJumpForce);
        }
        */
    }

    public void RunHeld() {
        if (stamina > 5f) {
            // Only starts if stamina > 5
            runButtonPressed = true;
        }
    }

    public void RunReleased() {
        runButtonPressed = false;
    }
}
