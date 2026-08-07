using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(LineRenderer))]
public class TrajectoryRecorder : MonoBehaviour
{
    [Header("Configuración de la línea")]
    public Color lineColor = Color.cyan;
    public float lineWidth = 0.05f;
    public float recordInterval = 0.02f; // cada cuántos segundos guarda un punto

    [Header("Juice")]
    public GameObject impactParticlePrefab;

    private LineRenderer lineRenderer;
    private List<Vector3> points = new List<Vector3>();
    private float timer = 0f;
    private bool recording = true;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

        // Configurar apariencia de la línea
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;
        lineRenderer.startColor = lineColor;
        lineRenderer.endColor = lineColor;
        lineRenderer.useWorldSpace = true;

        // Material simple sin textura
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));

        // Registrar el punto inicial
        points.Add(transform.position);
        UpdateLine();
    }

    void Update()
    {
        if (!recording) return;

        timer += Time.deltaTime;

        // Guardar posición cada recordInterval segundos
        if (timer >= recordInterval)
        {
            timer = 0f;
            points.Add(transform.position);
            UpdateLine();
        }
    }

    void UpdateLine()
    {
        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPositions(points.ToArray());
    }

    // Detener grabación cuando toca el suelo
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            points.Add(transform.position); // punto final exacto
            UpdateLine();
            recording = false;

            if (impactParticlePrefab != null)
            {
                Instantiate(impactParticlePrefab, transform.position, Quaternion.identity);
            }
        }
    }
}