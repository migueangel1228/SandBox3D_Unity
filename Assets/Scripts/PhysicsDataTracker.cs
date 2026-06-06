using UnityEngine;
using TMPro;

public class PhysicsDataTracker : MonoBehaviour
{
    [Header("Referencia al proyectil activo")]
    public GameObject activeProjectile;

    [Header("Textos del panel de datos")]
    public TextMeshProUGUI textTiempo;
    public TextMeshProUGUI textPosX;
    public TextMeshProUGUI textPosY;
    public TextMeshProUGUI textPosZ;
    public TextMeshProUGUI textVelX;
    public TextMeshProUGUI textVelY;
    public TextMeshProUGUI textVelZ;
    public TextMeshProUGUI textAcel;

    private Rigidbody rb;
    private float tiempoVuelo = 0f;
    private Vector3 velocidadAnterior;

    void Update()
    {
        if (activeProjectile == null) return;

        rb = activeProjectile.GetComponent<Rigidbody>();
        if (rb == null) return;

        tiempoVuelo += Time.deltaTime;

        Vector3 pos = activeProjectile.transform.position;
        Vector3 vel = rb.linearVelocity;

        // Fix NaN: solo calcular aceleración si deltaTime > 0
        float acelY = 0f;
        if (Time.deltaTime > 0f)
        {
            Vector3 acel = (vel - velocidadAnterior) / Time.deltaTime;
            acelY = acel.y;
        }
        velocidadAnterior = vel;

        if (textTiempo != null) textTiempo.text = "Tiempo: " + tiempoVuelo.ToString("F2") + " s";
        if (textPosX != null) textPosX.text = "Pos X: " + pos.x.ToString("F2") + " m";
        if (textPosY != null) textPosY.text = "Pos Y: " + pos.y.ToString("F2") + " m";
        if (textPosZ != null) textPosZ.text = "Pos Z: " + pos.z.ToString("F2") + " m";
        if (textVelX != null) textVelX.text = "Vel X: " + vel.x.ToString("F2") + " m/s";
        if (textVelY != null) textVelY.text = "Vel Y: " + vel.y.ToString("F2") + " m/s";
        if (textVelZ != null) textVelZ.text = "Vel Z: " + vel.z.ToString("F2") + " m/s";
        if (textAcel != null) textAcel.text = "Acel Y: " + acelY.ToString("F2") + " m/s²";
    }

    public void SetProjectile(GameObject projectile)
    {
        activeProjectile = projectile;
        tiempoVuelo = 0f;
        velocidadAnterior = Vector3.zero;
    }

    // Llamado desde ResetScene para limpiar el panel
    public void Reset()
    {
        activeProjectile = null;
        tiempoVuelo = 0f;
        velocidadAnterior = Vector3.zero;

        if (textTiempo != null) textTiempo.text = "Tiempo: 0.00 s";
        if (textPosX != null) textPosX.text = "Pos X: 0.00 m";
        if (textPosY != null) textPosY.text = "Pos Y: 0.00 m";
        if (textPosZ != null) textPosZ.text = "Pos Z: 0.00 m";
        if (textVelX != null) textVelX.text = "Vel X: 0.00 m/s";
        if (textVelY != null) textVelY.text = "Vel Y: 0.00 m/s";
        if (textVelZ != null) textVelZ.text = "Vel Z: 0.00 m/s";
        if (textAcel != null) textAcel.text = "Acel Y: 0.00 m/s²";
    }
}