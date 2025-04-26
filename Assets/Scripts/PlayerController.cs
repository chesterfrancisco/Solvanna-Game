using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public float moveSpeed, gravityModifier, jumpPower, runSpeed = 12f;
    public CharacterController charCon;

    private Vector3 moveInput;

    public Transform camTrans;

    public float mouseSensitivity;
    public bool invertX;
    public bool invertY;

    private bool canJump, canDoubleJump;
    public Transform groundCheckPoint;
    public LayerMask whatIsGround;
    public Animator anim;

    public GameObject bullet;
    public Transform firePoint;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        
    }

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (!UIController.instance.pauseScreen.activeInHierarchy)
        {
        
            //moveInput.x = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
            //moveInput.z = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

            //store Y velocity
            float yStore = moveInput.y;

            Vector3 vertMove = transform.forward * Input.GetAxis("Vertical");
            Vector3 horiMove = transform.right * Input.GetAxis("Horizontal");
            //moveInput = vertMove * moveSpeed * Time.deltaTime;
            moveInput = horiMove + vertMove;
            moveInput.Normalize();
            if (Input.GetKey(KeyCode.LeftShift))
            {
                moveInput = moveInput * runSpeed; 
            }
            else
            {
                moveInput = moveInput * moveSpeed;
            }

            moveInput.y = yStore;

            moveInput.y += Physics.gravity.y * gravityModifier * Time.deltaTime;

            if(charCon.isGrounded)
            {
                moveInput.y = Physics.gravity.y * gravityModifier * Time.deltaTime;
            }

            canJump = Physics.OverlapSphere(groundCheckPoint.position, .25f, whatIsGround).Length > 0;

            if (canJump)
            {
                canDoubleJump = false;
            }

            //handle Character Jumping
            if (Input.GetKeyDown(KeyCode.Space) && canJump)
            {
                moveInput.y = jumpPower;
                canDoubleJump = true;
            }

            else if(canDoubleJump && Input.GetKeyDown(KeyCode.Space))
            {
                moveInput.y = jumpPower;
                canDoubleJump = false;
            }


            charCon.Move(moveInput * Time.deltaTime);
         
            //control Camera Rotation
            Vector2 mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mouseSensitivity;

            if(invertX)
            {
                mouseInput.x = -mouseInput.x;
            }

            if (invertY)
            {
                mouseInput.y = -mouseInput.y;
            }

            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + mouseInput.x, transform.rotation.eulerAngles.z);
            camTrans.rotation = Quaternion.Euler(camTrans.rotation.eulerAngles + new Vector3(-mouseInput.y, 0f, 0f));


            //Handle shooting
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                if(Physics.Raycast(camTrans.position, camTrans.forward, out hit, 50f))
                {
                    if (Vector3.Distance(camTrans.position, hit.point) > 2f)
                    {
                        firePoint.LookAt(hit.point);
                    }
                }
                else
                {
                    firePoint.LookAt(camTrans.position + (camTrans.forward * 30f) );
                }

                Instantiate(bullet, firePoint.position, firePoint.rotation);
            }

            //anim.SetFloat("moveSpeed", moveInput.magnitude);
            //anim.SetBool("onGround", canJump);
        }
    }
}
