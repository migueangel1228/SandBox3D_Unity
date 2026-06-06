using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class LaunchController : MonoBehaviour
{
    [Header("Prefab del proyectil")]
    public GameObject projectilePrefab;

    [Header("Sliders de control")]
    public Slider speedSlider;
    public Slider angleSlider;
    public Slider massSlider;

    [Header("Textos de los sliders")]
    public TMPro.TextMeshProUGUI speedText;
    public TMPro.TextMeshProUGUI angleText;
    public TMPro.TextMeshProUGUI massText;

    [Header("Referencias")]
    public PhysicsDataTracker physicsTracker;
    public EquationDisplay equationDisplay;

    void Update()
    {
        if (speedText != null)
            speedText.text = "Velocidad: " + speedSlider.value.ToString("F1") + " m/s";
        if (angleText != null)
            angleText.text = "Ángulo: " + angleSlider.value.ToString("F1") + "°";
        if (massText != null)
            massText.text = "Masa: " + massSlider.value.ToString("F2") + " kg";

        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
            Launch();
    }

    public void Launch()
    {
        float speed = speedSlider.value;
        float angle = angleSlider.value;
        float mass = massSlider.value;

        GameObject projectile = Instantiate(
            projectilePrefab,
            transform.position,
            Quaternion.identity
        );

        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.mass = mass;

        float angleRad = angle * Mathf.Deg2Rad;
        Vector3 velocity = new Vector3(
            Mathf.Cos(angleRad) * speed,
            Mathf.Sin(angleRad) * speed,
            0f
        );

        rb.linearVelocity = velocity;

        // Notificar al tracker de física
        if (physicsTracker != null)
            physicsTracker.SetProjectile(projectile);

        // Notificar al display de ecuaciones con los datos reales
        if (equationDisplay != null)
            equationDisplay.SetLaunchData(transform.position, velocity, mass);

        Debug.Log($"Lanzado | v={speed} m/s | θ={angle}° | m={mass} kg");
    }

    public void ResetScene()
    {
        GameObject[] projectiles = GameObject.FindGameObjectsWithTag("Projectile");
        foreach (GameObject p in projectiles)
            Destroy(p);
    }
}