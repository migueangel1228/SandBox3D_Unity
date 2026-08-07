using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(LineRenderer))]
public class TrajectoryPredictor : MonoBehaviour
{
    [Header("Punto de Lanzamiento (Opcional)")]
    public Transform launchPoint;

    [Header("UI Sliders")]
    public Slider speedSlider;
    public Slider angleSlider;
    public Slider massSlider;
    
    [Header("Opcional")]
    public Slider windSlider;
    
    [Header("Configuración de línea")]
    public int resolution = 30; // Puntos a calcular
    public float timeStep = 0.1f;
    public float lineWidth = 0.1f;
    public Color lineColor = new Color(0f, 1f, 1f, 0.8f); // Cyan semi-transparente
    
    private LineRenderer lr;
    
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.enabled = true;
        lr.useWorldSpace = true;
        
        // Asignar material si no tiene uno
        if (lr.material == null || lr.material.name.Contains("Default"))
        {
            Shader shader = Shader.Find("Sprites/Default");
            if (shader == null) shader = Shader.Find("Hidden/Internal-Colored");
            if (shader != null) lr.material = new Material(shader);
        }
        
        lr.startWidth = lineWidth;
        lr.endWidth = lineWidth;
        lr.startColor = lineColor;
        lr.endColor = lineColor;
        
        // Suscribirse a cambios en los sliders
        if (speedSlider != null) speedSlider.onValueChanged.AddListener(_ => DrawPrediction());
        if (angleSlider != null) angleSlider.onValueChanged.AddListener(_ => DrawPrediction());
        if (massSlider != null) massSlider.onValueChanged.AddListener(_ => DrawPrediction());
        if (windSlider != null) windSlider.onValueChanged.AddListener(_ => DrawPrediction());
        
        DrawPrediction();
    }

    void Update()
    {
        DrawPrediction();
    }

    void DrawPrediction()
    {
        if (speedSlider == null || angleSlider == null || lr == null) return;
        
        float speed = speedSlider.value;
        float angleRad = angleSlider.value * Mathf.Deg2Rad;
        
        Vector3 vel = new Vector3(Mathf.Cos(angleRad) * speed, Mathf.Sin(angleRad) * speed, 0);
        Vector3 grav = Physics.gravity;
        
        if (windSlider != null)
        {
            float windAcc = windSlider.value;
            if (massSlider != null && massSlider.value > 0)
                windAcc /= massSlider.value;
            grav += new Vector3(windAcc, 0, 0);
        }

        lr.positionCount = resolution;
        
        // Usar launchPoint asignado o la posición de este GameObject
        Vector3 startPos = launchPoint != null ? launchPoint.position : transform.position;

        int validPoints = resolution;
        for (int i = 0; i < resolution; i++)
        {
            float t = i * timeStep;
            // Ecuación del movimiento: r = r0 + v0*t + 1/2*a*t^2
            Vector3 point = startPos + vel * t + 0.5f * grav * t * t;
            
            lr.SetPosition(i, point);
            
            // Solo romper por suelo a partir del segundo punto para evitar positionCount < 2
            if (i > 0 && point.y < 0) 
            { 
                validPoints = i + 1; 
                break; 
            }
        }

        lr.positionCount = validPoints;
    }
}
