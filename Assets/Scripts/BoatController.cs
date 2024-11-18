using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject sail;
    public ClothWind clothWind;

    public float speed;
    public float rotateSpeed;


    public WindZone windZone;
    public Rigidbody boatRigidbody;
    public float sailEfficiency = 1f;
    public float maxSpeed = 10f;

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

        /*Vector3 moveDirection = transform.right * -vertical * speed * Time.deltaTime;
        rb.MovePosition(rb.position + moveDirection);

        if (Input.GetKey(KeyCode.D))
        {
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
        }*/
        

        if (Input.GetKey(KeyCode.A))
        {
            sail.transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            sail.transform.Rotate(0, -rotateSpeed * Time.deltaTime, 0);
        }
    }
}
