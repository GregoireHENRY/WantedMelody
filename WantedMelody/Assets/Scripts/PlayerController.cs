using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpSpeed;
    public AnimationCurve jumpAnimation;

    CharacterController controller;
    bool isJumping;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 verticalMovement = transform.forward * verticalInput * speed;
        Vector3 horizontalMovement = transform.right * horizontalInput * speed;

        controller.SimpleMove(verticalMovement + horizontalMovement);

        JumpInput();
    }

    void JumpInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            isJumping = true;
            StartCoroutine(JumpEvent());
        }
    }

    IEnumerator JumpEvent()
    {
        controller.slopeLimit = 90f;
        float timeInAir = 0f;

        do
        {
            float jumpForce = jumpAnimation.Evaluate(timeInAir);
            controller.Move(Vector3.up * jumpForce * jumpSpeed * Time.deltaTime);
            timeInAir += Time.deltaTime;
            yield return null;
        } while (!controller.isGrounded && controller.collisionFlags != CollisionFlags.Above);

        isJumping = false;
    }

    /*
    void OldController()
    {
        moveVertical = Input.GetAxis("Vertical");
        moveHorizontal = Input.GetAxis("Horizontal");
        movement = new Vector3(moveHorizontal, 0, moveVertical) * groundSpeed;
        rb.AddRelativeForce(movement, ForceMode.VelocityChange);

        // Cap the velocity to maxSpeed without reducing jumping height
        if (rb.velocity.magnitude > maxSpeed)
        {
            float yVel = rb.velocity.y;
            rb.velocity = maxSpeed * rb.velocity.normalized;
            float xVel = rb.velocity.x;
            float zVel = rb.velocity.z;
            rb.velocity = new Vector3(xVel, yVel, zVel);
        }

        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            jumpMovement = Vector3.up * jumpSpeed;
            rb.AddRelativeForce(jumpMovement, ForceMode.VelocityChange);
        }
    }

    bool IsGrounded()
    {
        Vector3 end = new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z);
        return Physics.CheckCapsule(col.bounds.center, end, col.radius, groundLayer);
    }
    */
}
