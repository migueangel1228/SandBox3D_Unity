using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(LineRenderer))]
public class VelocityVectorVisualizer : MonoBehaviour
{
    [Header("UI Sliders")]
    public Slider speedSlider;
    public Slider angleSlider;

    [Header("Configuración del Vector Vectorial")]
    public float scaleFactor = 0.1f; // Para escalar la flecha en la pantalla
    public Color vectorColor = Color.yellow;

    private LineRenderer lr;

    void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.useWorldSpace = true;
        lr.startWidth = 0.08f;
        lr.endWidth = 0.02f; // Apuntando como flecha
        
        if (lr.material == null || lr.material.name.Contains("Default"))
        {
            Shader shader = Shader.Find("Sprites/Default");
            if (shader == null) shader = Shader.Find("Hidden/Internal-Colored");
            if (shader != null) lr.material = new Material(shader);
        }

        lr.startColor = vectorColor;
        lr.endColor = vectorColor;
    }

    void Update()
    {
        if (speedSlider == null || angleSlider == null || lr == null) return;

        float speed = speedSlider.value;
        float angleRad = angleSlider.value * Mathf.Deg2Rad;

        // Calcular vector de velocidad inicial
        Vector3 dir = new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad), 0f);
        Vector3 startPos = transform.position;
        Vector3 endPos = startPos + dir * (speed * scaleFactor);

        lr.positionCount = 2;
        lr.SetPosition(0, startPos);
        lr.SetPosition(1, endPos);
    }
}
