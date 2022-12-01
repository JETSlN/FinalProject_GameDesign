using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //to remove later

// Code origin from Brackeys First person FPS Controller
// Modified to use mobile joysticks instead of mouse

public class PlayerMovement : MonoBehaviour
{
    public Transform carty;
    public StayCart ymovement;
    public bool cart = false;
    public char directionCart;
    public static PlayerMovement Instance;
    
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
    public float staminaItem = 1f;
    public GameObject staminaBoost;

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

    bool slidePressed;
    public Transform playerCapsule;
    bool isSliding;
    public float controllerHeight;
    //public float groundCheckYPos;

    public float yPosDeath;

    public void cartitup(){
        if(cart == false){
            cart = true;
        }
        else{
            cart = false;
        }
    }

    private void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        float x = fixedJoystick.Horizontal;
        float z = fixedJoystick.Vertical;

        if (cart) {
            if (carty.localEulerAngles.z < 345 &&  carty.localEulerAngles.z > 300){
                directionCart =  'R';  
            }
            else if (carty.localEulerAngles.z > 15 &&  carty.localEulerAngles.z < 60){
                directionCart =  'L';  
            }
            else{
                directionCart =  'N';
            }
            
            if (x >= 0.5 && (carty.localEulerAngles.z == 0 || carty.localEulerAngles.z > 330)){
                
                camera.transform.Rotate(0,0,-1);
                carty.Rotate(0,0,-1);
                
            }
            else if (x <= -0.5 && carty.localEulerAngles.z < 30){
                
                camera.transform.Rotate(0,0,1);
                carty.Rotate(0,0,1);
            }
            else if (z <= -0.5 && (int)carty.localEulerAngles.z == 0){
                ymovement.y = 2f;
            }
            else{
                
                if (carty.localEulerAngles.z < 180 && carty.localEulerAngles.z != 0 && x > -0.5) {
                    camera.transform.Rotate(0, 0, -1);
                    carty.Rotate(0,0,-1);
                }
                if (carty.localEulerAngles.z > 180 && carty.localEulerAngles.z != 0 && x < 0.5) {
                    camera.transform.Rotate(0, 0, 1);
                    carty.Rotate(0,0,1);
                }
                if (ymovement.y < 3){
                    ymovement.y = 3f;
                }
            }
        }
        else {
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
        if (runButtonPressed && fixedJoystick.Vertical > 0.5 && stamina > 0 && !slidePressed) {
            if (isLeftWall && !isGrounded) {
                speed = runSpeed;
                staminaTimer = waitTime;
                stamina -= 20f * Time.deltaTime / staminaItem;
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
            } else if (isRightWall && !isGrounded) {
                speed = runSpeed;
                staminaTimer = waitTime;
                stamina -= 20f * Time.deltaTime / staminaItem;
                gravity = 0f; 
                velocity.y = Mathf.Clamp(gravity, 0, 0);
                if (camera.transform.localEulerAngles.z < 30) {
                    camera.transform.Rotate(0,0,1);
                }
                isWallRunning = true;
                canJump = true;
            } else if (isGrounded) {
                speed = runSpeed;
                staminaTimer = waitTime;
                stamina -= 10f * Time.deltaTime / staminaItem;
            }
        } else {
            if (!slidePressed) {
                speed = walkSpeed;
            }
            gravity = -20f;
            if (camera.transform.localEulerAngles.z < 180 && camera.transform.localEulerAngles.z != 0) {
                camera.transform.Rotate(0, 0, -1);
            }
            if (camera.transform.localEulerAngles.z > 180 && camera.transform.localEulerAngles.z != 0) {
                camera.transform.Rotate(0, 0, 1);
            }
            isWallRunning = false;
        }

        if (slidePressed && isGrounded && !runButtonPressed && stamina > 0) {
            isSliding = true;
            speed = runSpeed;
            /*
            if (camera.position.y - gameObject.transform.position.y > -0.75) {
                camera.Translate(new Vector3 (0, -0.25f, 0));
                playerCapsule.Translate(new Vector3 (0, -0.25f, 0));
            }
            */
            stamina -= 25f * Time.deltaTime / staminaItem;
            staminaTimer = waitTime;
        } else {
            isSliding = false;
            if (stamina <= 0) {
                SlideReleased();
            }
            if (!runButtonPressed) {
                speed = walkSpeed;
            }
            if (camera.position.y - gameObject.transform.position.y < 0.75) {
                camera.Translate(new Vector3 (0, 0.25f, 0));
                playerCapsule.Translate(new Vector3 (0, 0.25f, 0));
            }
        }




        if(!isSliding) {
            move = transform.right * x + transform.forward * z;
        } else {
            move = transform.forward;
        }
        
        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        }
        
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
        if (gameObject.transform.position.y < yPosDeath) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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

    public void SlideHeld() {
        if (stamina > 5f && isGrounded) {
            slidePressed = true;
            controller.height = controllerHeight * 2/5;
            //controller.center = new Vector3(0, controller.center.y-groundCheckYPos, 0);
            //groundCheck.localPosition = new Vector3(0,0,0);
        }
    }

    public void SlideReleased() {
        slidePressed = false;
        controller.height = controllerHeight;
        //controller.center = new Vector3(0, 0, 0);
        //groundCheck.localPosition = new Vector3(0,groundCheckYPos,0);
    }

    public void staminaConsumable(float duration) {
        staminaItem = 2f;
        staminaBoost.SetActive(true);
        Invoke("normalStamina", duration);
    }

    void normalStamina() {
        staminaBoost.SetActive(false);
        staminaItem = 1f;
    }
}
