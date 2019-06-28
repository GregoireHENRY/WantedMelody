using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    float speed = 10f;
    [SerializeField]
    float jumpForce = 7f;

    Rigidbody rb;
    CapsuleCollider col;
    LayerMask groundLayer;

    bool isJumping;
    float moveHorizontal, moveVertical;
    Vector3 movement;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
        groundLayer = LayerMask.GetMask("Default");

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        moveVertical = Input.GetAxis("Vertical");
        moveHorizontal = Input.GetAxis("Horizontal");
        movement = new Vector3(moveHorizontal, 0, moveVertical);

        rb.AddRelativeForce(movement * speed, ForceMode.Impulse);

        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    bool IsGrounded()
    {
        return Physics.CheckCapsule(col.bounds.center,
                                    new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z),
                                    col.radius, 
                                    groundLayer);
    }
}
