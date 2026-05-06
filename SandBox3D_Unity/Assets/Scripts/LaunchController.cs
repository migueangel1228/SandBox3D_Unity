using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LaunchController : MonoBehaviour
{
    [Header("Referencias")]
    public GameObject projectilePrefab;
    public Transform launchPoint;

    [Header("Interfaz - velocidad")]
    public Slider speedSlider;
    public TMP_Text speedValueText;

    [Header("Interfaz - ángulo")]
    public Slider angleSlider;
    public TMP_Text angleValueText;

    [Header("Parámetros del lanzamiento")]
    public float initialSpeed = 10f;
    public float launchAngle = 45f; // En grados
    public float projectileMass = 1f;

    private GameObject currentProjectile;

    void Start()
    {
        // Sincronizar sliders con los valores iniciales (Inspector)
        SyncUIFromValues();

        // Asegurar que los textos se actualicen al inicio
        UpdateValuesFromUI();
    }

    void Update()
    {
        // Leer sliders y actualizar textos cada frame (simple y suficiente para el MVP)
        UpdateValuesFromUI();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            LaunchProjectile();
        }
    }

    private void SyncUIFromValues()
    {
        if (speedSlider != null)
        {
            speedSlider.value = initialSpeed;
        }

        if (angleSlider != null)
        {
            angleSlider.value = launchAngle;
        }
    }

    private void UpdateValuesFromUI()
    {
        // Velocidad
        if (speedSlider != null)
        {
            initialSpeed = speedSlider.value;
        }

        if (speedValueText != null)
        {
            speedValueText.text = "Velocidad: " + initialSpeed.ToString("F1") + " m/s";
        }

        // Ángulo
        if (angleSlider != null)
        {
            launchAngle = angleSlider.value;
        }

        if (angleValueText != null)
        {
            angleValueText.text = "Ángulo: " + launchAngle.ToString("F1") + "°";
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

        // Convertir ángulo a radianes
        float angleInRadians = launchAngle * Mathf.Deg2Rad;

        // Dirección de lanzamiento en el plano X-Y (Z = 0 por ahora)
        Vector3 launchDirection = new Vector3(
            Mathf.Cos(angleInRadians),
            Mathf.Sin(angleInRadians),
            0f
        );

        Vector3 initialVelocity = launchDirection * initialSpeed;

        // En versiones recientes de Unity puedes usar linearVelocity; si da error, usa rb.velocity en su lugar
        rb.linearVelocity = initialVelocity;
        // rb.velocity = initialVelocity; // Alternativa si linearVelocity no existe en tu versión
    }
}