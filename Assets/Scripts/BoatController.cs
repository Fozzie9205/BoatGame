using NUnit.Framework.Interfaces;
using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.UIElements;

public class BoatController : MonoBehaviour
{
    public Rigidbody rb;
    public Transform sail;
    public Transform windZone;
    public ClothWind clothWind;

    public float speed;
    public float rotateSpeed;
    public float sailRotateSpeed;
    public float maxSpeed = 10f;

    private float boatSpeed;
    private float dot;
    private float dot1;
    private float forward;

    void Start()
    {
        rb.GetComponent<Rigidbody>();
    }

    void Update()
    {
        //float horizontal = Input.GetAxis("Horizontal");
        //float vertical = Input.GetAxis("Vertical");

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
        //var clothX = clothWind.cloth.externalAcceleration.x;
        //var clothZ = clothWind.cloth.externalAcceleration.z;

        Vector3 windVector = windZone.forward;
        Vector3 sailVector = sail.forward;

        dot = Vector3.Dot(windVector, sailVector);
        dot1 = 1 - Mathf.Abs(dot);

        //boatSpeed = speed * DotGraph(dot1);

        float dot3 = Vector3.Dot(-transform.right, windVector);
        if (dot3 < -0.6)
        {
            forward = -1;
            boatSpeed /= 1.5f;
        }
        else
        {
            forward = 1;
            boatSpeed = speed * DotGraph(dot1);
        }
        //forward = Mathf.Sign(dot3);

        Debug.Log(boatSpeed);

        Vector3 moveDirection = -transform.right.normalized * boatSpeed * Time.deltaTime * forward;
        if (forward < 0)
        {
            moveDirection *= 0.5f;
        }
        rb.AddForce(moveDirection, ForceMode.Impulse);

        //Debug.Log(boatSpeed);
        Rotation();
    }

    float DotGraph(float x)
    {
        return Mathf.Pow(x, 0.1f);
    }
    void Rotation()
    {
        if (Input.GetKey(KeyCode.S))
        {
            sail.Rotate(0, sailRotateSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            sail.Rotate(0, -sailRotateSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -rotateSpeed * Time.deltaTime, 0);
        }
    }
}
