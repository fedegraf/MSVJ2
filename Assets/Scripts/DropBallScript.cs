using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBallScript : MonoBehaviour
{
    private bool dropped = false;
    private BallController ballController;
    private Rigidbody rb;

    void Start()
    {
        ballController = GetComponent<BallController>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (ballController.isShoot)
        {
            if (Input.GetKeyDown(KeyCode.Space) && !dropped)
            {
                rb.velocity = Vector3.down * 14f;
                rb.mass = 3f;
                dropped = true;
            }
        }
    }
}
