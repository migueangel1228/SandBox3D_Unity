using UnityEngine;
using UnityEngine.UI;
using TMPro;

[ExecuteAlways]
public class UIPanelPolisher : MonoBehaviour
{
    [Header("Estilo del Panel de Fondo")]
    public Color backgroundColor = new Color(0.06f, 0.09f, 0.15f, 0.85f); // Dark Slate Blue (Semi-transparente)
    public bool addPanelBackground = true;

    [Header("Estilo de Tipografía")]
    public bool applyTextStyling = true;
    public Color headerColor = new Color(1f, 1f, 1f, 1f);
    public FontStyles defaultFontStyle = FontStyles.Bold;

    void Awake()
    {
        ApplyStyling();
    }

    [ContextMenu("Polir UI Ahora")]
    public void ApplyStyling()
    {
        // 1. Agregar o configurar Panel de Fondo Semi-transparente
        if (addPanelBackground)
        {
            Image bg = GetComponent<Image>();
            if (bg == null)
            {
                bg = gameObject.AddComponent<Image>();
            }
            
            bg.color = backgroundColor;
            bg.raycastTarget = false;
        }

        // 2. Dar estilo elegante a todos los TextMeshPro hijos
        if (applyTextStyling)
        {
            TextMeshProUGUI[] texts = GetComponentsInChildren<TextMeshProUGUI>(true);
            foreach (var txt in texts)
            {
                // Habilitar RichText para los colores de las variables
                txt.richText = true;

                // Si es un título/encabezado, darle estilo destacado
                if (txt.gameObject.name.ToLower().Contains("header") || 
                    txt.gameObject.name.ToLower().Contains("title") || 
                    txt.gameObject.name.ToLower().Contains("titulo"))
                {
                    txt.fontStyle = FontStyles.Bold | FontStyles.UpperCase;
                    txt.color = headerColor;
                }
            }
        }

        Debug.Log($"UI Polished en el panel: {gameObject.name}");
    }
}
