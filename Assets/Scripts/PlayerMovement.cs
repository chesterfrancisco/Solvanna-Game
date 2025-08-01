using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform Camera;
    private CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f * 2;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 2.0f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;
    public bool isMoving;

    private Vector3 lastPosition = new(0f,0f,0f);


    void Start()
    {
       controller = GetComponent<CharacterController>();
    }

    
    void Update()
    {
        // Ground check
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        //Resetting the default velocity
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Getting the inputs
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //Creating the moving vector
        //Vector3 move = transform.right * x + transform.forward * z;
        Vector3 move = Camera.transform.right * x + Camera.transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (lastPosition != gameObject.transform.position && isGrounded == true)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        lastPosition = gameObject.transform.position;

    }
}
