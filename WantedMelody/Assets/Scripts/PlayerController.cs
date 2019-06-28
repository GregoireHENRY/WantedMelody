using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    float speed = 10f;

    Transform groundPos;
    Rigidbody rb;

    bool isJumping;
    float translation, straffe, jump, jumpAcc, jumpVel;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jumpAcc = 300f;

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        straffe = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        jump = Jumping();

        transform.Translate(straffe, jump, translation);

        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    float Jumping()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            isJumping = true;
            jumpVel = jumpAcc * Time.deltaTime;
        }

        if (isJumping)
        {
            if (jumpVel > 0)
            {
                jumpVel -= 9.81f * Time.deltaTime;
            }
            jump = jumpVel * Time.deltaTime;
        }

        if (jump < 0f)
        {
            isJumping = false;
            jump = 0f;
        }

        return jump;
    }
}
