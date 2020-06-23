using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public float CameraMoveSpeed = 120.0f;
    public GameObject CameraFollowObj;
    public float clampAngle = 80.0f;
    public float inputSensitivity = 150.0f;
    public GameObject CameraObj;
    public GameObject PlayerObj;

    private float mouseX;
    private float mouseY;
    private float finalInputX;
    private float finalInputZ;
    //public float smoothX;
    //public float smoothY;
    private float rotY = 0.0f;
    private float rotX = 0.0f;

    public bool rotationOff;
    Transform pTransform;
    public Quaternion playerRotation;

    void Start()
    {
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;

        pTransform = PlayerObj.GetComponent<Transform>();
        //NormalMovement player = PlayerObj.GetComponent<NormalMovement>();
    }

    void Update()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = -Input.GetAxis("Mouse Y");
        finalInputX = mouseX;
        finalInputZ = mouseY;

        rotY += finalInputX * inputSensitivity * Time.deltaTime;
        rotX += finalInputZ * inputSensitivity * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.rotation = localRotation;
        playerRotation = Quaternion.Euler(0.0f, rotY, 0.0f);

        if (!rotationOff)
            pTransform.rotation = playerRotation;


        if (!PlayerActions.inventoryOpen)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    void LateUpdate()
    {
        CameraUpdater();
    }

    void CameraUpdater()
    {
        //Set target to follow
        Transform target = CameraFollowObj.transform;

        //move towards game object that is the target
        float step = CameraMoveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }

    public void RotationDisabled(Quaternion rotation)
    {
        if (rotationOff)
        {
            pTransform.rotation = rotation;
        }
        else
        {
            pTransform.rotation = rotation;
        }

    }

    public bool RotationEnabled()
    {
        if (!rotationOff)
        {

            return true;
        }

        return false;
    }
}
