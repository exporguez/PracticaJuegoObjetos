using UnityEngine;

public class MenuEliminar : IEstado
{
    private MenuStateMachine menus;

    private float distanciaMaxima = 300f;// Distancia máxima del rayo

    private float duracionAnimacion = 0.2f;// Duración de la animación de reducción

    private string tagEditable = "Editable";// Etiqueta para los objetos que se pueden eliminar

    public void Entrar(MenuStateMachine menus)
    {
        menus.controlMenus.CerrarMenus();
        menus.AnimarEntradaPopUps(menus.controlMenus.popUpEliminar);
        menus.controlMenus.menuEliminar.SetActive(true);
        menus.capaDestruibleMask = LayerMask.GetMask("Default");

    }

    public void Ejecutar(MenuStateMachine menus)
    {
        if (Input.GetMouseButtonDown(0)) // Si se hace clic izquierdo
        {
            if (Camera.main == null) return; // Si no hay una cámara principal, no hacer nada

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, distanciaMaxima, menus.capaDestruibleMask)) // Si el rayo golpea un objeto en la capa "NoEditable"
            {
                GameObject objetoSeleccionado = hit.collider.gameObject;
                LeanTween.scale(objetoSeleccionado, Vector3.zero, duracionAnimacion).setEase(LeanTweenType.easeInQuad).setOnComplete(() => {
                    Object.Destroy(objetoSeleccionado);
                    Debug.Log("Destruido por animación: " + objetoSeleccionado.name);
                });

            }
        }
        /*if (Camera.main == null) return;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, distanciaMaxima))
            {
                if (hit.collider.CompareTag(tagEditable))
                {
                    GameObject objetoSeleccionado = hit.collider.gameObject;

                    
                    menus.controlMenus.objetoSeleccionadoParaEliminar = objetoSeleccionado;

                   
                    menus.AnimarEntradaPopUps(menus.controlMenus.popUpConfirmarEliminar);
                   
                    return;
                }
            }
        }*/
    }

    public void Salir(MenuStateMachine menus)
    {
        menus.controlMenus.menuEliminar.SetActive(false);
    }
}
