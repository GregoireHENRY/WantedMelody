using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotorOld : MonoBehaviour
{

    [SerializeField]
    Camera cam;

    Rigidbody rb;
    Vector3 velocity = Vector3.zero;
    Vector3 rotation = Vector3.zero;
    Vector3 cameraRotation = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();
    }

    public void Move(Vector3 vel)
    {
        velocity = vel;
    }

    public void Jump(float jump)
    {
        PerformJump(jump);
    }

    public void Rotate(Vector3 rot)
    {
        rotation = rot;
    }

    public void RotateCamera(Vector3 camRot)
    {
        cameraRotation = camRot;
    }

    void PerformMovement()
    {
        if (velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
            //rb.AddForceAtPosition()
        }
    }

    void PerformJump(float jumpSpeed)
    {
        Vector3 force = Vector3.up * jumpSpeed;
        //rb.AddForceAtPosition(force, transform.position);
        rb.AddForceAtPosition(force, transform.GetChild(1).position);
    }

    void PerformRotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
        
        if (cam != null)
        {
            cam.transform.Rotate(-cameraRotation);
        }
    }
}
