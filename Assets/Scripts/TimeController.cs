using UnityEngine;

public class TimeController : MonoBehaviour
{
    // Guarda el fixedDeltaTime original para restaurarlo
    private float defaultFixedDeltaTime;

    void Awake()
    {
        defaultFixedDeltaTime = Time.fixedDeltaTime;
    }

    // ▶ Tiempo normal
    public void Resume()
    {
        SetTimeScale(1f);
        Debug.Log("Tiempo: NORMAL (1x)");
    }

    // ⏸ Pausa total
    public void Pause()
    {
        SetTimeScale(0f);
        Debug.Log("Tiempo: PAUSA (0x)");
    }

    // 🐢 Cámara lenta
    public void SlowMotion()
    {
        SetTimeScale(0.2f);
        Debug.Log("Tiempo: SLOW MOTION (0.2x)");
    }

    // Control seguro — ajusta física junto con el tiempo
    private void SetTimeScale(float scale)
    {
        Time.timeScale = scale;

        // Ajustar fixedDeltaTime para que la física no se rompa
        if (scale > 0f)
            Time.fixedDeltaTime = defaultFixedDeltaTime * scale;
        else
            Time.fixedDeltaTime = defaultFixedDeltaTime;
    }
}