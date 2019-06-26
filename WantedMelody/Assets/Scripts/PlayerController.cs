using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    float speed = 10f;
    [SerializeField]
    float jumpForce = 50f;

    Transform groundPos;
    Rigidbody rb;

    float translation, straffe, jump;
    Vector3 groundForce;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        groundPos = transform.GetChild(2);
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        straffe = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = speed * Time.deltaTime;
        }

        transform.Translate(straffe, jump, translation);
        
        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }

        /*
        groundForce = Vector3.zero;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (transform.position.y <= 2f) // Jumping is available only on the ground
            {
                groundForce = Vector3.up * jumpForce;
            }
        }
        rb.AddForceAtPosition(groundForce, groundPos.position);
        */
    }
}
