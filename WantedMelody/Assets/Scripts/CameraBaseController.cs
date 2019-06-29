using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBaseController : MonoBehaviour
{
    [Header("General")]
    public float sensitivity = 150.0f;
    public float clampAngle = 80.0f;
    [Header("Camera Follow")]
    public GameObject followObject;
    public float followSpeed = 120.0f;

    GameObject followPoint;
    float rotY = 0.0f;
    float rotX = 0.0f;
    float mouseX;
    float mouseY;

    void Start()
    {
        followPoint = followObject.transform.GetChild(1).gameObject;
        transform.position = followPoint.transform.position;

        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        CameraBaseRotation();
        CameraBaseFollow();
    }

    void CameraBaseRotation()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        rotY += mouseX * sensitivity * Time.deltaTime;
        rotX += mouseY * sensitivity * Time.deltaTime;
        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

        transform.rotation = Quaternion.Euler(rotX, rotY, 0);
        followObject.transform.rotation = Quaternion.Euler(0, rotY, 0);
    }

    void CameraBaseFollow()
    {
        transform.position = Vector3.MoveTowards(transform.position, followPoint.transform.position, followSpeed * Time.deltaTime);
    }
}
