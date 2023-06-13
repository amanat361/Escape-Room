using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public float jumpSpeed;
    private float test;
    void Update()
    {
        if ((Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.UpArrow)))
        {
            rb.AddForce(0f, 0f, speed * Time.deltaTime, ForceMode.VelocityChange);
        }
        if ((Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.DownArrow)))
        {
            rb.AddForce(0f, 0f, -speed * Time.deltaTime, ForceMode.VelocityChange);
        }
        if ((Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.LeftArrow)))
        {
            rb.AddForce(-speed * Time.deltaTime, 0f, 0f, ForceMode.VelocityChange);
        }
        if ((Input.GetKey(KeyCode.D)) || (Input.GetKey(KeyCode.RightArrow)))
        {
            rb.AddForce(speed * Time.deltaTime, 0f, 0f, ForceMode.VelocityChange);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(0f, jumpSpeed * Time.deltaTime, 0f, ForceMode.VelocityChange);
        }
    }
}
