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
        if (Input.GetAxis("Mouse ScrollWheel") > 0 && !isJumping)
        {
            Debug.Log("JUMP!");
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
}
