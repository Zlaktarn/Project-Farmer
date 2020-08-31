using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalMovement : MonoBehaviour
{
    [SerializeField]
    Animator anim = null;

    CharacterController controller;

    [Header("Moving Speeds")]
    [SerializeField]
    float speed = 0f;
    [SerializeField]
    float sneakSpeed = 1.0f;
    [SerializeField]
    float walkSpeed = 2.0f;
    [SerializeField]
    float sprintSpeed = 6.0f;
    [SerializeField]
    float aerialSpeed = 4.0f;

    [Header("Jump Settings")]
    [SerializeField]
    float jumpForce = 4;
    [SerializeField]
    float gravity = 10;
    float verticalVelocity;

    Vector3 moveVector;
    Vector3 rotation;
    Vector3 groundedVelocity;

    PlayerActions actions = null;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        actions = GetComponent<PlayerActions>();
    }

    void Update()
    {
        moveVector = Vector3.zero;
        Vector3 input = Vector3.zero;
        input.x = Input.GetAxis("Horizontal");
        input.z = Input.GetAxis("Vertical");
        input = transform.TransformDirection(input);
        input = Vector3.ClampMagnitude(input, 1f);

        if (controller.isGrounded)
        {
            if(!actions.digging)
            {
                Movement();

                moveVector = input;
                moveVector *= speed;

                verticalVelocity = -1;

                groundedVelocity = Vector3.ProjectOnPlane(moveVector, Vector3.up);

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    verticalVelocity = jumpForce;
                }
            }
        }
        
        if(!controller.isGrounded)
        {
            moveVector = groundedVelocity;
            moveVector += input * aerialSpeed;
            verticalVelocity -= gravity * Time.deltaTime;
        }

        moveVector = Vector3.ClampMagnitude(moveVector, speed);
        moveVector.y = verticalVelocity;

        //Rotation
        controller.Move(moveVector * Time.deltaTime);

        float forward = Input.GetAxis("Vertical");
        float strafe = Input.GetAxis("Horizontal");

        AnimMove(strafe, forward); //For Animation
    }


    private void AnimMove(float x, float y)
    {
        anim.SetFloat("Strafe", x);
        anim.SetFloat("Forward", y);
    }

    #region movement speed
    private void Movement()
    {
        if (Input.GetKey(KeyCode.LeftShift))
            speed = sprintSpeed;
        else if (Input.GetKey(KeyCode.LeftControl))
            speed = sneakSpeed;
        else
            speed = walkSpeed;
    }
    #endregion
}
