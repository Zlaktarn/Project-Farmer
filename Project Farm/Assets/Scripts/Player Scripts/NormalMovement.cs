using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalMovement : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 movementVector = Vector3.zero;
    private Vector3 directionSpeed;
    private float speed = 0;

    [Header("Movement Speeds")]
    [SerializeField]
    float WalkSpeed = 3.0f;
    [SerializeField]
    float RunSpeed = 5.0f;

    [Range(0.1f, 1.0f)]
    [SerializeField]
    float sideSpeedModifier = 1.0f;


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Movement();
        
    }

    private void Movement()
    {
        directionSpeed.z = speed * Input.GetAxis("Vertical");
        directionSpeed.x = speed * sideSpeedModifier * Input.GetAxis("Horizontal");
        directionSpeed = transform.TransformDirection(directionSpeed);

        movementVector = new Vector3(directionSpeed.x, 0, directionSpeed.z);
        movementVector.y -= 1;

        rb.velocity = movementVector;

        if (Input.GetKey(KeyCode.LeftShift))
            speed = RunSpeed;
        else
            speed = WalkSpeed;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * 100f);
        }
    }
}
