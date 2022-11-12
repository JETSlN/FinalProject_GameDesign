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

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Check run boolean with if else statement
        if (runButtonPressed && fixedJoystick.Vertical > 0.5 && stamina > 0) {
            speed = runSpeed;
            stamina -= 10f * Time.deltaTime;
            staminaTimer = waitTime;
        } else {
            speed = walkSpeed;
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

    /*
    private void WallRunInput() {
        if (fixedJoystick.Horizontal > 0.5f && wallRight && runButtonPressed && stamina > 0) {
            StartWallRun();
        } 
        if (fixedJoystick.Horizontal < -0.5f && wallLeft && runButtonPressed && stamina > 0) {
            StartWallRun();
        } 
    }

    private void StartWallRun() {
        gravity = 0f;
        isWallRunning = true;

        if (velocity.magnitude <= maxWallSpeed) {
            velocity.z = orientation.forward * wallForce * Time.deltaTime;

            if (wallRight) {
                velocity.x = orientation.right * wallForce / 5 * Time.deltaTime;
                if (Mathf.Abs(wallCameraTilt) < maxCameraTilt) {
                    wallCameraTilt += Time.deltaTime * maxCameraTilt * 2;
                }
            } else {
                velocity.x = orientation.left * wallForce / 5 * Time.deltaTime;
                if (Mathf.Abs(wallCameraTilt) < maxCameraTilt) {
                    wallCameraTilt -= Time.deltaTime * maxCameraTilt * 2;
                }
            }
        }
    }

    private void StopWallRun() {
        gravity = -9.81f;
        isWallRunning = false;

        if (wallCameraTilt > 0) {
            wallRunCameraTilt -= Time.deltaTime * maxCameraTilt * 2f;
        }
        if (wallCameraTilt < 0) {
            wallRunCameraTilt -= Time.deltaTime * maxCameraTilt * 2f;
        }
    }

    private void CheckForWall() {
        wallRight = Physics.Raycast(transform.position, orientation.right, 1f, wallCheck);
        wallLeft = Physics.Raycast(transform.position, orientation.left, 1f, wallCheck);

        if (!wallLeft && !wallRight) {
            StopWallRun();
        }
    }
    */

    public void Jump() {
        if (isGrounded) {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        /*
        if (isWallRunning) {
            if (wallLeft && fixedJoystick.Horizontal < 0.33f || wallRight && fixedJoystick.Horizontal > -0.33f) {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            if (wallRight || isWallLeft && fixedJoystick.Horizontal > 0.33f || fixedJoystick.Horizontal < -0.33f) {
                velocity.y = Mathf.Sqrt(jumpHeight * 1f * gravity);
            }

            if (wallRight && fixedJoystick.Horizontal < -0.33f) {
                velocity.x = Math.Sqrt(orientation.left * jumpHeight * 3.2f);
            }

            if (isWallLeft && fixedJoystick.Horizontal > 0.33f) {
                velocity.x = Math.Sqrt(orientation.right * jumpHeight * 3.2f);
            }

            velocity.z = orientation.forward * jumpHeight;
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
