using UnityEngine;

public class MenuMover : IEstado
{
    private MenuStateMachine menus;
    private string tagEditable = "Editable";

    public void Entrar(MenuStateMachine menus)
    {
        menus.menuMover.SetActive(true);
    }

    public void Ejecutar(MenuStateMachine menus)
    {
        if (Camera.main != null) return; // Si no hay una cámara principal, no hacer nada
        if (menus == null) return; // Si no hay un menú, no hacer nada

        if(Input.GetMouseButtonDown(0)) // Si se hace clic izquierdo
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Crea un rayo desde la cámara hacia la posición del ratón
            
            if (Physics.Raycast(ray, out RaycastHit hit, 100f)) // Si el rayo colisiona con un objeto editable
            {
                if (hit.collider.CompareTag(tagEditable)) // Verifica si el objeto tiene la etiqueta "Editable"
                {
                    GameObject objetoSeleccionado = hit.collider.gameObject; // Obtiene el objeto seleccionado
                    objetoSeleccionado.transform.position = hit.point; // Mueve el objeto a la nueva posición                   
                }
            }                                                                
        }
    }

    public void Salir(MenuStateMachine menus)
    {
        menus.menuMover.SetActive(false);
    }
}
