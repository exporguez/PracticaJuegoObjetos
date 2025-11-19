using UnityEngine;

public class MenuRotar : IEstado
{
    private GameObject objetoSeleccionado;
    private string tagEditable = "Editable";
    private float velocidadRotacion = 500f;
    private float distanciaMaxima = 300f;

    public void Entrar(MenuStateMachine menus)
    {
        menus.controlMenus.CerrarMenus();
        menus.controlMenus.menuRotar.SetActive(true);
        objetoSeleccionado = null;

    }

    public void Ejecutar(MenuStateMachine menus)
    {
        if (Camera.main == null) return; // Si no hay una cámara principal, no hacer nada
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);// Crea un rayo desde la cámara hacia la posición del ratón
        RaycastHit hit;// Variable para almacenar la información del punto de colisión
        
        if (objetoSeleccionado == null && Input.GetMouseButtonDown(0)) // Si se hace clic izquierdo y no hay ningún objeto seleccionado
        {
            if (Physics.Raycast(ray, out hit, distanciaMaxima))// Si el rayo colisiona con un objeto editable
            {     
                if (hit.collider.CompareTag(tagEditable)) // Verifica si el objeto tiene la etiqueta "Editable"
                {
                    objetoSeleccionado = hit.collider.gameObject; // Obtiene el objeto seleccionado                                   
                }
            }
        }

        if (objetoSeleccionado != null) // Si hay un objeto seleccionado
        {
            float rotX = Input.GetAxis("Mouse X") * velocidadRotacion * Time.deltaTime; // Obtiene la rotación en el eje X basada en el movimiento del ratón
            objetoSeleccionado.transform.Rotate(0f, -rotX, 0f); // Rota el objeto alrededor del eje Y (arriba) en el espacio mundial

            if (Input.GetMouseButtonDown(1))// Si se hace clic derecho
            {
                objetoSeleccionado = null; // Deselecciona el objeto al hacer clic izquierdo
            }
        }
    }

   
    public void Salir(MenuStateMachine menus)
    {
        menus.controlMenus.menuRotar.SetActive(false);
    }
}
