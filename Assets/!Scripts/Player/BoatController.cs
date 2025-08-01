using NUnit.Framework.Interfaces;
using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class BoatController : MonoBehaviour
{
    public Rigidbody rb;
    public Transform sail;
    public Transform windZone;
    public GameObject deathScreen;

    public float speed;
    public float rotateSpeed;
    public float sailRotateSpeed;
    public float maxSpeed = 10f;

    private float boatSpeed;
    private float dotSail;
    private float dotSailNew;
    private float dotBoat;
    private float forward;

    private bool dot3HasRun = false;

    void Start()
    {
        Time.timeScale = 1f;
        rb.GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        Movement();
        Rotation();
    }
    void Update()
    {
        if (deathScreen.activeSelf && Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    float DotGraph(float x)
    {
        return Mathf.Pow(x, 0.28f);
    }

    void Movement()
    {
        Vector3 windVector = windZone.forward;
        Vector3 sailVector = sail.forward;

        dotSail = Vector3.Dot(windVector.normalized, sailVector.normalized);
        dotSailNew = 1 - Mathf.Abs(dotSail);
        boatSpeed = speed * DotGraph(dotSailNew);

        dotBoat = Vector3.Dot(-transform.right, windVector);
        if (dotBoat < -0.6)
        {
            if (!dot3HasRun)
            {
                dot3HasRun = true;
                forward = -1;
                boatSpeed /= 2.0f;
            }
        }
        else
        {
            forward = 1;
            boatSpeed = speed * DotGraph(dotSailNew);
            dot3HasRun = false;
        }

        Vector3 moveDirection = -transform.right.normalized * boatSpeed * Time.deltaTime * forward;
        if (forward < 0)
        {
            moveDirection *= 0.5f;
        }

        if (moveDirection != Vector3.zero)
        {
            rb.AddForce(moveDirection, ForceMode.Impulse);
        }
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
