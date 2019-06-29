using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityManager : MonoBehaviour
{
    public float g;

    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity = new Vector3(0, -g, 0);
    }
}
