using UnityEngine;
using UnityEngine.InputSystem;

public class LaunchController : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float speed = 15f;
    public float angle = 45f;

    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Launch();
        }
    }

    void Launch()
    {
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();

        float angleRad = angle * Mathf.Deg2Rad;
        Vector3 velocity = new Vector3(
            Mathf.Cos(angleRad) * speed,
            Mathf.Sin(angleRad) * speed,
            0f
        );

        rb.linearVelocity = velocity;
    }
}