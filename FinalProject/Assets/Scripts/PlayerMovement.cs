using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Code origin from Brackeys First person FPS Controller
// Modified to use mobile joysticks instead of mouse

public class PlayerMovement : MonoBehaviour
{
    public FixedJoystick fixedJoystick;
    public CharacterController controller;

    float speed;
    public float gravity = -20f;
    [SerializeField]
    float jumpHeight = 3f;
    Vector3 move;

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
    [SerializeField]
    bool canJump;

    public Transform leftWallCheck;
    public Transform rightWallCheck;
    public LayerMask wallMask;
    [SerializeField]
    bool isRightWall;
    [SerializeField]
    bool isLeftWall;
    [SerializeField]
    float wallDistance = 0.4f;
    public Transform camera;
    public bool isWallRunning;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        isRightWall = Physics.CheckBox(rightWallCheck.position, new Vector3(wallDistance/2, 0.75f, wallDistance/2), Quaternion.identity, wallMask);
        isLeftWall = Physics.CheckBox(leftWallCheck.position, new Vector3(wallDistance/2, 0.75f, wallDistance/2), Quaternion.identity, wallMask);

        if (isGrounded)
        {
            canJump = true;
            if (velocity.y < 0f) {
                velocity.y = -2f;
            }
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
                isWallRunning = true;
                canJump = true;
            }
            if (isRightWall && !isGrounded) {
                stamina -= 10f * Time.deltaTime;
                gravity = 0f; 
                velocity.y = Mathf.Clamp(gravity, 0, 0);
                if (camera.transform.localEulerAngles.z < 30) {
                    camera.transform.Rotate(0,0,1);
                }
                isWallRunning = true;
                canJump = true;
            }
        } else {
            speed = walkSpeed;
            gravity = -20f;
            if (camera.transform.localEulerAngles.z < 180 && camera.transform.localEulerAngles.z != 0) {
                camera.transform.Rotate(0, 0, -1);
            }
            if (camera.transform.localEulerAngles.z > 180 && camera.transform.localEulerAngles.z != 0) {
                camera.transform.Rotate(0, 0, 1);
            }
            isWallRunning = false;
        }

        float x = fixedJoystick.Horizontal;
        float z = fixedJoystick.Vertical;

        move = transform.right * x + transform.forward * z;
        
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
        if (canJump) {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            canJump = false;
        }
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
