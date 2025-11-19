using UnityEngine;

public class MenuEliminar : IEstado
{
    private MenuStateMachine menus;
    private string tagEditable = "Editable";


    public void Entrar(MenuStateMachine menus)
    {
        menus.controlMenus.CerrarMenus();
        menus.controlMenus.menuEliminar.SetActive(true);
        
    }

    public void Ejecutar(MenuStateMachine menus)
    {
        if (Camera.main == null) return; // Si no hay una cámara principal, no hacer nada        

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Crea un rayo desde la cámara hacia la posición del ratón
        RaycastHit hit;// Variable para almacenar la información del rayo

        if (Input.GetMouseButtonDown(0)) // Si se hace clic izquierdo
        {           
            if (Physics.Raycast(ray, out hit, 100f)) // Si el rayo colisiona con un objeto editable
            {
                if (hit.collider.CompareTag(tagEditable)) // Verifica si el objeto tiene la etiqueta "Editable"
                {
                    GameObject objetoEliminar = hit.collider.gameObject;// Obtiene el objeto seleccionado
                    Object.Destroy(objetoEliminar); // Obtiene el objeto seleccionado                    
                }
            }
        }
    }

    public void Salir(MenuStateMachine menus)
    {
        menus.controlMenus.menuEliminar.SetActive(false);
    }
}
