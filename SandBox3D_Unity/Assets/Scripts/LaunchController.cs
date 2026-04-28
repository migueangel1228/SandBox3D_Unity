using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LaunchController : MonoBehaviour
{
    [Header("Referencias")]
    public GameObject projectilePrefab;
    public Transform launchPoint;

    [Header("Interfaz")]
    public Slider speedSlider;
    public TMP_Text speedValueText;

    [Header("Parámetros del lanzamiento")]
    public float initialSpeed = 10f;
    public float launchAngle = 45f;
    public float projectileMass = 1f;

    private GameObject currentProjectile;

    void Start()
    {
        UpdateSpeedFromUI();
    }

    void Update()
    {
        UpdateSpeedFromUI();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            LaunchProjectile();
        }
    }

    private void UpdateSpeedFromUI()
    {
        if (speedSlider != null)
        {
            initialSpeed = speedSlider.value;
        }

        if (speedValueText != null)
        {
            speedValueText.text = "Velocidad: " + initialSpeed.ToString("F1") + " m/s";
        }
    }

    public void LaunchProjectile()
    {
        if (projectilePrefab == null)
        {
            Debug.LogError("No se asignó el prefab del proyectil.");
            return;
        }

        if (launchPoint == null)
        {
            Debug.LogError("No se asignó el punto de lanzamiento.");
            return;
        }

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

        if (rb == null)
        {
            Debug.LogError("El proyectil no tiene Rigidbody.");
            return;
        }

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