using UnityEngine;

public class MenuEscalar : IEstado
{
    private GameObject objetoSeleccionado;
    private float distanciaMaxima = 300f;// Distancia máxima del rayo
    private string tagEditable = "Editable";// Tag de los objetos editables

    private float factorEscalado = 0.1f; // Factor de escala
    private Vector3 escalaMinima = new Vector3(0.3f, 0.3f, 0.3f); // Escala mínima del objeto
    private Vector3 escalaMaxima = new Vector3(3f, 3f, 3f); // Escala máxima del objeto


    public void Entrar(MenuStateMachine menus)
    {
        menus.controlMenus.CerrarMenus();
        objetoSeleccionado = null;// No hay ningún objeto seleccionado al entrar
    }

    public void Ejecutar(MenuStateMachine menus)
    {
        if (Camera.main == null) return;
        
        if(objetoSeleccionado != null)
        {
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            if (scroll != 0f)
            {
                Vector3 cambioEscala = Vector3.one * scroll * factorEscalado;
                Vector3 nuevaEscala = objetoSeleccionado.transform.localScale + cambioEscala;

                nuevaEscala.x = Mathf.Clamp(nuevaEscala.x, escalaMinima.x, escalaMaxima.x);
                nuevaEscala.y = Mathf.Clamp(nuevaEscala.y, escalaMinima.y, escalaMaxima.y);
                nuevaEscala.z = Mathf.Clamp(nuevaEscala.z, escalaMinima.z, escalaMaxima.z);

                objetoSeleccionado.transform.localScale = nuevaEscala;
            }

            if (Input.GetMouseButtonDown(1))
            {
                objetoSeleccionado = null;
            }
            return;
        }

        if (Input.GetMouseButtonDown(0))// Si se hace clic izquierdo
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit, distanciaMaxima))
            {
                if (hit.collider.CompareTag(tagEditable))// Verifica si el objeto tiene la etiqueta "Editable"
                {
                    objetoSeleccionado = hit.collider.gameObject;// Selecciona el objeto
                }
            }
        }
    }
    public void Salir(MenuStateMachine menus)
    {
        if (objetoSeleccionado != null)
        {
            objetoSeleccionado = null;
        }

    }
}
