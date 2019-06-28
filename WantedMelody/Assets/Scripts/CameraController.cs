using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField]
    float sensitivity = 2.5f;

    Rigidbody player;
    Camera cam;

    Vector2 md;
    Vector3 playerRotation, cameraRotation;

    // Use this for initialization
    void Start()
    {
        player = GetComponent<Rigidbody>();
        cam = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * sensitivity;
        playerRotation = new Vector3(0f, md.x, 0f);
        // cameraRotation = new Vector3(-md.y, 0f, 0f) * .25f;

        // player.transform.Rotate(playerRotation);
        // cam.transform.Rotate(cameraRotation);
    }
}
