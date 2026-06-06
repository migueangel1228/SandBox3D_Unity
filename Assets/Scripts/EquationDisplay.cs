using UnityEngine;
using TMPro;

public class EquationDisplay : MonoBehaviour
{
    [Header("Textos del panel de ecuaciones")]
    public TextMeshProUGUI textVectorial;
    public TextMeshProUGUI textComponentes;
    public TextMeshProUGUI textValores;

    private float v0x, v0y, v0z;
    private float x0, y0, z0;
    private bool lanzado = false;

    void Update()
    {
        if (textVectorial != null)
            textVectorial.text = "r(t)  =  r0  +  v0 * t  +  (1/2) * a * t^2";

        if (textComponentes != null)
            textComponentes.text =
                "x(t) = x0 + v0x*t          " +
                "y(t) = y0 + v0y*t - 4.905*t^2          " +
                "z(t) = z0 + v0z*t";

        if (!lanzado && textValores != null)
            textValores.text = "[ Configura y lanza para ver los valores reales ]";
    }

    public void SetLaunchData(Vector3 position, Vector3 velocity, float m)
    {
        x0 = position.x; y0 = position.y; z0 = position.z;
        v0x = velocity.x; v0y = velocity.y; v0z = velocity.z;
        lanzado = true;
        ActualizarEcuacionValores();
    }

    void ActualizarEcuacionValores()
    {
        if (textValores == null) return;

        string signoVx = v0x >= 0 ? "+ " : "- ";
        string signoVy = v0y >= 0 ? "+ " : "- ";
        string signoVz = v0z >= 0 ? "+ " : "- ";

        string eqX = $"x(t) = {x0:F2} {signoVx}{Mathf.Abs(v0x):F2} * t";
        string eqY = $"y(t) = {y0:F2} {signoVy}{Mathf.Abs(v0y):F2} * t  -  4.905 * t^2";
        string eqZ = $"z(t) = {z0:F2} {signoVz}{Mathf.Abs(v0z):F2} * t";

        textValores.text = eqX + "\n" + eqY + "\n" + eqZ;
    }
}