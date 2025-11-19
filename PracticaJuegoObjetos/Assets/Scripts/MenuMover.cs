using UnityEngine;

public class MenuMover : IEstado
{
    private float distanciaMaxima = 300f;// Distancia máxima del rayo
    private GameObject objetoSeleccionado;// Objeto que ha sido seleccionado para mover
    private string tagEditable = "Editable";// Etiqueta para los objetos que se pueden mover
    private LayerMask sueloMask = LayerMask.GetMask("Suelo");// Capa del suelo


    public void Entrar(MenuStateMachine menus)
    {
        menus.controlMenus.CerrarMenus();
        menus.controlMenus.menuMover.SetActive(true);
        objetoSeleccionado = null;// No hay ningún objeto seleccionado al entrar
    }

    public void Ejecutar(MenuStateMachine menus)
    {
        if (Camera.main == null) return; // Si no hay una cámara principal, no hacer nada

        if (objetoSeleccionado != null) // Si se hace clic izquierdo y no hay ningún objeto seleccionado
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Crea un rayo desde la cámara hacia la posición del ratón
            RaycastHit hit;// Variable para almacenar la información del rayo

            if (Physics.Raycast(ray, out hit, distanciaMaxima, sueloMask)) // Si el rayo colisiona con un objeto editable
            {
                Vector3 nuevaPosicion = hit.point; // Obtiene la posición del punto de colisión
                nuevaPosicion.y += objetoSeleccionado.transform.localScale.y / 2f; // Ajusta la posición Y para que el objeto quede sobre el suelo
                objetoSeleccionado.transform.position = nuevaPosicion; // Mueve el objeto seleccionado a la nueva posición
            }

            if (Input.GetMouseButtonDown(0)) // Si se hace clic izquierdo
            {
                objetoSeleccionado.layer = LayerMask.NameToLayer("Default"); // Restaura la capa del objeto seleccionado
                objetoSeleccionado = null; // Deselecciona el objeto al hacer clic izquierdo
            }
            return; // Sale del método para evitar seleccionar otro objeto mientras se mueve uno
        }


        if (Input.GetMouseButtonDown(0)) // Si se hace clic izquierdo
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Crea un rayo desde la cámara hacia la posición del ratón
            RaycastHit hit;// Variable para almacenar la información del rayo
            
            if (Physics.Raycast(ray, out hit, distanciaMaxima)) // Si el rayo colisiona con un objeto editable
            {
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Default")) // Si el objeto tiene la etiqueta "Editable"
                {
                    objetoSeleccionado = hit.collider.gameObject; // Selecciona el objeto
                    objetoSeleccionado.layer = LayerMask.NameToLayer("Ignore Raycast"); // Cambia la capa del objeto para ignorar futuros rayos
                }
            }
        }
    }

    public void Salir(MenuStateMachine menus)
    {
        menus.controlMenus.menuMover.SetActive(false);
    }
}
