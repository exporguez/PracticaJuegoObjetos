using UnityEditor.SceneManagement;
using UnityEngine;

public class MenuCrear : IEstado
{
    private float distanciaMaxima = 300f;// Distancia máxima del rayo
    public ControlMenus controlMenus;// Referencia al controlador de menús
    private GameObject objetoCreado;// Objeto que se está moviendo
    //private bool enMovimiento = false;// Indica si un objeto está en movimiento
    public MenuStateMachine menus;

    public void Entrar(MenuStateMachine menus)// Al entrar en el estado de crear edificio
    {
        menus.controlMenus.CerrarMenus();

        menus.AnimarEntradaPopUps(menus.controlMenus.popUpCrear);
        menus.AnimarEntradaMenuCrear(menus.controlMenus.menuLateralCrear);
        menus.controlMenus.menuCrear.SetActive(true);
        menus.controlMenus.menuLateralCrear.SetActive(true);
        objetoCreado = null; // No hay ningún edificio creado al entrar


    }

    public void Ejecutar(MenuStateMachine menus)// Lógica del estado de crear edificio
    {
        if (objetoCreado == null || Camera.main == null) return; // Si no hay un edificio creado o no hay una cámara principal, no hacer nada

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);// Crea un rayo desde la cámara hacia la posición del ratón
        RaycastHit hit;// Variable para almacenar la información del punto de colisión
        Debug.DrawRay(ray.origin, ray.direction * distanciaMaxima, Color.red, 0.1f);

        if (Physics.Raycast(ray, out hit, distanciaMaxima, menus.sueloMask))// Si el rayo colisiona con el suelo
        {
            Vector3 nuevaPosicion = hit.point;// Obtiene la posición del punto de colisión
            nuevaPosicion.y += objetoCreado.transform.localScale.y / 2f; // Ajusta la posición Y para que el edificio quede sobre el suelo
            objetoCreado.transform.position = hit.point;// Mueve el edificio a la nueva posición

        }



        if (Input.GetMouseButtonDown(0)) // Si se hace clic izquierdo
        {
            objetoCreado = null; // Confirma la colocación del edificio y deja de moverlo
        }
        if (Input.GetMouseButtonDown(1)) // Si se hace clic derecho
        {
            Object.Destroy(objetoCreado); // Destruye el edificio creado
            objetoCreado = null; // No hay ningún edificio creado

        }
        /*if (objetoCreado == null || Camera.main == null) return;// Si no hay un objeto creado o no hay una cámara principal, no hacer nada
        Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);// Crea un rayo desde la cámara hacia la posición del ratón
        Debug.DrawRay(myRay.origin, myRay.direction * distanciaMaxima, Color.red, 0.1f);
        RaycastHit hit;// Variable para almacenar la información del punto de colisión

        if (Physics.Raycast(myRay, out hit, distanciaMaxima, menus.sueloMask))
        {
            menus.MoverSombra(hit.point);
            Vector3 nuevaPosicion = hit.point;

            Collider col = objetoCreado.GetComponent<Collider>();
            if (col != null)
            {
                nuevaPosicion.y += col.bounds.extents.y; // Ajusta la posición en Y para que el objeto no se hunda en el suelo
            }
            else
            {
                nuevaPosicion.y += 0.5f; // Ajuste por defecto si no hay collider
            }

            objetoCreado.transform.position = nuevaPosicion; // Mueve el edificio a la nueva posición
            
        }

        if(Input.GetMouseButtonDown(0)) // Si se hace clic izquierdo
        {
            menus.ReproducirSonidoSoltar();
            menus.InstanciarParticulas(objetoCreado.transform.position);
            objetoCreado.layer = LayerMask.NameToLayer("Default");
            objetoCreado = null; // El objeto ya no está en movimiento
            menus.DestruirSombra();            
        }*/

    }

    public void Salir(MenuStateMachine menus)// Al salir del estado de crear edificio
    {
        if (!objetoCreado)
        {
            Object.Destroy(objetoCreado); // Destruye el edificio creado si existe
        }

        menus.controlMenus.menuCrear.SetActive(false);
        menus.controlMenus.menuLateralCrear.SetActive(false);
    }


}
