using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour
{
    public Rigidbody rb;

    public float speed;
    public float rotateSpeed;

    void Start()
    {
        rb.GetComponent<Rigidbody>();
        speed = 3.0f;
        rotateSpeed = 0.2f;
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.right * -vertical * speed * Time.deltaTime;
        rb.MovePosition(rb.position + moveDirection);

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, rotateSpeed, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -rotateSpeed, 0);
        }
    }
}
