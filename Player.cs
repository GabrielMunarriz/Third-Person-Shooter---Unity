using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float jumpHeight = 20.0f;
    [SerializeField] private float gravity = 0.25f;
    private float yVelocity;
    private CharacterController controller;
    private Animator animator;

    // Start is called before the first frame update
    void Awake()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    void Start()
    {
        //lock cursor to center
        

        //assign CharacterController to controller object
        
    }

    // Update is called once per frame
    void Update()
    {

        //Lock and unlock cursor functionality
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }

        //Update player movement every frame
        Movement();
    }

    void Movement()
    {
        var horizontalMovement = Input.GetAxis("Horizontal");
        var verticalMovement = Input.GetAxis("Vertical");

        var direction = new Vector3(horizontalMovement, 0, verticalMovement);
        Vector3 velocity = direction * speed;

        //we manipulate yVelocity here based on whether or not the controller is on the ground.
        if (controller.isGrounded == true)
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                yVelocity = jumpHeight;
            }

        }
        else
        {

            yVelocity -= gravity;

        }

        //we only update velocity.y once we have "decided" on our yVelocity.
        velocity.y = yVelocity;

        //transform direction from local space to world space
        velocity = transform.TransformDirection(velocity);

        //move player
        controller.Move(velocity * Time.deltaTime);

        animator.SetFloat("Speed", direction.magnitude);
    }

}
