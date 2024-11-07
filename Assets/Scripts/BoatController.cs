using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour
{
    public Rigidbody rb;

    public float speed;
    public float rotateSpeed;
    public float swaySpeed;

    void Start()
    {
        rb.GetComponent<Rigidbody>();
        speed = 3.0f;
        rotateSpeed = 30.0f;
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.right * -vertical * speed * Time.deltaTime;
        rb.MovePosition(rb.position + moveDirection);

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(swaySpeed, 0, 0);
            if (Input.GetKey(KeyCode.S))
            {
                transform.Rotate(0, -rotateSpeed * Time.deltaTime, 0);
            }
            else
            {
                transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.S))
            {
                transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
            }
            else
            {
                transform.Rotate(0, -rotateSpeed * Time.deltaTime, 0);

            }
        }
    }
}
