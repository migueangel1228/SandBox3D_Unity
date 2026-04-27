using UnityEngine;

public class LaunchController : MonoBehaviour
{
    [Header("Referencias")]
    public GameObject projectilePrefab;
    public Transform launchPoint;

    [Header("Parámetros del lanzamiento")]
    public float initialSpeed = 10f;
    public float launchAngle = 45f;
    public float projectileMass = 1f;

    private GameObject currentProjectile;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LaunchProjectile();
        }
    }

    public void LaunchProjectile()
    {
        if (currentProjectile != null)
        {
            Destroy(currentProjectile);
        }

        currentProjectile = Instantiate(
            projectilePrefab,
            launchPoint.position,
            Quaternion.identity
        );

        Rigidbody rb = currentProjectile.GetComponent<Rigidbody>();

        rb.mass = projectileMass;

        float angleInRadians = launchAngle * Mathf.Deg2Rad;

        Vector3 launchDirection = new Vector3(
            Mathf.Cos(angleInRadians),
            Mathf.Sin(angleInRadians),
            0f
        );

        Vector3 initialVelocity = launchDirection * initialSpeed;

        rb.linearVelocity = initialVelocity;
    }
}