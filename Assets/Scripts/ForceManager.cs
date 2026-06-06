using UnityEngine;

public class ForceManager : MonoBehaviour
{
    [Header("Proyectil activo")]
    public GameObject activeProjectile;

    [Header("Configuración de fuerzas")]
    public float fuerzaViento = 0f;       // en X (positivo = derecha)
    public bool resistenciaActiva = false;
    public float coeficienteArrastre = 0.5f; // cuánto frena el aire

    private Rigidbody rb;

    void FixedUpdate()
    {
        // Solo aplicar si hay proyectil activo con Rigidbody
        if (activeProjectile == null) return;
        if (rb == null) rb = activeProjectile.GetComponent<Rigidbody>();
        if (rb == null) return;

        // Fuerza de viento (constante en X)
        if (fuerzaViento != 0f)
        {
            Vector3 viento = new Vector3(fuerzaViento, 0f, 0f);
            rb.AddForce(viento, ForceMode.Force);
        }

        // Resistencia del aire (opuesta a la velocidad, proporcional a v²)
        if (resistenciaActiva)
        {
            Vector3 velocidad = rb.linearVelocity;
            float magnitud = velocidad.magnitude;

            if (magnitud > 0.01f)
            {
                // F_arrastre = -k * v² * dirección
                Vector3 fuerzaArrastre = -coeficienteArrastre * magnitud * velocidad;
                rb.AddForce(fuerzaArrastre, ForceMode.Force);
            }
        }
    }

    // Llamado desde LaunchController al lanzar
    public void SetProjectile(GameObject projectile)
    {
        activeProjectile = projectile;
        rb = null; // resetear para que FixedUpdate lo obtenga fresco
    }

    // Llamado desde el Slider de viento
    public void SetViento(float valor)
    {
        fuerzaViento = valor;
    }

    // Llamado desde el Toggle de resistencia
    public void SetResistencia(bool activo)
    {
        resistenciaActiva = activo;
    }

    // Llamado desde Reset
    public void Reset()
    {
        activeProjectile = null;
        rb = null;
    }
}