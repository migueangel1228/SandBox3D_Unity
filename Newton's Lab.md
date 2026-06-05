# Newton's Lab
## Laboratorio interactivo de física educativa en Unity

## 1. Resumen del proyecto

Newton's Lab es un sandbox 3D educativo desarrollado en Unity donde el usuario puede lanzar objetos, activar y desactivar fuerzas externas, observar trayectorias, leer variables físicas en tiempo real y ver ecuaciones físicas representadas de forma visual e interactiva.

La idea principal es que el proyecto no se sienta como una clase tradicional ni como una simulación plana. En cambio, debe parecer un laboratorio gamificado donde el estudiante experimenta con las leyes de Newton y la cinemática viendo directamente cómo cambian las ecuaciones, la trayectoria y los vectores.

El proyecto prioriza:
- Claridad académica.
- Rapidez de implementación.
- Demostración visual.
- Interacción simple.
- MVP funcional antes que complejidad gráfica.

---

## 2. Objetivo general

Construir un laboratorio interactivo en Unity que permita experimentar con movimientos físicos en 3D para demostrar:

- Cinemática básica.
- Ley de inercia.
- Segunda ley de Newton.
- Acción y reacción.
- Efecto de fuerzas externas.
- Relación entre ecuaciones, vectores y comportamiento real.

---

## 3. Visión del proyecto

La simulación debe responder a esta lógica:

1. El usuario configura un experimento.
2. El sistema ejecuta el movimiento.
3. La UI muestra números, vectores y ecuaciones.
4. El usuario activa o desactiva fuerzas externas.
5. La trayectoria y la aceleración cambian en vivo.
6. El aprendizaje ocurre por observación y prueba.

La experiencia debe sentirse como un “laboratorio de Newton” y no como un formulario matemático.

---

## 4. No negociables

Estos elementos deben existir sí o sí en la versión final del MVP:

- Lanzamiento de objetos con Rigidbody.
- Visualización de trayectoria con LineRenderer.
- Panel con variables físicas en tiempo real.
- Ecuaciones visibles y actualizadas con valores reales.
- Modos para activar o desactivar fuerzas externas.
- Pausa y cámara lenta.
- Botón de reinicio.
- Interfaz simple pero vistosa.
- Demostración clara de al menos la primera y segunda ley de Newton.

---

## 5. Qué NO hacer al inicio

Para mantener el proyecto rápido y realista, no se debe empezar con:

- Menús complejos.
- Animaciones avanzadas.
- Gráficos realistas.
- Inventarios de objetos sofisticados.
- Física personalizada desde cero.
- Mecánicas innecesarias.
- Demasiados tipos de objetos lanzables.

La prioridad es que funcione, se entienda y se vea bien.

---

## 6. Estructura general del laboratorio

### Escenas
- `MainMenuScene`: menú principal.
- `SandboxScene`: escena principal del laboratorio.
- `DemoScene`: escena preparada para exposición.

### Objetos principales
- `GameManager`: coordina estados generales.
- `LaunchPoint`: punto de lanzamiento.
- `ProjectilePrefab`: objeto físico lanzable.
- `Canvas`: interfaz del usuario.
- `TrajectoryObject`: objeto visual de trayectoria.
- `ForceSystem`: gestiona fuerzas externas.
- `EquationPanel`: muestra ecuaciones en pantalla.
- `TimeController`: pausa y cámara lenta.

### Scripts principales
- `LaunchController.cs`
- `PhysicsDataTracker.cs`
- `TrajectoryRecorder.cs`
- `EquationDisplay.cs`
- `ForceManager.cs`
- `TimeController.cs`
- `UIController.cs`
- `ModeController.cs`

---

## 7. Enfoque gamificado

El proyecto se organiza como un laboratorio con modos experimentales. Cada modo representa un concepto físico de forma visual.

### Modo 1: Inercia pura
Demuestra la primera ley de Newton.

- Sin fuerzas externas activas.
- El objeto conserva movimiento constante.
- Se observa trayectoria recta.
- La UI indica que la fuerza neta es cero.
- Sirve para mostrar que sin fuerza no cambia la velocidad.

### Modo 2: Fuerza y aceleración
Demuestra la segunda ley de Newton.

- El usuario aplica una fuerza configurable.
- Se modifica la masa del objeto.
- Se observa cómo cambia la aceleración.
- La ecuación \(F = ma\) se actualiza en pantalla.
- Se compara el comportamiento entre masas distintas.

### Modo 3: Acción y reacción
Demuestra la tercera ley de Newton.

- Dos cuerpos interactúan.
- Se visualizan fuerzas opuestas.
- Las flechas muestran dirección y magnitud.
- Es ideal para una demostración visual.

---

## 8. Fase 0: Base técnica

### Objetivo
Crear una escena limpia, estable y lista para pruebas físicas.

### Qué incluye
- Escena 3D.
- Piso con collider.
- Cámara fija.
- Luz direccional.
- Objeto lanzable simple.
- Canvas básico.

### Resultado esperado
Una escena funcional donde ya se pueda ver un objeto físico interactuando con el entorno.

### Entregable
- Proyecto Unity creado.
- Escena base funcional.
- Cámara y luz colocadas.
- Piso listo para colisiones.

---

## 9. Fase 1: Lanzamiento básico

### Objetivo
Permitir que el usuario lance un objeto físico.

### Qué incluye
- Prefab de esfera o cubo.
- Rigidbody y Collider.
- Punto de lanzamiento.
- Parámetros iniciales.
- Botón de lanzar.
- Botón de reiniciar.

### Variables iniciales
- Velocidad inicial.
- Ángulo de lanzamiento.
- Dirección horizontal.
- Masa.

### Resultado esperado
El usuario presiona lanzar y el objeto sale con velocidad inicial visible.

### Entregable
- Lanzamiento funcional.
- Colisiones correctas con el piso.
- Reinicio de la escena u objeto.

---

## 10. Fase 2: UI de entrada

### Objetivo
Permitir configurar el experimento sin tocar código.

### Qué incluye
- Slider de velocidad.
- Slider de ángulo.
- Slider de dirección.
- Slider de masa.
- Botón de aplicar cambios.
- Botón de lanzar.

### Resultado esperado
El usuario puede modificar condiciones físicas antes del experimento.

### Entregable
- Interfaz básica operativa.
- Valores visibles y editables.
- Configuración lista para pruebas.

---

## 11. Fase 3: Variables físicas en pantalla

### Objetivo
Convertir la simulación en una herramienta de análisis.

### Variables a mostrar
- Tiempo.
- Posición X, Y, Z.
- Velocidad X, Y, Z.
- Rapidez total.
- Aceleración X, Y, Z.
- Masa.
- Altura máxima.
- Distancia recorrida.
- Estado del objeto.

### Resultado esperado
La pantalla ya no solo muestra el objeto, sino datos físicos útiles para entender lo que ocurre.

### Entregable
- HUD científico.
- Variables actualizándose en tiempo real.
- Lectura clara para exposición.

---

## 12. Fase 4: Trayectoria visual

### Objetivo
Representar el movimiento de forma clara y agradable.

### Qué incluye
- Registro de posiciones.
- Dibujo con LineRenderer.
- Punto de inicio.
- Punto de impacto.
- Punto de altura máxima.

### Prioridad
Primero se implementa la trayectoria real, porque es más fácil, estable y fiel a la simulación.

### Resultado esperado
El usuario ve la curva recorrida por el objeto y entiende el movimiento completo.

### Entregable
- Línea de trayectoria funcional.
- Visualización clara del recorrido.
- Marcadores básicos.

---

## 13. Fase 5: Ecuaciones vivas

### Objetivo
Mostrar la matemática que explica el movimiento.

### Qué debe verse
- Ecuación vectorial.
- Ecuaciones por componentes.
- Ecuación con valores reales.

### Ejemplo
- \(\vec{r}(t) = \vec{r_0} + \vec{v_0}t + \frac{1}{2}\vec{a}t^2\)
- \(x(t) = x_0 + v_{0x}t + \frac{1}{2}a_xt^2\)
- \(y(t) = y_0 + v_{0y}t + \frac{1}{2}a_yt^2\)

### Resultado esperado
La ecuación cambia en pantalla según el lanzamiento real.

### Entregable
- Panel de ecuaciones.
- Valores dinámicos.
- Presentación académica fuerte.

---

## 14. Fase 6: Fuerzas externas

### Objetivo
Demostrar cómo cambian los movimientos al introducir fuerzas externas.

### Qué incluir
- Gravedad activable/desactivable.
- Viento lateral.
- Fricción simplificada.
- Fuerza aplicada manualmente.

### Uso educativo
- Sin fuerzas: inercia.
- Con fuerzas: aceleración.
- Con varias fuerzas: cambio de trayectoria.
- Con objetos diferentes: comparación de masa y respuesta.

### Resultado esperado
El usuario puede “romper” o modificar el experimento y ver el efecto en tiempo real.

### Entregable
- Sistema de toggles.
- Reacción visible del movimiento.
- Ecuaciones ajustadas al estado físico.

---

## 15. Fase 7: Tiempo

### Objetivo
Permitir observar el fenómeno con más claridad.

### Qué incluir
- Pausa.
- Reanudar.
- Cámara lenta.
- Slider de velocidad del tiempo.

### Resultado esperado
El usuario puede detener el experimento o verlo más despacio para analizarlo.

### Entregable
- Control estable del `Time.timeScale`.
- Ajuste de `fixedDeltaTime`.
- Interfaz de tiempo funcional.

---

## 16. Fase 8: Pulido visual

### Objetivo
Hacer que el proyecto se vea más vistoso sin complicarlo demasiado.

### Qué incluir
- Paneles limpios.
- Colores por tipo de dato.
- Iconos simples.
- Mejora de legibilidad.
- Fondo académico agradable.
- Vectores de colores.

### Resultado esperado
El laboratorio se ve profesional sin dejar de ser simple.

### Entregable
- UI más ordenada.
- Mejor jerarquía visual.
- Presentación lista para profesor.

---

## 17. Orden recomendado de construcción

1. Crear escena base.
2. Crear piso, luz y cámara.
3. Crear objeto lanzable.
4. Agregar Rigidbody y Collider.
5. Programar lanzamiento básico.
6. Crear UI de parámetros.
7. Mostrar variables físicas.
8. Dibujar trayectoria real.
9. Mostrar ecuaciones.
10. Agregar fuerzas externas.
11. Agregar pausa y slow motion.
12. Pulir interfaz.
13. Preparar demo final.

---

## 18. MVP final recomendado

La versión mínima viable ideal debe incluir:

- Una escena 3D simple.
- Un objeto lanzable.
- Configuración de velocidad, ángulo, dirección y masa.
- Trayectoria real visible.
- Variables físicas en pantalla.
- Ecuaciones del movimiento con valores reales.
- Activación y desactivación de fuerzas externas.
- Pausa y cámara lenta.
- Botón de reinicio.

---

## 19. Entregas por revisión

### Revisión 1
- Escena básica.
- Objeto lanzable.
- Física funcionando.
- Colisión con piso.

### Revisión 2
- HUD de variables.
- Parámetros configurables.
- Lectura física en tiempo real.

### Revisión 3
- Trayectoria.
- Ecuaciones visibles.
- Fuerzas externas simples.

### Revisión 4
- Tiempo.
- Pulido visual.
- Demo final.

---

## 20. Riesgos del proyecto

### Riesgo: alcance demasiado grande
Querer meter muchas ideas y no terminar ninguna.

### Solución
Mantener el MVP pequeño y funcional.

### Riesgo: perder tiempo en gráficos
Demasiado detalle visual antes de tener física lista.

### Solución
Usar primitivas simples y UI clara.

### Riesgo: mezcla confusa entre teoría y simulación
No saber qué está calculando Unity y qué está mostrando la UI.

### Solución
Unity simula, la interfaz explica.

### Riesgo: tiempos inestables
La pausa o cámara lenta puede romper la simulación.

### Solución
Ajustar `Time.timeScale` y `Time.fixedDeltaTime`.

---

## 21. Estructura ideal para IA o documentación técnica

Si una IA debe leer este proyecto, debe entenderlo con esta jerarquía:

1. Objetivo general.
2. No negociables.
3. Fases del proyecto.
4. Escenas y objetos.
5. Scripts principales.
6. Flujo del experimento.
7. Variables físicas.
8. Trayectoria.
9. Ecuaciones.
10. Fuerzas externas.
11. Tiempo.
12. Pulido visual.
13. Riesgos.
14. MVP final.

---

## 22. Conclusión del plan

Newton's Lab debe ser un laboratorio interactivo, visual y académico. Su fortaleza no está en gráficos complejos, sino en permitir que el estudiante vea, pruebe y modifique fenómenos físicos mientras las ecuaciones se reflejan en pantalla.

El proyecto debe construirse por pasos pequeños, testeables y demostrables. Primero debe funcionar. Luego debe verse bien. Después debe enseñar mejor.