using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.ProBuilder;

public class cannonShoot : MonoBehaviour
{
    public float waitTime;
    public float projectileSpeed;

    private bool isRunning = false;

    public Transform player;
    public Transform cannonBallSpawn;
    void Start()
    {
        
    }
    void Update()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        transform.LookAt(player.position);
        if (Vector3.Distance(transform.position, player.position) <= 25 && !isRunning)
        {
            StartCoroutine(shootCoroutine());
        }
    }

    IEnumerator shootCoroutine()
    {
        isRunning = true;

        GameObject cannonBall = ObjectPool_Cannon.SharedInstance.GetPooledObject();
        SphereCollider sphereCollider = GetComponent<SphereCollider>();
        Rigidbody rb = cannonBall.GetComponent<Rigidbody>();

        Vector3 directionToPlayer = player.position - cannonBallSpawn.position;

        if (cannonBall != null)
        {
            cannonBall.transform.position = cannonBallSpawn.position;
            cannonBall.SetActive(true);

            float distance = directionToPlayer.magnitude;
            Debug.Log("distance " + distance);

            float height = directionToPlayer.y;
            Debug.Log("height " + height);

            directionToPlayer.y = 0;

            if (distance > 0f)
            {
                float angle = Mathf.Abs(Mathf.Atan2(height, distance));
                Debug.Log("angle " + angle);

                float launchSpeed = Mathf.Sqrt(distance * Physics.gravity.magnitude / Mathf.Sin(2 * angle));
                launchSpeed *= projectileSpeed;
                
                Debug.Log("launch speed " + launchSpeed);

                if (!float.IsNaN(launchSpeed) && !float.IsInfinity(launchSpeed))
                {
                    Vector3 velocity = directionToPlayer.normalized * launchSpeed;
                    rb.velocity = new Vector3(velocity.x, Mathf.Sin(angle) * launchSpeed, velocity.z);
                }
                else
                {
                    Debug.LogWarning("Invalid arc calculation, fallback to straight shot.");
                    rb.velocity = directionToPlayer.normalized * projectileSpeed;
                }
            }
            else
            {
                Debug.LogWarning("Player is too close or directly above/below, skipping arc calculation.");
                rb.velocity = directionToPlayer.normalized * projectileSpeed;
            }
            yield return new WaitForSeconds(waitTime);
            isRunning = false;
        }
    }
}
