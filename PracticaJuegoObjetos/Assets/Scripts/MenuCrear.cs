using UnityEngine;

public class MenuCrear : IEstado
{

    private GameObject edificioCreado;
    private float distanciaMaxima = 100f;

    public void Entrar(MenuStateMachine menus)// Al entrar en el estado de crear edificio
    {
        menus.controlMenus.CerrarMenus();
        menus.controlMenus.menuCrear.SetActive(true);
        edificioCreado = null; // No hay ningún edificio creado al entrar
    }

    public void Ejecutar(MenuStateMachine menus)// Lógica del estado de crear edificio
    {
        if (edificioCreado == null) return; // Si no hay un edificio creado, no hacer nada
        if (Camera.main == null) return; // Si no hay una cámara principal, no hacer nada

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Crea un rayo desde la cámara hacia la posición del ratón

        //Raycast hacia el suelo para mover el edificio
        if (Physics.Raycast(ray, out RaycastHit hit, distanciaMaxima, menus.sueloMask))
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
            edificioCreado = null; // Resetea el edificio creado para permitir crear uno nuevo
        }

        if (Input.GetMouseButtonDown(1)) // Si se hace clic derecho
        {
            Object.Destroy(edificioCreado); // Destruye el edificio creado
            edificioCreado = null; // Resetea el edificio creado para permitir crear uno nuevo
        }
    }
    
    public void Salir(MenuStateMachine menus)// Al salir del estado de crear edificio
    {
        menus.controlMenus.menuCrear.SetActive(false);
    }

    public void SeleccionarEdificio(GameObject prefab)
    {
        if (edificioCreado == null) return; // Si ya hay un edificio creado, no hacer nada
        edificioCreado = Object.Instantiate(prefab); // Crea una instancia del prefab seleccionado
        edificioCreado.layer = LayerMask.NameToLayer("Editable"); // Cambia la capa del edificio para que sea editable
    }
}
