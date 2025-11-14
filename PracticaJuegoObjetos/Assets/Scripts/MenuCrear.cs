using UnityEngine;

public class MenuCrear : IEstado
{
    [SerializeField]
    private GameObject menuCrear;

    private GameObject edificioCreado;
    private float distanciaMaxima = 100f;

    public void Entrar(MenuStateMachine menus)
    {
        menus.menuCrear.SetActive(true);
    }

    public void Ejecutar(MenuStateMachine menus)
    {
        if (edificioCreado == null) return; // Si no hay un edificio creado, no hacer nada
        if (Camera.main == null) return; // Si no hay una cámara principal, no hacer nada

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Crea un rayo desde la cámara hacia la posición del ratón

        if (Physics.Raycast(ray, out RaycastHit hit, distanciaMaxima, menus.sueloMask)) // Si el rayo colisiona con el suelo
        {
            edificioCreado.transform.position = hit.point; // Mueve el edificio a la posición del punto de colisión
            Debug.DrawLine(ray.origin, hit.point, Color.green); // Dibuja una línea verde si colisiona
        }
        else
        {
            Debug.DrawLine(ray.origin, ray.direction * distanciaMaxima, Color.red); // Dibuja una línea roja si no colisiona
        }

        if (Input.GetMouseButtonDown(0)) // Si se hace clic izquierdo
        {
            edificioCreado.layer = 0;// Cambia la capa del edificio para que ya no sea editable       
        }

        if (Input.GetMouseButtonDown(1)) // Si se hace clic derecho
        {
            Object.Destroy(edificioCreado); // Destruye el edificio creado
        }
    }

    public void Salir(MenuStateMachine menus)
    {
        menus.menuCrear.SetActive(false);
    }
}
