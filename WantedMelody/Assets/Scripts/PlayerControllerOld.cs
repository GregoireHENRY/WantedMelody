using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotorOld))]
public class PlayerControllerOld : MonoBehaviour
{

    PlayerMotorOld motor;

    [SerializeField]
    float speed = 5f;
    [SerializeField]
    float jumpSpeed = 1000f;
    [SerializeField]
    float lookSensitivity = 3f;

    // Start is called before the first frame update
    void Start()
    {
        motor = GetComponent<PlayerMotorOld>();
    }

    // Update is called once per frame
    void Update()
    {
        float xMov = Input.GetAxisRaw("Horizontal");
        float zMov = Input.GetAxisRaw("Vertical");
        float yRot = Input.GetAxisRaw("Mouse X");
        float xRot = Input.GetAxisRaw("Mouse Y");
        float mwheel = Input.mouseScrollDelta.y;

        Vector3 movHorizontal = transform.right * xMov;
        Vector3 movVertical = transform.forward * zMov;
        Vector3 velocity = (movHorizontal + movVertical).normalized * speed;
        Vector3 rotation = new Vector3(0f, yRot, 0f) * lookSensitivity;
        Vector3 cameraRotation = new Vector3(xRot, 0f, 0f) * lookSensitivity;
        
        motor.Move(velocity);
        if (mwheel > 0) motor.Jump(jumpSpeed);
        motor.Rotate(rotation);
        motor.RotateCamera(cameraRotation);
    }

    /*
    void CaptureInteraction()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                Debug.Log("You've clicked on something..");
            }
        }
    }
    */
}
