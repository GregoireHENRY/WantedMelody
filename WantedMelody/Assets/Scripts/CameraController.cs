using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{ 
    [Header("Camera Collision")]
    public float minDistance = 1.0f;
    public float maxDistance = 4.0f;
    public float smooth = 10.0f;

    GameObject followPoint;
    Vector3 playerDirection;
    float distanceToPlayer;

    void Start()
    {
        playerDirection = transform.localPosition.normalized;
        distanceToPlayer = transform.localPosition.magnitude;
    }

    void Update()
    {
        CameraCollision();
    }

    void CameraCollision()
    {
        Vector3 desiredCameraPos = transform.parent.TransformPoint(playerDirection * maxDistance);
        RaycastHit hit;
        if (Physics.Linecast(transform.parent.position, desiredCameraPos, out hit))
        {
            distanceToPlayer = Mathf.Clamp(hit.distance * 0.85f, minDistance, maxDistance);
        }
        else
        {
            distanceToPlayer = maxDistance;
        }
        transform.localPosition = Vector3.Lerp(transform.localPosition, playerDirection * distanceToPlayer, Time.deltaTime * smooth);
    }
}
