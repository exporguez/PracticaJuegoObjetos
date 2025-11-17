using UnityEngine;

public class MenuMover : IEstado
{
    private MenuStateMachine menus;
    private string tagEditable = "Editable";

    private GameObject objetoSeleccionado;
    private float distanciaMaxima = 100f;

    public void Entrar(MenuStateMachine menus)
    {
        menus.controlMenus.CerrarMenus();
        menus.controlMenus.menuMover.SetActive(true);
        objetoSeleccionado = null;// No hay ningún objeto seleccionado al entrar
    }

    public void Ejecutar(MenuStateMachine menus)
    {
        if (Camera.main == null) return; // Si no hay una cámara principal, no hacer nada        

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Crea un rayo desde la cámara hacia la posición del ratón
        RaycastHit hit;// Variable para almacenar la información del rayo

        if (objetoSeleccionado == null && Input.GetMouseButtonDown(0)) // Si se hace clic izquierdo y no hay ningún objeto seleccionado
        {                   
            if (Physics.Raycast(ray, out hit, distanciaMaxima)) // Si el rayo colisiona con un objeto editable
            {
                if (hit.collider.CompareTag(tagEditable)) // Verifica si el objeto tiene la etiqueta "Editable"
                {
                    objetoSeleccionado = hit.collider.gameObject; // Obtiene el objeto seleccionado                                   
                }
            }                                                                
        }

        if (objetoSeleccionado != null)
        {                      
            if (Physics.Raycast(ray, out hit, distanciaMaxima, menus.sueloMask)) // Si el rayo colisiona con el suelo
            {
                objetoSeleccionado.transform.position = hit.point; // Mueve el objeto seleccionado a la posición del ratón en el suelo
            }

            if (Input.GetMouseButtonDown(0)) // Si se hace clic izquierdo
            {
                objetoSeleccionado = null;// Deselecciona el objeto
            }
        }
    }

    public void Salir(MenuStateMachine menus)
    {
        menus.controlMenus.menuMover.SetActive(false);
    }
}
