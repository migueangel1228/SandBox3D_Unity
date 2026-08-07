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

    [Header("Textos adicionales de análisis")]
    public TextMeshProUGUI textMaxHeight;
    public TextMeshProUGUI textMaxDistance;

    private Rigidbody rb;
    private float tiempoVuelo = 0f;
    private Vector3 velocidadAnterior;
    private float maxHeight = 0f;
    private float maxDistance = 0f;
    private Vector3 startPosition;

    void OnEnable()
    {
        LaunchController.OnProjectileLaunched += ManejarLanzamiento;
        LaunchController.OnSceneReset += Reset;
    }

    void OnDisable()
    {
        LaunchController.OnProjectileLaunched -= ManejarLanzamiento;
        LaunchController.OnSceneReset -= Reset;
    }

    void Update()
    {
        if (activeProjectile == null) return;

        rb = activeProjectile.GetComponent<Rigidbody>();
        if (rb == null) return;

        tiempoVuelo += Time.deltaTime;

        Vector3 pos = activeProjectile.transform.position;
        Vector3 vel = rb.linearVelocity;

        // Registro de Máximos
        if (pos.y > maxHeight) maxHeight = pos.y;
        float currentDistance = Mathf.Abs(pos.x - startPosition.x);
        if (currentDistance > maxDistance) maxDistance = currentDistance;

        // Fix NaN: solo calcular aceleración si deltaTime > 0
        float acelY = 0f;
        if (Time.deltaTime > 0f)
        {
            Vector3 acel = (vel - velocidadAnterior) / Time.deltaTime;
            acelY = acel.y;
        }
        velocidadAnterior = vel;

        // Formato con RichText (Colores académicos)
        if (textTiempo != null) textTiempo.text = $"Tiempo: <color=#50E3C2>{tiempoVuelo:F2} s</color>";
        if (textPosX != null) textPosX.text = $"Pos X: <color=#4A90E2>{pos.x:F2} m</color>";
        if (textPosY != null) textPosY.text = $"Pos Y: <color=#4A90E2>{pos.y:F2} m</color>";
        if (textPosZ != null) textPosZ.text = $"Pos Z: <color=#4A90E2>{pos.z:F2} m</color>";
        if (textVelX != null) textVelX.text = $"Vel X: <color=#F5A623>{vel.x:F2} m/s</color>";
        if (textVelY != null) textVelY.text = $"Vel Y: <color=#F5A623>{vel.y:F2} m/s</color>";
        if (textVelZ != null) textVelZ.text = $"Vel Z: <color=#F5A623>{vel.z:F2} m/s</color>";
        if (textAcel != null) textAcel.text = $"Acel Y: <color=#E74C3C>{acelY:F2} m/s²</color>";
        
        if (textMaxHeight != null) textMaxHeight.text = $"Alt. Máx: <color=#B8E986>{maxHeight:F2} m</color>";
        if (textMaxDistance != null) textMaxDistance.text = $"Alcance: <color=#B8E986>{maxDistance:F2} m</color>";
    }

    void ManejarLanzamiento(GameObject projectile, Vector3 velocity, float mass)
    {
        activeProjectile = projectile;
        tiempoVuelo = 0f;
        velocidadAnterior = Vector3.zero;
        startPosition = projectile.transform.position;
        maxHeight = startPosition.y;
        maxDistance = 0f;
    }

    public void Reset()
    {
        activeProjectile = null;
        tiempoVuelo = 0f;
        velocidadAnterior = Vector3.zero;
        maxHeight = 0f;
        maxDistance = 0f;

        if (textTiempo != null) textTiempo.text = "Tiempo: <color=#50E3C2>0.00 s</color>";
        if (textPosX != null) textPosX.text = "Pos X: <color=#4A90E2>0.00 m</color>";
        if (textPosY != null) textPosY.text = "Pos Y: <color=#4A90E2>0.00 m</color>";
        if (textPosZ != null) textPosZ.text = "Pos Z: <color=#4A90E2>0.00 m</color>";
        if (textVelX != null) textVelX.text = "Vel X: <color=#F5A623>0.00 m/s</color>";
        if (textVelY != null) textVelY.text = "Vel Y: <color=#F5A623>0.00 m/s</color>";
        if (textVelZ != null) textVelZ.text = "Vel Z: <color=#F5A623>0.00 m/s</color>";
        if (textAcel != null) textAcel.text = "Acel Y: <color=#E74C3C>0.00 m/s²</color>";
        if (textMaxHeight != null) textMaxHeight.text = "Alt. Máx: <color=#B8E986>0.00 m</color>";
        if (textMaxDistance != null) textMaxDistance.text = "Alcance: <color=#B8E986>0.00 m</color>";
    }
}